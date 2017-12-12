using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xNet;

namespace HH_Parser_Request
{
    public class Specialization
    {
        public string id { get; set; }
        public bool laboring { get; set; }
        public string name { get; set; }
    }

    public class Specializations
    {
        public List<Specialization> specializations { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    class Classes
    {
        //on use now
        public static List<Specializations> GetAllSpec()
        {
            List<Specializations> Specs = new List<Specializations>();
            HttpRequest request = new HttpRequest();
            //request.Proxy.Host = "192.168.1.234";
            //request.Proxy.Port = 3128;
            string result = request.Get("https://api.hh.ru/specializations").ToString();
            Specs = JsonConvert.DeserializeObject<List<Specializations>>(result);       
            return Specs;
        }
    }
}
