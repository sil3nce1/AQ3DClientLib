using AQ3DClientLib.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib
{
    public class MethodInvoker
    {
        public SubscribeForMessageAttribute Attr { get; set; }

        public MethodInvoker(Attribute attr)
        {
            Attr = (SubscribeForMessageAttribute)attr;
        }
    }
}
