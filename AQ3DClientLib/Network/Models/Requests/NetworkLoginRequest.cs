using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib.Network.Models.Requests
{
    public class NetworkLoginRequest : NetworkBaseRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }

        public NetworkLoginRequest(int id, string token) : base(3,1)
        {
            Id = id;
            Token = token;
        }
    }
}
