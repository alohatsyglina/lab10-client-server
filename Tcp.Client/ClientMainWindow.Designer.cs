namespace SomeProject.TcpClient
{
    partial class ClientMainWindow
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
            this.components = new System.ComponentModel.Container();
            this.sendMsgBtn = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.labelRes = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.sendFileBtn = new System.Windows.Forms.Button();
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.chooseFileBtn = new System.Windows.Forms.Button();
            this.serverResponseLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sendMsgBtn
            // 
            this.sendMsgBtn.Location = new System.Drawing.Point(197, 172);
            this.sendMsgBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sendMsgBtn.Name = "sendMsgBtn";
            this.sendMsgBtn.Size = new System.Drawing.Size(110, 19);
            this.sendMsgBtn.TabIndex = 0;
            this.sendMsgBtn.Text = "Send Message";
            this.sendMsgBtn.UseVisualStyleBackColor = true;
            this.sendMsgBtn.Click += new System.EventHandler(this.OnMsgBtnClick);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(28, 10);
            this.textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(281, 158);
            this.textBox.TabIndex = 1;
            // 
            // labelRes
            // 
            this.labelRes.AutoSize = true;
            this.labelRes.Location = new System.Drawing.Point(28, 172);
            this.labelRes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRes.Name = "labelRes";
            this.labelRes.Size = new System.Drawing.Size(0, 13);
            this.labelRes.TabIndex = 2;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // sendFileBtn
            // 
            this.sendFileBtn.Location = new System.Drawing.Point(197, 222);
            this.sendFileBtn.Margin = new System.Windows.Forms.Padding(2);
            this.sendFileBtn.Name = "sendFileBtn";
            this.sendFileBtn.Size = new System.Drawing.Size(110, 19);
            this.sendFileBtn.TabIndex = 3;
            this.sendFileBtn.Text = "Send File";
            this.sendFileBtn.UseVisualStyleBackColor = true;
            this.sendFileBtn.Click += new System.EventHandler(this.SendFileBtn_Click);
            // 
            // fileNameBox
            // 
            this.fileNameBox.Location = new System.Drawing.Point(31, 196);
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.Size = new System.Drawing.Size(276, 20);
            this.fileNameBox.TabIndex = 4;
            // 
            // chooseFileBtn
            // 
            this.chooseFileBtn.Location = new System.Drawing.Point(31, 222);
            this.chooseFileBtn.Name = "chooseFileBtn";
            this.chooseFileBtn.Size = new System.Drawing.Size(110, 19);
            this.chooseFileBtn.TabIndex = 5;
            this.chooseFileBtn.Text = "Choose File";
            this.chooseFileBtn.UseVisualStyleBackColor = true;
            this.chooseFileBtn.Click += new System.EventHandler(this.ChooseFileBtn_Click);
            // 
            // serverResponseLabel
            // 
            this.serverResponseLabel.AutoSize = true;
            this.serverResponseLabel.Location = new System.Drawing.Point(28, 248);
            this.serverResponseLabel.Name = "serverResponseLabel";
            this.serverResponseLabel.Size = new System.Drawing.Size(0, 13);
            this.serverResponseLabel.TabIndex = 6;
            // 
            // ClientMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 269);
            this.Controls.Add(this.serverResponseLabel);
            this.Controls.Add(this.chooseFileBtn);
            this.Controls.Add(this.fileNameBox);
            this.Controls.Add(this.sendFileBtn);
            this.Controls.Add(this.labelRes);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.sendMsgBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientMainWindow";
            this.Text = "Client application";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendMsgBtn;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label labelRes;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button sendFileBtn;
        private System.Windows.Forms.TextBox fileNameBox;
        private System.Windows.Forms.Button chooseFileBtn;
        private System.Windows.Forms.Label serverResponseLabel;
    }
}

