using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib.Network.Models.Requests
{
    public class NetworkMessageChatRequest : NetworkBaseRequest
    {
        [JsonProperty("channelID")]
        public int ChannelId { get; set; }
        [JsonProperty("msg")]
        public string Message { get; set; }

        public NetworkMessageChatRequest(int channelId, string msg) : base(4, 1)
        {
            ChannelId = channelId;
            Message = msg;
        }

    }
}
