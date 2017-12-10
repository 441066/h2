using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private void Form1_Load(object sender, EventArgs e)
        {
            request = new HttpRequest();
            request.Cookies = new CookieDictionary();
            request.UserAgent = Http.ChromeUserAgent();
            request.MaximumAutomaticRedirections = 10;
            //List<Specializations> SPECS = Classes.GetAllSpec();
        }

        void Log(string text_to_log)
        {
            log_box.Text = DateTime.Now.ToString(DateFormat) + " > " + text_to_log + "\n" + log_box.Text;
        }
        DateTime Work_Start;
        DateTime Work_End;
        DateTime Q_Start;
        DateTime Q_End;
        string path_to_save = "";
        int global_counter_of_res_to_save = 0;
        int global_page_counter = 1;
        HttpRequest request;
        bool need_to_stop = false;
        string total_res_to_save = "";
        string DateFormat = "dd.MM.yyyy HH:mm:ss:fff";
        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer_main.Enabled)
            {
                string[] parameters = req_params.Text.Split('\n');
                for (int i = 0; i < parameters.Length; i++)
                {
                    try
                    {
                        path_to_save += parameters[i] + "_";
                        string[] res = parameters[i].Split('=');
                        request.AddUrlParam(res[0], res[1]);
                    }
                    catch
                    {
                        Log("Не удалось считать параметр: " + parameters[i]);
                    }
                }
                Work_Start = DateTime.Now;
                button1.Text = "STOP";
                timer_main.Start();
            }
            else
            {
                button1.Text = "START";
                timer_main.Stop();
            }
        }
        void SaveLog()
        {
            if (!Directory.Exists(Application.StartupPath + "\\log"))
                Directory.CreateDirectory(Application.StartupPath + "\\log");
            Log("Сохраняем лог в файл");
            File.AppendAllText(Application.StartupPath + "\\log\\log_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + ".txt", log_box.Text, Encoding.UTF8);
            log_box.Text = "";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer_main.Stop();
            string temp_result_to_show_in_rtb = "";
            //Clean some trash from Rich TB
            //if (qry_result.Text.Length > 1000)
            //   qry_result.Text = "";

            if (log_box.Text.Length > 15000)
            {
                SaveLog();
            }

            //work here start
            request.AddUrlParam("page", global_page_counter);
            string req_string = request.Get(CONF.URL_RES).ToString();
            //look if answer is long enough
            if (req_string.Length > 500)
            {
                MatchCollection Resume_MA = CONF.RESUME_REGEX.Matches(req_string);
                Log(String.Format("На странице {0} найдено: {1}", global_page_counter, Resume_MA.Count));
                foreach (Match OneResume in Resume_MA)
                {
                    if (!qry_result.Text.Contains(OneResume.Value))
                    {

                        total_res_to_save += OneResume.Value.Replace("/resume/", "") + "\n";
                        temp_result_to_show_in_rtb += OneResume.Value.Replace("/resume/", "") + "\n";
                        global_counter_of_res_to_save++;
                    }
                    else
                    {
                        //paste some sheet about repeats
                    }
                }
            }
            else
            {
                Log("Ответ слишком короткий, останавливаем работу");
                need_to_stop = true;
            }
            //Show results in TB
            qry_result.Text = temp_result_to_show_in_rtb;
            //save some here
            //if (global_counter_of_res_to_save > CONF.RES_IN_FILE_TO_SAVE)
            if (global_counter_of_res_to_save > 1000)
            {
                string filenametosave = "Result_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_" + global_counter_of_res_to_save + ".txt";
                if (!Directory.Exists(Application.StartupPath + "\\" + path_to_save))
                    Directory.CreateDirectory(Application.StartupPath + "\\" + path_to_save);

                File.AppendAllText(Application.StartupPath + "\\" + path_to_save + "\\" + filenametosave, total_res_to_save, Encoding.UTF8);
                global_counter_of_res_to_save = 0;
                total_res_to_save = "";
                qry_result.Text = "";
                Log("Результат сохранен в файал: " + Application.StartupPath + "\\" + path_to_save + "\\" + filenametosave);
            }
            //work here end
            if (!need_to_stop && global_page_counter < CONF.PAGES_COUNT)
            {
                global_page_counter++;
                timer_main.Start();
            }
            else
            {
                Work_End = DateTime.Now;
                // save last results
                string filenametosave = "Result_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_" + global_counter_of_res_to_save + ".txt";
                if (!Directory.Exists(Application.StartupPath + "\\" + path_to_save))
                    Directory.CreateDirectory(Application.StartupPath + "\\" + path_to_save);
                File.AppendAllText(Application.StartupPath + "\\" + path_to_save + "\\" + filenametosave, total_res_to_save, Encoding.UTF8);
                SaveLog();
                Log("Обработка закончена\nВремени затрачено (минут): " + (Work_End - Work_Start).TotalMinutes.ToString());

                //save last here
            }
        }
    }
}
