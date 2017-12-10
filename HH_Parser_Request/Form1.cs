using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            Start = DateTime.Now;
            request.AddUrlParam("specialization", "15");
            #region subj
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

            #endregion
            string total = request.Get("http://hh.ru/search/resume").ToString();
            richTextBox1.Text = total;
            End = DateTime.Now;
            this.Text = (End - Start).TotalSeconds.ToString();
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
