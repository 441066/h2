using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Text;

namespace HH_Parser_Request
{
    public class Specialization
    {
        public string id { get; set; }
        public bool laboring { get; set; }
        public string name { get; set; }
    }
    public class HeaderParameters
    {
        public HeaderParameters()
        {

        }
        public HeaderParameters(string i_key, string i_value)
        {
            key = i_key;
            value = i_value;
        }
        public string key { get; set; }
        public string value { get; set; }
    }
    public class Specializations
    {
        public List<Specialization> specializations { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    class Classes
    {
        public static async Task<string> Request(string url, List<HeaderParameters> PARAMS, string type, string body)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (PARAMS != null)
            {
                for (int i = 0; i < PARAMS.Count; i++)
                {
                    request.Headers.Add(PARAMS[i].key, PARAMS[i].value);
                }
            }
            request.Proxy = WebRequest.GetSystemWebProxy();
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36";
            request.Timeout = 30 * 1000;
            request.CookieContainer = new CookieContainer();
            request.MaximumAutomaticRedirections = 10;
            if (body != "")
            {
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] bytes = encoding.GetBytes(body);
                request.ContentType = "application/json";
                request.ContentLength = bytes.Length;
                Stream newStream = request.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
            }
            else
                request.ContentLength = 0;
            HttpWebResponse Resp = default(HttpWebResponse);

            await Task.Run(() =>
            {
                Resp = (HttpWebResponse)request.GetResponse();
            });
            Stream Str = Resp.GetResponseStream();
            StreamReader reader = new StreamReader(Str);
            string return_string = reader.ReadToEnd();
            reader.Close();
            Resp.Close();
            return return_string;
        }
    }
}
