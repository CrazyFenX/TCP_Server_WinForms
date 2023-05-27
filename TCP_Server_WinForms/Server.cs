using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Client_Server
{
    public class Server
    {
        static int width = 1920;
        static int height = 1080;

        bool live = false;
        string errorString = "Нет ошибок";
        int errorCode = 0;
        public TextBox textBoxState;

        Socket tcpClient;
        Socket udpClient;

        IPEndPoint LocalIp;
        IPEndPoint RemoteIp;

        static Bitmap BackGround = new Bitmap(width, height);
        Graphics graphics = Graphics.FromImage(BackGround);

        public Server(string hostname, int port, TextBox _textBoxState, ProtocolType protocolType)
        {
            textBoxState = _textBoxState; // Если null, все к херам развалится :)))

            IPAddress LocalAddr = IPAddress.Parse(hostname);
            LocalIp = new IPEndPoint(LocalAddr, port);
            
            if (protocolType == ProtocolType.TCP)
            {
                TcpListener server = new TcpListener(LocalIp);
                server.Start();  // Запускаем сервер

                Listening(server);  // Слушаем
            }
            else if (protocolType == ProtocolType.UDP)
            {

                udpClient = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp);
                SendAsyncUDP();
            }

        }
        
        /// <summary>
        /// Ожидание подключений
        /// </summary>
        /// <param name="server"></param>
        private async void Listening(TcpListener server)
        {
            WriteInLog("Сервер запущен. Ожидание подключений...");
            live = true;

            // получаем входящее подключение
            tcpClient = await server.Server.AcceptAsync();

            // Получаем адрес клиента
            WriteInLog($"Адрес подключенного клиента: {tcpClient.RemoteEndPoint}");
        }

        /// <summary>
        /// Отправить картинку (Устаревший)
        /// </summary>
        public async void SendAsyncTCP()
        {
            if (tcpClient == null)
            {
                WriteInLog("Клиент не доступен!");
                return;
            }
            // Получаем снимок экрана
            graphics.CopyFromScreen(0, 0, 0, 0, BackGround.Size);

            // получаем размеры окна рабочего стола
            Rectangle bounds = Screen.GetBounds(Point.Empty);

            // создаем пустое изображения размером с экран устройства
            using (var bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                // создаем объект на котором можно рисовать
                using (var g = Graphics.FromImage(bitmap))
                {
                    // перерисовываем экран на наш графический объект
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }

                var data1 = ImageToByteArray(bitmap);
                await tcpClient.SendAsync(data1, SocketFlags.None);
            }

            WriteInLog("Сообщение отправлено");
        }
        
        /// <summary>
        /// Отправить картинку UDP
        /// </summary>
        public async void SendAsyncUDP()
        {
            int a = 0;
            if (udpClient == null)
            {
                WriteInLog("Клиент не доступен!");
                return;
            }
            // Получаем снимок экрана
            graphics.CopyFromScreen(0, 0, 0, 0, BackGround.Size);

            // получаем размеры окна рабочего стола
            Rectangle bounds = Screen.GetBounds(Point.Empty);

            // создаем пустое изображения размером с экран устройства
            using (var bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                // создаем объект на котором можно рисовать
                using (var g = Graphics.FromImage(bitmap))
                {
                    // перерисовываем экран на наш графический объект
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }

                var data1 = ImageToByteArray(bitmap);
                a = await udpClient.SendToAsync(data1, SocketFlags.None, RemoteIp);
            }

            WriteInLog($"Сообщение отправлено {a}байт");
        }

        /// <summary>
        /// Отправить снимок экрана
        /// </summary>
        public async void SendScreenAsyncTCP()
        {
            // Проверяем, есть ли клиент, чтобы все к херам не развалилось
            if (tcpClient == null)
            {
                WriteInLog("Клиент не доступен!");
                return;
            }
            // Получаем снимок экрана
            graphics.CopyFromScreen(0, 0, 0, 0, BackGround.Size);

            // Получаем размеры окна рабочего стола
            Rectangle bounds = Screen.GetBounds(Point.Empty);

            // Создаем пустое изображения размером с экран устройства
            using (var bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                // Создаем объект на котором можно рисовать
                using (var g = Graphics.FromImage(bitmap))
                {
                    // Перерисовываем экран на наш графический объект
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                // Конвертируем картинку в массив байтов
                var data = ImageToByteArray(bitmap);

                // Асинхронная отправка
                await tcpClient.SendAsync(data, SocketFlags.None);
            }
            WriteInLog("Сообщение отправлено");
        }

        /// <summary>
        /// Принять сообщение (заглушка)
        /// </summary>
        /// <param name="socket"></param>
        private async void ReceiveTCPAsync(Socket socket)
        {
            byte[] data = new byte[512];

            // получаем данные из потока
            int bytes = await socket.ReceiveAsync(data, SocketFlags.None);
            // получаем отправленное время
            string time = Encoding.UTF8.GetString(data, 0, bytes);
            WriteInLog($"Текущее время: {time}");
        }

        #region Service Methods
        
        /// <summary>
        /// Запись в текстбокс лога изнутри 
        /// </summary>
        /// <param name="message"> Сообщение </param>
        private void WriteInLog(string message)
        {
            if (textBoxState != null)
                textBoxState.Text += "\r\n" + message;
        }

        /// <summary>
        /// Запись в текстбокс лога извне
        /// </summary>
        /// <param name="message"> Сообщение </param>
        /// <param name="_textBoxState"> Целевой текстбокс </param>
        public static void WriteInLog(string message, TextBox _textBoxState)
        {
            if (_textBoxState != null)
                _textBoxState.Text += "\r\n" + message;
        }

        /// <summary>
        /// Конвертация изображения в массив битов
        /// </summary>
        /// <param name="imageIn"> Изображение </param>
        /// <returns></returns>
        static byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                // 5 строчек магии (мутим параметры для сохранения потока памяти)
                var myEncoder = System.Drawing.Imaging.Encoder.Quality;
                var myEncoderParameters = new EncoderParameters(1);
                var myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                var myImageCodecInfo = GetEncoderInfo("image/jpeg");

                // Сохраняем поток памяти
                imageIn.Save(ms, myImageCodecInfo, myEncoderParameters);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Получить encoder
        /// Вспомогательный метод для конвертации
        /// </summary>
        /// <param name="mimeType"> Какое-то говно </param>
        /// <returns> Кодек инфо </returns>
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        #endregion Service Methods

        public enum ProtocolType
        {
            TCP  = 1,
            UDP = 2,
        }
    }
}
