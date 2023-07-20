using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib.Network.Models.Requests
{
    public class NetworkBaseRequest
    {
        [JsonProperty("type")]
        public byte Type { get; set; }
        [JsonProperty("cmd")]
        public byte Cmd { get; set; }


        public NetworkBaseRequest() { }

        public NetworkBaseRequest(byte type, byte cmd)
        {
            Type = type;
            Cmd = cmd;
        }


    }
}
