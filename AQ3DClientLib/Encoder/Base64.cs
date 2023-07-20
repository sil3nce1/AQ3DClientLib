using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AQ3DClientLib.Encoder
{
    public static class Base64
    {
        public static string Encode(string text)
        {
            try
            {
                byte[] textAsBytes = Encoding.UTF8.GetBytes(text);
                string result = Convert.ToBase64String(textAsBytes);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
