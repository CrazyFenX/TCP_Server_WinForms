using TCP_Client_Server;

namespace TCP_Server_WinForms
{
    public partial class Form1 : Form
    {
        Server tcpServer;

        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var IP = textBoxIp.Text;
            var Port = Convert.ToInt32(textBoxPort.Text);
            try
            {
                tcpServer = new Server(IP, Port, StateTextBox);
                StateTextBox.Text = "Server is ON";
            }
            catch(Exception ex)
            {
                Server.WriteInLog(ex.Message, StateTextBox);
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            var messageText = textBoxMessage.Text;
            try
            {
                tcpServer.SendAsyncTCP();
            }
            catch(Exception ex)
            {
                Server.WriteInLog(ex.Message, StateTextBox);
            }
        }
    }
}