using AQ3DClientLib.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib.Network.Models.Requests
{
    public class NetworkEmoteRequest : NetworkBaseRequest
    {
        [JsonProperty("em")]
        public StateEmoteEnum Emote { get; set; }

        public NetworkEmoteRequest(StateEmoteEnum emote) : base(21,0)
        {
            Emote = emote;
        }

    }
}
