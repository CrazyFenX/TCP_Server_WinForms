using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Client_Server
{
    public class Server
    {
        //int port = 8888;
        //string hostname = "192.168.1.74";
        //string hostname = "192.168.0.14";

        //Socket socket;

        bool live = false;
        string errorString = "Нет ошибок";
        int errorCode = 0;
        public TextBox textBoxState;

        Socket tcpClient;

        public Server(string hostname, int port, TextBox _textBoxState)
        {
            //IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(hostname), port);
            //socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //socket.Bind(ipPoint);   // связываем с локальной точкой ipPoint

            textBoxState = _textBoxState; // Если null, все к херам развалится :)))

            IPAddress localAddr = IPAddress.Parse(hostname);
            IPEndPoint ipLocalEndPoint = new IPEndPoint(localAddr, port);
            TcpListener server = new TcpListener(ipLocalEndPoint);
            server.Start();  // Запускаем сервер

            Listening(server);  // Слушаем

            //while (live)
            //{

            //}
        }

        private async void Listening(TcpListener server)
        {
            //socket.Listen(1000);

            WriteInLog("Сервер запущен. Ожидание подключений...");
            live = true;

            // получаем входящее подключение
            tcpClient = await server.Server.AcceptAsync();

            // получаем подключение в виде TcpClient
            //using var tcpClient = await server.AcceptTcpClientAsync();

            // получаем входящее подключение
            //using var tcpClient1 = await server.AcceptAsync();

            // Получаем адрес клиента
            WriteInLog($"Адрес подключенного клиента: {tcpClient.RemoteEndPoint}");

            // Ждем сообщения
            ReceiveAsyncTCP(tcpClient);

        }

        //private async void ReadingClientStream(Socket clientSocket)
        //{
        //    // буфер для получения данных
        //    var responseData = new byte[512];

        //    using var stream = new NetworkStream(clientSocket);

        //    // получаем данные
        //    var bytes = await stream.ReadAsync(responseData);
        //    // преобразуем полученные данные в строку
        //    string response = Encoding.UTF8.GetString(responseData, 0, bytes);
        //    // выводим данные на консоль
        //    WriteInLog(response);
        //}

        /// <summary>
        /// Отправить сообщение
        /// </summary>
        public async void SendAsyncTCP()
        {
            if (tcpClient == null)
            {
                WriteInLog("Клиент не доступен!");
                return;
            }

            // определяем данные для отправки - текущее время
            //byte[] data = Encoding.UTF8.GetBytes(DateTime.Now.ToLongTimeString());

            FileStream stream = new FileStream("C:\\Users\\User\\source\\repos\\TCP_Server_WinForms\\TCP_Server_WinForms\\media\\important-file.png", FileMode.Open, FileAccess.Read);
            var image = Image.FromStream(stream);
            stream.Close();

            byte[] data = ImageToByteArray(image);

            // отправляем данные
            await tcpClient.SendAsync(data, SocketFlags.None);

            WriteInLog("Сообщение отправлено");
        }

        /// <summary>
        /// Принять сообщение
        /// </summary>
        /// <param name="socket"></param>
        private async void ReceiveAsyncTCP(Socket socket)
        {
            byte[] data = new byte[512];

            // получаем данные из потока
            int bytes = await socket.ReceiveAsync(data, SocketFlags.None);
            // получаем отправленное время
            string time = Encoding.UTF8.GetString(data, 0, bytes);
            WriteInLog($"Текущее время: {time}");
        }

        #region Service Methods

        public void WriteInLog(string message)
        {
            if (textBoxState != null)
                textBoxState.Text += "\r\n" + message;
        }

        public static void WriteInLog(string message, TextBox _textBoxState)
        {
            if (_textBoxState != null)
                _textBoxState.Text += "\r\n" + message;
        }
        static byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        #endregion

    }
}
