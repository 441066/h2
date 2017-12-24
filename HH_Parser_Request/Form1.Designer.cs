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
            this.listView1 = new System.Windows.Forms.ListView();
            this.key = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
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
            this.timer_main.Interval = 800;
            this.timer_main.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "qry params";
            // 
            // req_params
            // 
            this.req_params.BackColor = System.Drawing.Color.Black;
            this.req_params.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.req_params.ForeColor = System.Drawing.Color.Lime;
            this.req_params.Location = new System.Drawing.Point(14, 29);
            this.req_params.Name = "req_params";
            this.req_params.Size = new System.Drawing.Size(375, 89);
            this.req_params.TabIndex = 3;
            this.req_params.Text = "area=1\nexperience=noExperience";
            // 
            // log_box
            // 
            this.log_box.BackColor = System.Drawing.Color.Black;
            this.log_box.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.log_box.ForeColor = System.Drawing.Color.Lime;
            this.log_box.Location = new System.Drawing.Point(395, 237);
            this.log_box.Name = "log_box";
            this.log_box.ReadOnly = true;
            this.log_box.Size = new System.Drawing.Size(602, 403);
            this.log_box.TabIndex = 4;
            this.log_box.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 217);
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
            this.spec_box.Location = new System.Drawing.Point(14, 302);
            this.spec_box.Name = "spec_box";
            this.spec_box.Size = new System.Drawing.Size(375, 91);
            this.spec_box.TabIndex = 7;
            this.spec_box.Text = resources.GetString("spec_box.Text");
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Black;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.key,
            this.value});
            this.listView1.ForeColor = System.Drawing.Color.Lime;
            this.listView1.FullRowSelect = true;
            this.listView1.LabelEdit = true;
            this.listView1.Location = new System.Drawing.Point(395, 29);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(602, 150);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // key
            // 
            this.key.Text = "key";
            this.key.Width = 318;
            // 
            // value
            // 
            this.value.Text = "value";
            this.value.Width = 268;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(910, 185);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 29);
            this.button2.TabIndex = 9;
            this.button2.Text = "open";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(395, 185);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 29);
            this.button3.TabIndex = 10;
            this.button3.Text = "add new";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(817, 185);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 29);
            this.button4.TabIndex = 11;
            this.button4.Text = "save";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "params";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 652);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView1);
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader key;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
    }
}

