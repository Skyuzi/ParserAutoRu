namespace AutoRuParser
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDilers = new System.Windows.Forms.CheckBox();
            this.cbUsed = new System.Windows.Forms.CheckBox();
            this.cbNew = new System.Windows.Forms.CheckBox();
            this.cbAll = new System.Windows.Forms.CheckBox();
            this.cbCredit = new System.Windows.Forms.CheckBox();
            this.cbHistory = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbDilers);
            this.groupBox1.Controls.Add(this.cbUsed);
            this.groupBox1.Controls.Add(this.cbNew);
            this.groupBox1.Controls.Add(this.cbAll);
            this.groupBox1.Controls.Add(this.cbCredit);
            this.groupBox1.Controls.Add(this.cbHistory);
            this.groupBox1.Location = new System.Drawing.Point(4, 445);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтры";
            // 
            // cbDilers
            // 
            this.cbDilers.AutoSize = true;
            this.cbDilers.Enabled = false;
            this.cbDilers.Location = new System.Drawing.Point(108, 67);
            this.cbDilers.Name = "cbDilers";
            this.cbDilers.Size = new System.Drawing.Size(68, 17);
            this.cbDilers.TabIndex = 5;
            this.cbDilers.Text = "Дилеры";
            this.cbDilers.UseVisualStyleBackColor = true;
            // 
            // cbUsed
            // 
            this.cbUsed.AutoSize = true;
            this.cbUsed.Location = new System.Drawing.Point(6, 67);
            this.cbUsed.Name = "cbUsed";
            this.cbUsed.Size = new System.Drawing.Size(89, 17);
            this.cbUsed.TabIndex = 4;
            this.cbUsed.Text = "С пробегом";
            this.cbUsed.UseVisualStyleBackColor = true;
            this.cbUsed.CheckedChanged += new System.EventHandler(this.CbUsed_CheckedChanged);
            // 
            // cbNew
            // 
            this.cbNew.AutoSize = true;
            this.cbNew.Location = new System.Drawing.Point(6, 44);
            this.cbNew.Name = "cbNew";
            this.cbNew.Size = new System.Drawing.Size(61, 17);
            this.cbNew.TabIndex = 3;
            this.cbNew.Text = "Новые";
            this.cbNew.UseVisualStyleBackColor = true;
            this.cbNew.CheckedChanged += new System.EventHandler(this.CbNew_CheckedChanged);
            // 
            // cbAll
            // 
            this.cbAll.AutoSize = true;
            this.cbAll.Location = new System.Drawing.Point(6, 21);
            this.cbAll.Name = "cbAll";
            this.cbAll.Size = new System.Drawing.Size(43, 17);
            this.cbAll.TabIndex = 2;
            this.cbAll.Text = "Все";
            this.cbAll.UseVisualStyleBackColor = true;
            this.cbAll.CheckedChanged += new System.EventHandler(this.CbAll_CheckedChanged);
            // 
            // cbCredit
            // 
            this.cbCredit.AutoSize = true;
            this.cbCredit.Enabled = false;
            this.cbCredit.Location = new System.Drawing.Point(108, 44);
            this.cbCredit.Name = "cbCredit";
            this.cbCredit.Size = new System.Drawing.Size(73, 17);
            this.cbCredit.TabIndex = 1;
            this.cbCredit.Text = "В кредит";
            this.cbCredit.UseVisualStyleBackColor = true;
            // 
            // cbHistory
            // 
            this.cbHistory.AutoSize = true;
            this.cbHistory.Enabled = false;
            this.cbHistory.Location = new System.Drawing.Point(108, 21);
            this.cbHistory.Name = "cbHistory";
            this.cbHistory.Size = new System.Drawing.Size(88, 17);
            this.cbHistory.TabIndex = 0;
            this.cbHistory.Text = "С историей";
            this.cbHistory.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtbLog);
            this.groupBox2.Location = new System.Drawing.Point(4, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 441);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Лог";
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(6, 15);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(772, 420);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClearLog);
            this.groupBox3.Controls.Add(this.btnStop);
            this.groupBox3.Controls.Add(this.btnStart);
            this.groupBox3.Location = new System.Drawing.Point(221, 445);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(567, 94);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Меню";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(401, 17);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(160, 65);
            this.btnClearLog.TabIndex = 2;
            this.btnClearLog.Text = "Очистить лог";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.BtnClearLog_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(6, 53);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(389, 30);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Стоп";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 18);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(389, 30);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 540);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Form1";
            this.Text = "Парсер для Auto.ru";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbDilers;
        private System.Windows.Forms.CheckBox cbUsed;
        private System.Windows.Forms.CheckBox cbNew;
        private System.Windows.Forms.CheckBox cbAll;
        private System.Windows.Forms.CheckBox cbCredit;
        private System.Windows.Forms.CheckBox cbHistory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
    }
}

