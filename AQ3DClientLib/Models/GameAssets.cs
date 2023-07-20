using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib.Models
{
    public class GameAssets
    {
        public string FileName { get; set; }
        public int Version { get; set; }
        public Int64 CRCAndroid { get; set; }
        public Int64 CRCIOS { get; set; }
        public Int64 CRCPC { get; set; }
        public Int64 CRCOSX { get; set; }
    }
}
