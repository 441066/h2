using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HH_Parser_Request
{

    //.AddUrlParam("data2", "value2")
    // Parameters 'x-www-form-urlencoded'.
    //.AddParam("data1", "value1")
    // .AddParam("data2", "value2")
    // .AddParam("data2", "value2")

    // Multipart data.
    //.AddField("data1", "value1")
    //.AddFile("game_code", @"C:\orion.zip")

    // HTTP-header.
    //.AddHeader("X-Apocalypse", "21.12.12");

    // These parameters are sent in this request.
    //request.Post("/").None();
    // But in this request they will be gone.
    //request.Post("/").None();

    public static class CONF
    {
        public static Regex RESUME_REGEX = new Regex(@"/resume/[a-z0-9]{38}", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        public static string URL_RES = "http://hh.ru/search/resume";
        public const int PAGES_COUNT = 249;
        public const int RES_IN_FILE_TO_SAVE = 1000;
        public const int RES_IN_FILE_TO_SAVE_2 = 1000;

    }
}
