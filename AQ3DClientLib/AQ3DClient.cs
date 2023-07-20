using AQ3DClientLib.Http;
using AQ3DClientLib.Http.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AQ3DClientLib.Models;
using AQ3DClientLib.Network;
using AQ3DClientLib.Network.Models.Requests;
using AQ3DClientLib.Enums;

namespace AQ3DClientLib
{
    public class AQ3DClient : IAQ3DClient
    {
        public string Email { get; }
        public string Password { get; }
        public Account Account { get; private set; }
        public ServerInfo SelectedServer { get; private set; }
        public Character SelectedCharacter { get; private set; }
        private AQ3DClientSocket _clientSocket;

        public AQ3DClient(string email, string password)
        {
            Email = email;
            Password = password;
        }


        public async Task<bool> ConnectAsync()
        {
            AQ3DHttpLoginResponse response = await AQ3DClientHttp.Login(Email, Password);

            if (response.Account != null)
                Account = response.Account;

            return response.Account != null;

        }

        public void SelectServer(ServerInfo server)
        {
            SelectedServer = server;
        }

        public async Task<ServerInfo[]> GetServers()
        {
            ServerInfo[] servers = await AQ3DClientHttp.GetServers();
            return servers.Where(s => s.Status == 1).ToArray();
        }

        
        public void SendChatMessage(int channelId, string message)
        { 
            _clientSocket.SendRequest(new NetworkMessageChatRequest(channelId, message));
        }

        public void Suicide()
        {
            _clientSocket.SendRequest(new NetworkEntityKillRequest());
        }

        public void Respawn()
        {
            _clientSocket.SendRequest(new NetworkRespawnRequest());
        }

        public void Emote(StateEmoteEnum emote)
        {
            _clientSocket.SendRequest(new NetworkEmoteRequest(emote));
        }

        public void SendPosition(int state, float posX, float posY, float posZ, float rotation)
        {
            _clientSocket.SendRequest(new NetworkSendPositionRequest(state, posX, posY, posZ, rotation, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()));
        }

        public bool ConnectToWorld(ServerInfo server, Character character)
        {
            try
            {
                _clientSocket = new AQ3DClientSocket(server);
                _clientSocket.Connect();

                _clientSocket.SendRequest(new NetworkLoginRequest(character.Id, Account.StrToken));

                SelectedCharacter = character;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Character[] GetCharacters()
        {
            return Account.chars;
        }
    }
}
