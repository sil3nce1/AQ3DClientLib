using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib.Models
{
    public class Account
    {
        public int UserId { get; set; }
        [JsonProperty("strToken")]
        public string StrToken { get; set; }
        [JsonProperty("strCountryCode")]
        public string StrCountryCode { get; set; }
        public int LevelCap { get; set; }
        public Int64 EventBitTracker { get; set; }
        [JsonProperty("strRegion")]
        public string StrRegion { get; set; }
        public Character[] chars { get; set; }
        [JsonProperty("bundles")]
        public AccountBundles Bundles { get; set; }

        public bool Success { get; set; }
    }
}
