using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TCP_Client_WinForms;

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

        public Server(string hostname, int port, TextBox _textBoxState)
        {
            textBoxState = _textBoxState; // Если null, все к херам развалится :)))

            IPAddress LocalAddr = IPAddress.Parse(hostname);
            LocalIp = new IPEndPoint(LocalAddr, port);
            
            TcpListener server = new TcpListener(LocalIp);
            server.Start();  // Запускаем сервер

            Listening(server);  // Ждем подключений
            
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

            // Получить публичный ключ клиента
            // Отправить свой публичный ключ
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
        /// Принять сообщение
        /// </summary>
        /// <param name="socket"></param>
        public async void ReceiveTCPAsync()
        {
            if (tcpClient == null)
            {
                //WriteInLog("Клиент не пдключен!");
                return;
            }
            byte[] data = new byte[50];
            MouseData mouseInput = new MouseData();
            KeyBoardData kbInput = new KeyBoardData();

            var mouseController = new MouseController();

            // получаем данные из потока
            int bytes = await tcpClient.ReceiveAsync(data, SocketFlags.None);
            if (data.Any())
            {
                switch (data[0])
                {
                    //Mouse input
                    case 0:
                        mouseInput = MouseData.toData(data);
                    break;

                    //KeyBoard input
                    case 1:
                        kbInput = KeyBoardData.toData(data);
                    break;
                }
            }
            //var text = $"Получен инпут: {mouseInput.ToString() + " " + kbInput.ToString()}";
            if (mouseInput._x != 0 || mouseInput._y != 0)
            {
                mouseController = new MouseController(mouseInput._x, mouseInput._y);
                if (mouseInput._button == 0)
                    mouseController.Move();
                else if (mouseInput._button == 1 && mouseInput._UpOrDown == 1)
                    mouseController.LeftClickDown();
                else if (mouseInput._button == 1 && mouseInput._UpOrDown == 2)
                    mouseController.LeftClickUp();
                else if (mouseInput._button == 2 && mouseInput._UpOrDown == 1)
                    mouseController.MiddleClickDown();
                else if (mouseInput._button == 2 && mouseInput._UpOrDown == 2)
                    mouseController.MiddleClickUp();
                else if (mouseInput._button == 3 && mouseInput._UpOrDown == 1)
                    mouseController.RightClickDown();
                else if (mouseInput._button == 3 && mouseInput._UpOrDown == 2)
                    mouseController.RightClickUp();
            }

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
