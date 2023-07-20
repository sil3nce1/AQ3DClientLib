using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib.Network.Models.Responses
{
    public class NetworkLoginResponse
    {
        [JsonProperty("status")]
        public int Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("UserID")]
        public int UserId { get; set; }
        [JsonProperty("ID")]
        public int Id { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }
        public int XPToLevel { get; set; }
        public int LevelCap { get; set; }
        public int EndGame { get; set; }
        public int Gold { get; set; }
        public int MC { get; set; }
    }
}
