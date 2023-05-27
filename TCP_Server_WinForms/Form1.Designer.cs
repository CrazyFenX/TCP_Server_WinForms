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
            this.StartStreamButtonTCP = new System.Windows.Forms.Button();
            this.StopStreamButtonTCP = new System.Windows.Forms.Button();
            this.StopStreamButtonUDP = new System.Windows.Forms.Button();
            this.StartStreamButtonUDP = new System.Windows.Forms.Button();
            this.startUDPButton = new System.Windows.Forms.Button();
            this.SendUDPButton = new System.Windows.Forms.Button();
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
            // StartStreamButtonTCP
            // 
            this.StartStreamButtonTCP.Location = new System.Drawing.Point(128, 160);
            this.StartStreamButtonTCP.Name = "StartStreamButtonTCP";
            this.StartStreamButtonTCP.Size = new System.Drawing.Size(133, 23);
            this.StartStreamButtonTCP.TabIndex = 6;
            this.StartStreamButtonTCP.Text = "Start streaming TCP";
            this.StartStreamButtonTCP.UseVisualStyleBackColor = true;
            this.StartStreamButtonTCP.Click += new System.EventHandler(this.StartStreamButton_Click);
            // 
            // StopStreamButtonTCP
            // 
            this.StopStreamButtonTCP.Location = new System.Drawing.Point(128, 189);
            this.StopStreamButtonTCP.Name = "StopStreamButtonTCP";
            this.StopStreamButtonTCP.Size = new System.Drawing.Size(133, 23);
            this.StopStreamButtonTCP.TabIndex = 7;
            this.StopStreamButtonTCP.Text = "Stop streaming TCP";
            this.StopStreamButtonTCP.UseVisualStyleBackColor = true;
            this.StopStreamButtonTCP.Click += new System.EventHandler(this.StopStreamButton_Click);
            // 
            // StopStreamButtonUDP
            // 
            this.StopStreamButtonUDP.Location = new System.Drawing.Point(293, 189);
            this.StopStreamButtonUDP.Name = "StopStreamButtonUDP";
            this.StopStreamButtonUDP.Size = new System.Drawing.Size(133, 23);
            this.StopStreamButtonUDP.TabIndex = 9;
            this.StopStreamButtonUDP.Text = "Stop streaming UDP";
            this.StopStreamButtonUDP.UseVisualStyleBackColor = true;
            this.StopStreamButtonUDP.Click += new System.EventHandler(this.StopStreamButtonUDP_Click);
            // 
            // StartStreamButtonUDP
            // 
            this.StartStreamButtonUDP.Location = new System.Drawing.Point(293, 160);
            this.StartStreamButtonUDP.Name = "StartStreamButtonUDP";
            this.StartStreamButtonUDP.Size = new System.Drawing.Size(133, 23);
            this.StartStreamButtonUDP.TabIndex = 8;
            this.StartStreamButtonUDP.Text = "Start streaming UDP";
            this.StartStreamButtonUDP.UseVisualStyleBackColor = true;
            this.StartStreamButtonUDP.Click += new System.EventHandler(this.StartStreamButtonUDP_Click);
            // 
            // startUDPButton
            // 
            this.startUDPButton.Location = new System.Drawing.Point(273, 11);
            this.startUDPButton.Name = "startUDPButton";
            this.startUDPButton.Size = new System.Drawing.Size(75, 23);
            this.startUDPButton.TabIndex = 10;
            this.startUDPButton.Text = "Start UDP";
            this.startUDPButton.UseVisualStyleBackColor = true;
            this.startUDPButton.Click += new System.EventHandler(this.startUDPButton_Click);
            // 
            // SendUDPButton
            // 
            this.SendUDPButton.Location = new System.Drawing.Point(293, 131);
            this.SendUDPButton.Name = "SendUDPButton";
            this.SendUDPButton.Size = new System.Drawing.Size(107, 23);
            this.SendUDPButton.TabIndex = 11;
            this.SendUDPButton.Text = "SendUDPButton";
            this.SendUDPButton.UseVisualStyleBackColor = true;
            this.SendUDPButton.Click += new System.EventHandler(this.SendUDPButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SendUDPButton);
            this.Controls.Add(this.startUDPButton);
            this.Controls.Add(this.StopStreamButtonUDP);
            this.Controls.Add(this.StartStreamButtonUDP);
            this.Controls.Add(this.StopStreamButtonTCP);
            this.Controls.Add(this.StartStreamButtonTCP);
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
        private Button StartStreamButtonTCP;
        private Button StopStreamButtonTCP;
        private Button StopStreamButtonUDP;
        private Button StartStreamButtonUDP;
        private Button startUDPButton;
        private Button SendUDPButton;
    }
}