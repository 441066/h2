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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HH_Parser_Request
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool force_go_next_spec = false;
        string path_to_save_with_spec;
        string filenametosave;
        string path_to_save = "";
        int global_counter_of_res_to_save = 0;
        int global_page_counter = 1;
        string total_res_to_save = "";
        string DateFormat = "dd.MM.yy HH:mm:ss";
        int global_proff_counter = 0;
        int global_query_counter = 0;
        List<QueryParams> HEADERS;
        string[] SPEACIALIZERS;
        private void Form1_Load(object sender, EventArgs e)
        {
            //nothing is do here
        }
        void MakeQueries()
        {
            HEADERS = new List<QueryParams>();
            string[] arr_raw = req_params.Text.Split('~');
            for (int i = 0; i < arr_raw.Length; i++)
            {
                string[] one_q_params = arr_raw[i].Trim().Split('\n');
                QueryParams Temp_Params = new QueryParams();
                for (int j = 0; j < one_q_params.Length; j++)
                {
                    string[] temp = one_q_params[j].Trim().Split('=');
                    Temp_Params.PushParam(new QueryParam(temp[0], temp[1]));
                }
                HEADERS.Add(Temp_Params);
            }
        }
        void SaveFile(string path_to_save_with_spec)
        {
            // save results if they are
            if (total_res_to_save.Trim().Length > 0)
            {
                filenametosave = "Result_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_" + global_counter_of_res_to_save + ".txt";
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
            log_box.Text = log_box.Text + "\n" + DateTime.Now.ToString(DateFormat) + " > " + text_to_log;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer_main.Enabled)
            {
                SPEACIALIZERS = spec_box.Text.Trim().Split('\n');
                MakeQueries();
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
            //Log("Сохраняем лог в файл");
            File.AppendAllText(Application.StartupPath + "\\log\\log_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt", log_box.Text, Encoding.UTF8);
            //log_box.Text = "";
            total_res_to_save = "";
            qry_result.Text = "";
        }

        public async Task<string> Request(string url, string type)
        {
            return await Classes.Request(url, type, "");
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer_main.Stop();
            //Если есть запросы
            if (global_query_counter < HEADERS.Count)
            {

                //если есть специальности по запросу
                if (global_proff_counter < SPEACIALIZERS.Length)
                {
                    //если есть страницы
                    if (global_page_counter < CONF.PAGES_COUNT)
                    {

                        //////////////////////////////////////

                        string temp_result_to_show_in_rtb = "";
                        if (log_box.Text.Length > 15000)
                        {
                            SaveLog();
                        }
                        string url_params = "";
                        url_params = "/?specialization=" + SPEACIALIZERS[global_proff_counter].ToString();
                        path_to_save = "";
                        for (int i = 0; i < HEADERS[global_query_counter].Params.Count; i++)
                        {
                            try
                            {
                                path_to_save += HEADERS[global_query_counter].Params[i].Key + "_" + HEADERS[global_query_counter].Params[i].Value + "_";
                                url_params += "&" + HEADERS[global_query_counter].Params[i].Key + "=" + HEADERS[global_query_counter].Params[i].Value;
                            }
                            catch
                            {
                                //Не удалось считать параметр
                            }
                        }

                        url_params += "&page=" + global_page_counter;
                        Log(String.Format("Отправляем запрос: {0} ", CONF.URL_RES + url_params));
                        string req_string = await Classes.Request(CONF.URL_RES + url_params, "GET", "");
                        //look if answer is long enough
                        if (req_string.Length > 500)
                        {
                            MatchCollection Resume_MA = CONF.RESUME_REGEX.Matches(req_string);
                            Log(String.Format("Специальность: {2} Страница: {0} Найдено: {1} Всего в запросе: {3}/{4}", global_page_counter, Resume_MA.Count, SPEACIALIZERS[global_proff_counter], (global_proff_counter + 1), SPEACIALIZERS.Length));
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
                                force_go_next_spec = true;
                            }
                        }
                        else
                        {
                            Log("Ответ слишком короткий");
                        }
                        //Show results in TB
                        qry_result.Text = temp_result_to_show_in_rtb;
                        path_to_save_with_spec = path_to_save + SPEACIALIZERS[global_proff_counter].ToString();

                        /////////////////////////////

                        if (force_go_next_spec)
                        {
                            //переходим к след. специальности принудительно, т.к страницы закончились
                            SaveFile(path_to_save_with_spec);
                            global_proff_counter++;
                            //обнуляем страницы
                            global_page_counter = 1;
                            Log(String.Format("Принудительно переходим к специальности {0}", SPEACIALIZERS[global_proff_counter]));
                            timer_main.Start();
                        }
                        else
                        {
                            //переходим к следующей странице в обчных условиях
                            global_page_counter++;
                            if (global_counter_of_res_to_save > CONF.RES_IN_FILE_TO_SAVE)
                            {
                                SaveFile(path_to_save_with_spec);
                            }
                            timer_main.Start();
                        }
                    }
                    else
                    {
                        //переходим к след. специальности т.к закончились страницы
                        SaveFile(path_to_save_with_spec);
                        Log(String.Format("Переходим к специальности {0} т.к закончились страницы", SPEACIALIZERS[global_proff_counter]));
                        global_proff_counter++;
                        //обнуляем страницы
                        global_page_counter = 1;
                        timer_main.Start();
                    }
                }
                else
                {
                    //переходим к след. запросу т.к закончились специализации и страницы
                    Log(String.Format("Переходим к следующему запросу {0}-{1}", HEADERS[global_query_counter].Params[0].Key, HEADERS[global_query_counter].Params[0].Value));
                    global_query_counter++;
                    global_proff_counter = 0;
                    global_page_counter = 1;
                    SaveFile(path_to_save_with_spec);
                    timer_main.Start();
                }

            }
            else
            {
                //закончились запросы, останавливаем работу вообще
                Log(String.Format("Больше нечего обрабатывать. Совсем нечего."));
            }
        }
    }
}
    
  
