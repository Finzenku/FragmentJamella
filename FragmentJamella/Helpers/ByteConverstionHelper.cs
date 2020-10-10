using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragmentJamella.Helpers
{
    public static class ByteConverstionHelper
    {
        public static string converyBytesToSJIS(byte[] data)
        {
            try
            {
                var cleanedString = Encoding.GetEncoding(932).GetString(data).Split(new string[] { "\0" }, StringSplitOptions.None);
                return cleanedString[0].Replace(',', ' ');
            }
            catch (Exception)
            {

                return "";
            }
        }

        public static string convertBytesToString(byte[] data)
        {
            if (data != null)
            {
                string result;

                data.Reverse();

                result = Encoding.Default.GetString(data);

                var cleanedString = result.Split(new string[] { "\0" }, StringSplitOptions.None);
                return cleanedString[0].Replace(',', ' ');
            }
            else
            {
                return "";
            }
        }
    }


}
