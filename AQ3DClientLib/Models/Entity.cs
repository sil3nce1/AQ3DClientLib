using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib.Models
{
    public class Entity
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        public Int64 ClassXP;
        public int Level { get; set; }
        [JsonProperty("posX")]
        public float PosX;
        [JsonProperty("posY")]
        public float PosY;
        [JsonProperty("posZ")]
        public float PosZ;


    }
}
