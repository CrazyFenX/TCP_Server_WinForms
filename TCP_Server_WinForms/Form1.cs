using TCP_Client_Server;

namespace TCP_Server_WinForms
{
    public partial class Form1 : Form
    {
        Server tcpServer;
        ServerUDP udpServer;

        Thread threadTCP;
        Thread threadUDP;

        bool IsStreamingOn = false;

        public Form1()
        {
            InitializeComponent();
            threadTCP = new Thread(new ThreadStart(StreamStartTCP));
            threadUDP = new Thread(new ThreadStart(StreamStartUDP));
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var IP = textBoxIp.Text;
            var Port = Convert.ToInt32(textBoxPort.Text);
            try
            {
                tcpServer = new Server(IP, Port, StateTextBox);
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
            threadTCP.Start();
            //IsStreamingOn = true;

            //try
            //{
            //    while (IsStreamingOn)
            //        //tcpServer.SendScreenAsyncTCP();
            //        tcpServer.ReceiveTCPAsync();
            //}
            //catch (Exception ex)
            //{
            //    Server.WriteInLog(ex.Message, StateTextBox);
            //}
        }

        private void StopStreamButton_Click(object sender, EventArgs e)
        {
            IsStreamingOn = false;
        }

        private void StartStreamButtonUDP_Click(object sender, EventArgs e)
        {
            threadUDP.Start();
        }

        private void StopStreamButtonUDP_Click(object sender, EventArgs e)
        {
            IsStreamingOn = false;
        }

        private void SendUDPButton_Click(object sender, EventArgs e)
        {
            if (udpServer == null)
            {
                Server.WriteInLog("UDP Сервер не подключен", StateTextBox);
                return;
            }
            udpServer.SendAsyncUDP();
        }

        public void StreamStartTCP()
        {
            IsStreamingOn = true;
            
            try
            {
                while (IsStreamingOn)
                    tcpServer.ReceiveTCPAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                //Server.WriteInLog(ex.Message, StateTextBox);
            }
        }

        public void StreamStartUDP()
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

        private void StateTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxIp_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxMessage_TextChanged(object sender, EventArgs e)
        {

        }
    }
}