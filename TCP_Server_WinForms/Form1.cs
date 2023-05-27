using TCP_Client_Server;

namespace TCP_Server_WinForms
{
    public partial class Form1 : Form
    {
        Server tcpServer;
        ServerUDP udpServer;

        bool IsStreamingOn = false;

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
                tcpServer = new Server(IP, Port, StateTextBox, Server.ProtocolType.TCP);
                Server.WriteInLog("TCP Server is ON", StateTextBox);

            }
            catch(Exception ex)
            {
                Server.WriteInLog(ex.Message, StateTextBox);
            }
        }

        private void startUDPButton_Click(object sender, EventArgs e)
        {
            var IP = textBoxIp.Text;
            var Port = Convert.ToInt32(textBoxPort.Text);
            try
            {
                udpServer = new ServerUDP(IP, Port, StateTextBox);
                Server.WriteInLog("UPD Server is ON", StateTextBox);

            }
            catch (Exception ex)
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

        private void StartStreamButton_Click(object sender, EventArgs e)
        {
            IsStreamingOn = true;

            try
            {
                while(IsStreamingOn)
                    tcpServer.SendScreenAsyncTCP();
            }
            catch (Exception ex)
            {
                Server.WriteInLog(ex.Message, StateTextBox);
            }
        }

        private void StopStreamButton_Click(object sender, EventArgs e)
        {
            IsStreamingOn = false;
        }

        private void StartStreamButtonUDP_Click(object sender, EventArgs e)
        {
            IsStreamingOn = true;

            try
            {
                while (IsStreamingOn)
                    udpServer.SendScreenAsyncUDP();
            }
            catch (Exception ex)
            {
                Server.WriteInLog(ex.Message, StateTextBox);
            }

        }

        private void StopStreamButtonUDP_Click(object sender, EventArgs e)
        {
            IsStreamingOn = false;
        }

        private void SendUDPButton_Click(object sender, EventArgs e)
        {
            if (udpServer == null)
            {
                Server.WriteInLog("UDP Сурвер не подключен", StateTextBox);
                return;
            }
            udpServer.SendAsyncUDP();
        }
    }
}