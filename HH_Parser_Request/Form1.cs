using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using xNet;

namespace HH_Parser_Request
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DateTime Start;
        DateTime End;
        private void button1_Click(object sender, EventArgs e)
        {
            request.AddUrlParam("specialization", "15");
            string req_string = request.Get("http://hh.ru/search/resume").ToString();
            MatchCollection Resume_MA = config.RESUME_REGEX.Matches(req_string);
            foreach (Match OneResume in Resume_MA)
                if (!richTextBox1.Text.Contains(OneResume.Value))
                    richTextBox1.Text += OneResume.Value + "\n";
        }
        HttpRequest request;
        private void Form1_Load(object sender, EventArgs e)
        {
            request = new HttpRequest();
            request.Cookies = new CookieDictionary();
            request.UserAgent = Http.ChromeUserAgent();
            request.MaximumAutomaticRedirections = 6;
        }
    }
}
