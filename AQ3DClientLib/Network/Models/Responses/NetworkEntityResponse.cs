using AQ3DClientLib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib.Network.Models.Responses
{
    public class NetworkEntityResponse
    {
        [JsonProperty("entity")]
        public Entity Entity { get; set; }
    }
}
