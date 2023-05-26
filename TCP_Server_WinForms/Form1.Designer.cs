namespace TCP_Server_WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartButton = new System.Windows.Forms.Button();
            this.textBoxIp = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.StateTextBox = new System.Windows.Forms.TextBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.StartStreamButton = new System.Windows.Forms.Button();
            this.StopStreamButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(128, 12);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // textBoxIp
            // 
            this.textBoxIp.Location = new System.Drawing.Point(12, 12);
            this.textBoxIp.Name = "textBoxIp";
            this.textBoxIp.Size = new System.Drawing.Size(100, 23);
            this.textBoxIp.TabIndex = 1;
            this.textBoxIp.Text = "100.124.160.151";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(12, 50);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(100, 23);
            this.textBoxPort.TabIndex = 2;
            this.textBoxPort.Text = "8888";
            // 
            // StateTextBox
            // 
            this.StateTextBox.Location = new System.Drawing.Point(12, 341);
            this.StateTextBox.Multiline = true;
            this.StateTextBox.Name = "StateTextBox";
            this.StateTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StateTextBox.Size = new System.Drawing.Size(648, 97);
            this.StateTextBox.TabIndex = 3;
            this.StateTextBox.Text = "State";
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(12, 132);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(100, 23);
            this.textBoxMessage.TabIndex = 4;
            this.textBoxMessage.Text = "Text";
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(128, 131);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(107, 23);
            this.SendButton.TabIndex = 5;
            this.SendButton.Text = "SendButton";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // StartStreamButton
            // 
            this.StartStreamButton.Location = new System.Drawing.Point(128, 160);
            this.StartStreamButton.Name = "StartStreamButton";
            this.StartStreamButton.Size = new System.Drawing.Size(107, 23);
            this.StartStreamButton.TabIndex = 6;
            this.StartStreamButton.Text = "Start streaming";
            this.StartStreamButton.UseVisualStyleBackColor = true;
            this.StartStreamButton.Click += new System.EventHandler(this.StartStreamButton_Click);
            // 
            // StopStreamButton
            // 
            this.StopStreamButton.Location = new System.Drawing.Point(128, 189);
            this.StopStreamButton.Name = "StopStreamButton";
            this.StopStreamButton.Size = new System.Drawing.Size(107, 23);
            this.StopStreamButton.TabIndex = 7;
            this.StopStreamButton.Text = "Stop streaming";
            this.StopStreamButton.UseVisualStyleBackColor = true;
            this.StopStreamButton.Click += new System.EventHandler(this.StopStreamButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StopStreamButton);
            this.Controls.Add(this.StartStreamButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.StateTextBox);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxIp);
            this.Controls.Add(this.StartButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button StartButton;
        private TextBox textBoxIp;
        private TextBox textBoxPort;
        private TextBox StateTextBox;
        private TextBox textBoxMessage;
        private Button SendButton;
        private Button StartStreamButton;
        private Button StopStreamButton;
    }
}