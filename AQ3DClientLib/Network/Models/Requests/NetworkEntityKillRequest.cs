using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib.Network.Models.Requests
{
    public class NetworkEntityKillRequest : NetworkBaseRequest
    {
        public NetworkEntityKillRequest() : base(17, 13) { }
    }
}
