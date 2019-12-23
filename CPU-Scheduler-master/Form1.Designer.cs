namespace CPU_Scheduler
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
            this.num = new System.Windows.Forms.TextBox();
            this.btn1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Process = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BurstTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.algrothim = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.Button();
            this.schedule = new System.Windows.Forms.Button();
            this.TimeQauntum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // num
            // 
            this.num.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.num.Location = new System.Drawing.Point(49, 41);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(119, 20);
            this.num.TabIndex = 1;
            this.num.Tag = "";
            this.num.Text = "Write a Number (Ex. 5)";
            this.num.TextChanged += new System.EventHandler(this.num_TextChanged);
            this.num.Leave += new System.EventHandler(this.num_Leave);
            this.num.Enter += new System.EventHandler(this.num_Enter);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(436, 38);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 38);
            this.btn1.TabIndex = 2;
            this.btn1.Text = "Generate Table";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Process,
            this.ArrivalTime,
            this.BurstTime});
            this.dataGridView1.Location = new System.Drawing.Point(49, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(344, 225);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Process
            // 
            this.Process.HeaderText = "Process";
            this.Process.Name = "Process";
            this.Process.ReadOnly = true;
            this.Process.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ArrivalTime
            // 
            this.ArrivalTime.HeaderText = "Arrival Time";
            this.ArrivalTime.Name = "ArrivalTime";
            this.ArrivalTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ArrivalTime.Width = 101;
            // 
            // BurstTime
            // 
            this.BurstTime.HeaderText = "Burst Time";
            this.BurstTime.Name = "BurstTime";
            this.BurstTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Num. of Processes";
            // 
            // algrothim
            // 
            this.algrothim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algrothim.FormattingEnabled = true;
            this.algrothim.Items.AddRange(new object[] {
            "FCFS",
            "SJF (NP)",
            "SJF (P)",
            "Priority (NP)",
            "Priority (P)",
            "Round Robin"});
            this.algrothim.Location = new System.Drawing.Point(197, 40);
            this.algrothim.Name = "algrothim";
            this.algrothim.Size = new System.Drawing.Size(121, 21);
            this.algrothim.TabIndex = 5;
            this.algrothim.SelectedIndexChanged += new System.EventHandler(this.algrothim_SelectedIndexChanged);
            this.algrothim.SelectedValueChanged += new System.EventHandler(this.algrothim_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Scheduling Algorithm";
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(49, 360);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 9;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // schedule
            // 
            this.schedule.Location = new System.Drawing.Point(435, 360);
            this.schedule.Name = "schedule";
            this.schedule.Size = new System.Drawing.Size(75, 40);
            this.schedule.TabIndex = 10;
            this.schedule.Text = "Generate Chart";
            this.schedule.UseVisualStyleBackColor = true;
            this.schedule.Click += new System.EventHandler(this.schedule_Click);
            // 
            // TimeQauntum
            // 
            this.TimeQauntum.Enabled = false;
            this.TimeQauntum.Location = new System.Drawing.Point(340, 41);
            this.TimeQauntum.Name = "TimeQauntum";
            this.TimeQauntum.Size = new System.Drawing.Size(79, 20);
            this.TimeQauntum.TabIndex = 11;
            this.TimeQauntum.TextChanged += new System.EventHandler(this.TimeQauntum_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Time Quantum ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "How to use !";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 414);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TimeQauntum);
            this.Controls.Add(this.schedule);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.algrothim);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.num);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "CPU Scheduler";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox num;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox algrothim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button schedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn Process;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn BurstTime;
        private System.Windows.Forms.TextBox TimeQauntum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;




    }
}

