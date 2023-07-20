using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib.Network.Models.Requests
{
    public class NetworkRespawnRequest : NetworkBaseRequest
    {
        public NetworkRespawnRequest() : base(17, 4) { }
    }
}
