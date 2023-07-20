using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib.Models
{
    public class ServerInfo
    {
        [JsonProperty("ID")]
        public int Id { get; set; }
        public int SortIndex { get; set; }
        public string Name { get; set; }
        public string HostName { get; set; }
        public int Port { get; set; }
        public int UserCount { get; set; }
        public int MaxUsers { get; set; }
        public bool State { get; set; }
        public bool Chat { get; set; }
        public string Language { get; set; }
        public string IP { get; set; }
        public string LocalIP { get; set; }
        public int Connections { get; set; }
        public int AlertLevel { get; set; }
        public int Status { get; set; }
        public string Region { get; set; }
    }
}
