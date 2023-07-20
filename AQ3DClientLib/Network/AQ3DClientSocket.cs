using AQ3DClientLib.Attributes;
using AQ3DClientLib.Models;
using AQ3DClientLib.Network.Models.Requests;
using AQ3DClientLib.Serialization;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reactive;
using System.Reactive.Linq;
using System.Reflection;
using AQ3DClientLib.Network.Models.Responses;
using System.Text.RegularExpressions;
using System.Text.Json;

namespace AQ3DClientLib.Network
{
    public class AQ3DClientSocket
    {
        public string IP { get; set; }
        public int Port { get; set; }

        private TcpClient _client;
        private Socket _socket;
        private IPEndPoint _endPoint;

        private static JsonSerializerSettings serializingSettings = new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore
        };

        private static JsonSerializerSettings deserializingSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Binder = new TypeNameSerializationBinder()
        };



        public AQ3DClientSocket(ServerInfo server)
        {
            IP = Dns.GetHostEntry(server.HostName).AddressList[0].ToString();
            Port = server.Port;
            //_endPoint = new IPEndPoint(Dns.GetHostEntry(server.HostName).AddressList[0], Port);
            //_socket = new Socket(_endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            
        }

        public AQ3DClientSocket(string ip, int port)
        {
            IP = ip;
            Port = port;
        }

        public void Connect()
        {
            try
            {
                _client = new TcpClient(IP, Port);
                //_socket.Connect(_endPoint);
                Thread thread = new Thread(ReadMessage);
                thread.IsBackground = true;
                thread.Start();
            }
            catch
            {
                throw;
            }
        }

        void EncryptDecrypt(byte[] data)
        {
            byte[] key = new byte[] { 250, 158, 179 };

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != key[i % key.Length])
                {
                    data[i] ^= key[i % key.Length];
                }
            }
        }

        public void SendRequest(NetworkBaseRequest request)
        {
            string text = JsonConvert.SerializeObject(request, Formatting.None, serializingSettings);

            byte[] bytes = Encoding.UTF8.GetBytes(text);
            byte[] array = new byte[bytes.Length + 2];
            array[0] = request.Type;
            array[1] = request.Cmd;
            Buffer.BlockCopy(bytes, 0, array, 2, bytes.Length);
            EncryptDecrypt(array);
            SendMessage(array);
        }

        void SendMessage(byte[] data)
        {
            byte[] array = new byte[data.Length + 1];
            Buffer.BlockCopy(data, 0, array, 0, data.Length);

            array[data.Length] = 0;

            NetworkStream ns = _client.GetStream();
            ns.Write(array, 0, array.Length);
        }

        T Deserialize<T>(string msg)
        {
            return JsonConvert.DeserializeObject<T>(msg, deserializingSettings);
        }


        void ReadMessage()
        {
            while (true)
            {
                try
                {
                    //NetworkStream ns = _client.GetStream();
                    byte[] buffer = new byte[100000];

                    int messageLength = _socket.Receive(buffer,0);

                    Array.Resize(ref buffer, messageLength);
                    

                    EncryptDecrypt(buffer);

                    byte type = buffer[0];
                    byte cmd = buffer[1];
                    //string fullMessage = Encoding.UTF8.GetString(buffer, 0, messageLength);

                    string messageAsStr = Encoding.UTF8.GetString(buffer, 2, messageLength - 2);

                    if (messageAsStr != null && messageAsStr != string.Empty)
                    {
                        var methods = typeof(AQ3DClientSocket)
                            .GetMethods()
                            .Where(m => m.GetCustomAttribute(typeof(SubscribeForMessageAttribute)) != null)
                            .Where(m => new MethodInvoker(m.GetCustomAttribute(typeof(SubscribeForMessageAttribute))).Attr.Type == type)
                             .Where(m => new MethodInvoker(m.GetCustomAttribute(typeof(SubscribeForMessageAttribute))).Attr.Cmd == cmd);

                        if (methods.Any())
                        {
                            foreach (MethodInfo method in methods)
                            {
                                method.Invoke(this, new[] { messageAsStr });
                            }
                        }
                        else
                            Console.WriteLine("No handler found for Type: {0} and Cmd: {1}", type.ToString(), cmd.ToString());

                    }
                }
                catch
                {
                    continue;
                }
            }
            
        }


        [SubscribeForMessage(3, 255)]
        public void HandleLoginResponse(string msg)
        {
            NetworkLoginResponse loginResponse = Deserialize<NetworkLoginResponse>(msg);
            Console.WriteLine(loginResponse.XP);
        }

        [SubscribeForMessage(18, 2)]
        public void HandleEntityData(string msg)
        {
            msg = msg.Substring(0, msg.Length - 1);
            //Entity entity = Deserialize<NetworkEntityResponse>(msg).Entity;
        }


    }
}
