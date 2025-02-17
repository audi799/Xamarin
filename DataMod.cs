using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace REMICON.Common
{
    public class DataMod
    {
        public String URL = "http://211.105.106.**:8080/GM/getData.jsp?APINO=100&";
        public string eURL = "http://211.105.106.**:8080/GM/excuteData.jsp?APINO=100&";

        public DataMod()
        {
        }

        //public async Task<JArray> GetData(string Q, string C, string S)
        public async Task<JArray> GetDataByASync(string Q, string C, string S)
        {
            Debug.WriteLine("GetData 시작");
            String U = URL;
            Q = Common.Tools.EncodeBase64Web(Q);
            S = Common.Tools.EncodeBase64Web(S);
            C = Common.Tools.EncodeBase64Web(C);

            U += "Q=" + Q + "&";
            U += "S=" + S + "&";
            U += "C=" + C + "";

            JArray jArray = null;
            Uri sURL = new Uri(U);

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    var result = await webClient.DownloadDataTaskAsync(sURL);
                    string s = Encoding.UTF8.GetString(result);
                    jArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(s);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"              ERROR {0}", ex.Message);
                }
            }
            Debug.WriteLine("GetData 끝");

            return jArray;
        }

        public JArray GetData(string Q, string C, string S)
        {
            Debug.WriteLine("GetData 시작");
            String U = URL;
            Q = Common.Tools.EncodeBase64Web(Q);
            S = Common.Tools.EncodeBase64Web(S);
            C = Common.Tools.EncodeBase64Web(C);

            U += "Q=" + Q + "&";
            U += "S=" + S + "&";
            U += "C=" + C + "";

            JArray jArray = null;
            Uri sURL = new Uri(U);

            Debug.WriteLine(sURL);
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    //var result = await webClient.DownloadDataTaskAsync(sURL);
                    var result = webClient.DownloadData(sURL);
                    string s = Encoding.UTF8.GetString(result);
                    jArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(s);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"              ERROR {0}", ex.Message);
                }
            }
            Debug.WriteLine("GetData 끝");

            return jArray;
        }

        public string ExcuteData(string Q, string C, string S)
        {
            Debug.WriteLine("ExcuteData 시작");
            String U = eURL;
            Q = Common.Tools.EncodeBase64Web(Q);
            S = Common.Tools.EncodeBase64Web(S);
            C = Common.Tools.EncodeBase64Web(C);

            U += "Q=" + Q + "&";
            U += "S=" + S + "&";
            U += "C=" + C + "";

            Uri sURL = new Uri(U);

            Debug.WriteLine(sURL);
            string s = "";
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    //var result = await webClient.DownloadDataTaskAsync(sURL);
                    var result = webClient.DownloadData(sURL);
                    s = Encoding.UTF8.GetString(result);

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"              ERROR {0}", ex.Message);
                }
            }
            Debug.WriteLine("ExcuteData 끝");

            return s;
        }

        public string GetStartYmd(string companyCode)
        {
            return "2019-01-01";
        }
    }
}
