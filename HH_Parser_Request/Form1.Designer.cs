namespace HH_Parser_Request
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.qry_result = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timer_main = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.req_params = new System.Windows.Forms.RichTextBox();
            this.log_box = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.spec_box = new System.Windows.Forms.RichTextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // qry_result
            // 
            this.qry_result.BackColor = System.Drawing.Color.Black;
            this.qry_result.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qry_result.ForeColor = System.Drawing.Color.Lime;
            this.qry_result.Location = new System.Drawing.Point(14, 435);
            this.qry_result.Name = "qry_result";
            this.qry_result.ReadOnly = true;
            this.qry_result.Size = new System.Drawing.Size(375, 205);
            this.qry_result.TabIndex = 0;
            this.qry_result.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(375, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer_main
            // 
            this.timer_main.Interval = 600;
            this.timer_main.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Запросы";
            // 
            // req_params
            // 
            this.req_params.BackColor = System.Drawing.Color.Black;
            this.req_params.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.req_params.ForeColor = System.Drawing.Color.Lime;
            this.req_params.Location = new System.Drawing.Point(12, 29);
            this.req_params.Name = "req_params";
            this.req_params.Size = new System.Drawing.Size(375, 192);
            this.req_params.TabIndex = 3;
            this.req_params.Text = "area=1\nexperience=noExperience\n~\narea=113\nexperience=noExperience\n~\narea=2\nexperi" +
    "ence=noExperience";
            // 
            // log_box
            // 
            this.log_box.BackColor = System.Drawing.Color.Black;
            this.log_box.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.log_box.ForeColor = System.Drawing.Color.Lime;
            this.log_box.Location = new System.Drawing.Point(395, 29);
            this.log_box.Name = "log_box";
            this.log_box.ReadOnly = true;
            this.log_box.Size = new System.Drawing.Size(602, 611);
            this.log_box.TabIndex = 4;
            this.log_box.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "log";
            // 
            // spec_box
            // 
            this.spec_box.BackColor = System.Drawing.Color.Black;
            this.spec_box.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.spec_box.ForeColor = System.Drawing.Color.Lime;
            this.spec_box.Location = new System.Drawing.Point(14, 227);
            this.spec_box.Name = "spec_box";
            this.spec_box.Size = new System.Drawing.Size(375, 166);
            this.spec_box.TabIndex = 7;
            this.spec_box.Text = resources.GetString("spec_box.Text");
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "В работе";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 652);
            this.Controls.Add(this.spec_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.log_box);
            this.Controls.Add(this.req_params);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.qry_result);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox qry_result;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer_main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox req_params;
        private System.Windows.Forms.RichTextBox log_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox spec_box;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

