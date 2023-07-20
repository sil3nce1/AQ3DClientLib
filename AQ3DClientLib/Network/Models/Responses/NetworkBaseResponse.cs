using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib.Network.Models.Responses
{
    public class NetworkBaseResponse
    {
        [JsonProperty("type")]
        public byte Type { get; set; }
        [JsonProperty("cmd")]
        public byte Cmd { get; set; }


        public NetworkBaseResponse() { }

        public NetworkBaseResponse(byte type, byte cmd)
        {
            Type = type;
            Cmd = cmd;
        }
    }
}
