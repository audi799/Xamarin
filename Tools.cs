using System;
using Newtonsoft.Json.Linq;

namespace REMICON.Common
{
    public class Tools
    {
        public Tools()
        {
        }
        public static string Base64Encoding(string EncodingText, System.Text.Encoding oEncoding = null)
        {
            if (oEncoding == null)
                oEncoding = System.Text.Encoding.UTF8;

            byte[] arr = oEncoding.GetBytes(EncodingText);
            return System.Convert.ToBase64String(arr);
        }

        public static string Base64Decoding(string DecodingText, System.Text.Encoding oEncoding = null)
        {
            if (oEncoding == null)
                oEncoding = System.Text.Encoding.UTF8;

            byte[] arr = System.Convert.FromBase64String(DecodingText);
            return oEncoding.GetString(arr);
        }


        public static string EncodeBase64Web(string s)
        {
            s = Base64Encoding(s);
            s = s.Replace("+", "_");
            s = s.Replace("=", "-");
            s = s.Replace("/", "|");

            return s;
        }

        public static string DecodeBase64Web(string s)
        {
            s = s.Replace("_", "+");
            s = s.Replace("-", "=");
            s = s.Replace("|", "/");
            s = Base64Decoding(s);

            return s;
        }

        public static double DecodeBase64Double(string s)
        {
            s = s.Replace("_", "+");
            s = s.Replace("-", "=");
            s = s.Replace("|", "/");
            s = Base64Decoding(s);

            double d = 0;
            if (string.IsNullOrEmpty(s))
            {

            }
            else
            {
                d = double.Parse(s);
            }
            return d;
        }

        public static string IsNull(JObject j, string f)
        {
            if (j.Property(f) != null)
            {
                return j.GetValue(f).ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
