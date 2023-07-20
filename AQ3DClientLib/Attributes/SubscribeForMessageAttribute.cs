using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SubscribeForMessageAttribute : Attribute
    {
        public byte Type { get; set; }
        public byte Cmd { get; set; }

        public SubscribeForMessageAttribute(byte type, byte cmd)
        {
            Type = type;
            Cmd = cmd;
        }
    }
}
