using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib.Models
{
    public class Character
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        [JsonProperty("level")]
        public int Level { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        public string ClassName { get; set; }
        public int TotalClassRank { get; set; }
    }
}
