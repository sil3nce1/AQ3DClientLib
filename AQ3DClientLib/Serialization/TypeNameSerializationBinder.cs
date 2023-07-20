using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib.Serialization
{
    public class TypeNameSerializationBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            try
            {
                return Type.GetType(typeName, true);
            }
            catch (Exception exception)
            {
                throw;
            }
            return null;
        }
    }
}
