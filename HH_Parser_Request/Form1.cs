using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HH_Parser_Request
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool go_next_spec = false;
        DateTime Work_Start;
        DateTime Work_End;
        string path_to_save = "";
        int global_counter_of_res_to_save = 0;
        int global_page_counter = 1;
        bool need_to_stop = false;
        string total_res_to_save = "";
        string DateFormat = "dd.MM.yy HH:mm:ss";
        int global_proff_counter = 0;
        List<HeaderParameters> HEADERS;
        string[] SPEACIALIZERS;
        private void Form1_Load(object sender, EventArgs e)
        {
            //nothing is do here
        }
        void SaveFile(string path_to_save_with_spec)
        {
            // save results if they are
            if (total_res_to_save.Trim().Length > 0)
            {
                string filenametosave = "Result_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_" + global_counter_of_res_to_save + ".txt";
                if (!Directory.Exists(Application.StartupPath + "\\" + path_to_save_with_spec))
                    Directory.CreateDirectory(Application.StartupPath + "\\" + path_to_save_with_spec);
                File.AppendAllText(Application.StartupPath + "\\" + path_to_save_with_spec + "\\" + filenametosave, total_res_to_save, Encoding.UTF8);
                SaveLog();
                total_res_to_save = "";
                global_counter_of_res_to_save = 0;
            }
        }
        void Log(string text_to_log)
        {
            log_box.Text = DateTime.Now.ToString(DateFormat) + " > " + text_to_log + "\n" + log_box.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer_main.Enabled)
            {
                SPEACIALIZERS = spec_box.Text.Trim().Split('\n');
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
            total_res_to_save = "";
            qry_result.Text = "";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer_main.Stop();
            string temp_result_to_show_in_rtb = "";
            if (log_box.Text.Length > 15000)
            {
                SaveLog();
            }
            string url_params = "";
            HEADERS = new List<HeaderParameters>();
            url_params = "/?specialization=" + SPEACIALIZERS[global_proff_counter].ToString();
            //HEADERS.Add(new HeaderParameters("specialization", SPEACIALIZERS[global_proff_counter].ToString()));
            string[] parameters = req_params.Text.Split('\n');
            path_to_save = "";
            for (int i = 0; i < parameters.Length; i++)
            {
                try
                {
                    path_to_save += parameters[i] + "_";
                    string[] res = parameters[i].Split('=');
                    url_params += "&" + res[0] + "=" + res[1];
                    //HEADERS.Add(new HeaderParameters(res[0], res[1]));
                }
                catch
                {
                    Log("Не удалось считать параметр: " + parameters[i]);
                }
            }

            url_params += "&page=" + global_page_counter;
            //HEADERS.Add(new HeaderParameters("page", global_page_counter.ToString()));
            string req_string = Classes.Request(CONF.URL_RES + url_params, HEADERS, "GET", "");
            //look if answer is long enough
            if (req_string.Length > 500)
            {
                MatchCollection Resume_MA = CONF.RESUME_REGEX.Matches(req_string);
                Log(String.Format("Страница: {0} Специальность: {2} Найдено: {1} Всего: {3}/{4}", global_page_counter, Resume_MA.Count, SPEACIALIZERS[global_proff_counter], global_proff_counter, SPEACIALIZERS.Length));
                if (Resume_MA.Count > 0)
                {
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
                    go_next_spec = true;
                }
            }
            else
            {
                Log("Ответ слишком короткий, останавливаем работу");
                need_to_stop = true;
            }
            //Show results in TB
            qry_result.Text = temp_result_to_show_in_rtb;
            //save here

            string path_to_save_with_spec = path_to_save + SPEACIALIZERS[global_proff_counter].ToString();
            //ok save
            if (global_counter_of_res_to_save > CONF.RES_IN_FILE_TO_SAVE)
            {
                SaveFile(path_to_save_with_spec);
                global_counter_of_res_to_save = 0;
                string filenametosave = "Result_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_" + global_counter_of_res_to_save + ".txt";
                Log("Результат сохранен в файал: " + Application.StartupPath + "\\" + path_to_save_with_spec + "\\" + filenametosave);
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
                SaveFile(path_to_save_with_spec);
                Log("Обработка закончена\nВремени затрачено (минут): " + (Work_End - Work_Start).TotalMinutes.ToString());
                if (global_proff_counter < SPEACIALIZERS.Length)
                {
                    global_proff_counter++;
                    global_page_counter = 1;
                    Log("Переходим к следующей специальности: " + SPEACIALIZERS[global_proff_counter]);
                    timer_main.Start();
                }
            }
            //save last here
            if (go_next_spec)
            {
                go_next_spec = false;
                Work_End = DateTime.Now;
                string filenametosave = "Result_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_" + global_counter_of_res_to_save + ".txt";
                SaveFile(path_to_save_with_spec);
                SaveLog();
                Log("Обработка закончена\nВремени затрачено (минут): " + (Work_End - Work_Start).TotalMinutes.ToString());
                global_proff_counter++;
                global_page_counter = 1;
                if (global_proff_counter < SPEACIALIZERS.Length)
                {
                    Log("Переходим к следующей специальности: " + SPEACIALIZERS[global_proff_counter]);
                    timer_main.Start();
                }
                else
                {
                    timer_main.Stop();
                    Work_End = DateTime.Now;
                    Log("ВСЕ, РАБОТА ВООБЩЕ ЗАКОНЧЕНА.\nВремени затрачено (минут): " + (Work_End - Work_Start).TotalMinutes.ToString());
                    filenametosave = "Result_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_" + global_counter_of_res_to_save + ".txt";
                    SaveFile(path_to_save_with_spec);
                    MessageBox.Show("Всё, запрос полностью обработан!");
                }
            }
        }
    }
}
