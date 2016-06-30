namespace WindowsFormsApplication3
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.stopMS = new System.Windows.Forms.Button();
            this.startMS = new System.Windows.Forms.Button();
            this.startFS = new System.Windows.Forms.Button();
            this.stopFS = new System.Windows.Forms.Button();
            this.messageBOX = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // stopMS
            // 
            this.stopMS.Location = new System.Drawing.Point(130, 12);
            this.stopMS.Name = "stopMS";
            this.stopMS.Size = new System.Drawing.Size(106, 35);
            this.stopMS.TabIndex = 0;
            this.stopMS.Text = "Закончить прием сообщений";
            this.stopMS.UseVisualStyleBackColor = true;
            this.stopMS.Visible = false;
            this.stopMS.Click += new System.EventHandler(this.stopMS_Click);
            // 
            // startMS
            // 
            this.startMS.Location = new System.Drawing.Point(32, 12);
            this.startMS.Name = "startMS";
            this.startMS.Size = new System.Drawing.Size(92, 35);
            this.startMS.TabIndex = 1;
            this.startMS.Text = "Начать прием сообщений";
            this.startMS.UseVisualStyleBackColor = true;
            this.startMS.Click += new System.EventHandler(this.startMS_Click);
            // 
            // startFS
            // 
            this.startFS.Location = new System.Drawing.Point(32, 194);
            this.startFS.Name = "startFS";
            this.startFS.Size = new System.Drawing.Size(92, 34);
            this.startFS.TabIndex = 2;
            this.startFS.Text = "Начать прием файлов";
            this.startFS.UseVisualStyleBackColor = true;
            this.startFS.Click += new System.EventHandler(this.startFS_Click);
            // 
            // stopFS
            // 
            this.stopFS.Location = new System.Drawing.Point(144, 194);
            this.stopFS.Name = "stopFS";
            this.stopFS.Size = new System.Drawing.Size(92, 34);
            this.stopFS.TabIndex = 3;
            this.stopFS.Text = "Закончить прием файлов";
            this.stopFS.UseVisualStyleBackColor = true;
            this.stopFS.Visible = false;
            this.stopFS.Click += new System.EventHandler(this.stopFS_Click);
            // 
            // messageBOX
            // 
            this.messageBOX.Location = new System.Drawing.Point(32, 92);
            this.messageBOX.Multiline = true;
            this.messageBOX.Name = "messageBOX";
            this.messageBOX.Size = new System.Drawing.Size(204, 81);
            this.messageBOX.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(32, 248);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(204, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Входящее сообщение:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 287);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.messageBOX);
            this.Controls.Add(this.stopFS);
            this.Controls.Add(this.startFS);
            this.Controls.Add(this.startMS);
            this.Controls.Add(this.stopMS);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button stopMS;
        private System.Windows.Forms.Button startMS;
        private System.Windows.Forms.Button startFS;
        private System.Windows.Forms.Button stopFS;
        private System.Windows.Forms.TextBox messageBOX;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
    }
}

