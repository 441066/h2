using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HH_Parser_Request
{
    public static class CONF
    {
        public static Regex RESUME_REGEX = new Regex(@"/resume/[a-z0-9]{38}", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        public static string URL_RES = "http://hh.ru/search/resume";
        public const int PAGES_COUNT = 3;
        public const int RES_IN_FILE_TO_SAVE = 1000;
    }
}
