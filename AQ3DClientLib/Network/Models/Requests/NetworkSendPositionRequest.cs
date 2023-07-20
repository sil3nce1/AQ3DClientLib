using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib.Network.Models.Requests
{
    public class NetworkSendPositionRequest : NetworkBaseRequest
    {
        [JsonProperty("state")]
        public int State { get; set; }
        [JsonProperty("posX")]
        public float PosX { get; set; }
        [JsonProperty("posY")]
        public float PosY { get; set; }
        [JsonProperty("posZ")]
        public float PosZ { get; set; }
        [JsonProperty("rotY")]
        public float RotY { get; set; }
        [JsonProperty("timeStamp")]
        public long TimeStamp { get; set; }
        public NetworkSendPositionRequest(int state, float posX, float posY, float posZ, float rotY, long timeStamp): base(1, 1)
        {
            State = state;
            PosX = posX;
            PosY = posY;
            PosZ = posZ;
            RotY = rotY;
            TimeStamp = timeStamp;
        }
    }
}
