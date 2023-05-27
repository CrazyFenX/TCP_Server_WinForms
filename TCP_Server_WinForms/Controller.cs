using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Client_WinForms
{
    //internal class Controller
    //{
    //    // coords of click
    //    float X = 0;
    //    float Y = 0;

    //    // keycode
    //    short c = 0;

    //}

    struct MouseData
    {
        public ushort _x;
        public ushort _y;
        public byte _button;
        public byte _ID;

        public MouseData()
        {
            _ID = 0;
            _x = 0;
            _y = 0;
            _button = 0;
        }
        
        public MouseData(byte ID, ushort x, ushort y, byte button)
        {
            _ID = ID;
            _x = x;
            _y = y;
            _button = button;
        }

        public MouseData(int ID, int x, int y, int button)
        {
            _ID = (byte)ID;
            _x = (ushort)x;
            _y = (ushort)y;
            _button = (byte)button;
        }

        public static byte[] toByteArr(MouseData input)
        {
            byte[] mas = new byte[10];
            mas[0] = input._ID;
            for (int i = 0; i < 4; i++)
            {
                mas[i + 1] = Convert.ToByte(input._x / (ushort)Math.Pow(10, 3 - i) % 10);
                mas[i + 5] = Convert.ToByte(input._y / (ushort)Math.Pow(10, 3 - i) % 10);
            }
            mas[9] = input._button;
            return mas;
        }

        public static MouseData toData(byte[] arr)
        {
            ushort x = 0;
            ushort y = 0;
            byte ID = arr[0];
            byte button = arr[9];
            for (int i = 0; i < 4; i++)
            {
                x += Convert.ToUInt16(arr[i + 1] * (ushort)Math.Pow(10, 3 - i));
                y += Convert.ToUInt16(arr[i + 5] * (ushort)Math.Pow(10, 3 - i));
            }
            return new MouseData(ID, x, y, button);
        }

        public override string ToString()
        {
            var ret = "";
            if (_x != 0 || _y != 0 || _ID != 0 || _button != 0)
                ret = _x + " " + _y + " " + _ID + " " + _button;
            return ret;
        }
    }

    public struct KeyBoardData
    {
        public byte _button;
        public byte _ID;

        public KeyBoardData()
        {
            _button = 0;
            _ID = 0;
        }

        public KeyBoardData(byte ID, byte button)
        {
            _button = button;
            _ID = ID;
        }

        public static byte[] toByteArr(KeyBoardData kb)
        {
            byte[] mas = new byte[10];
            mas[0] = kb._ID;
            mas[1] = kb._button;
            return mas;
        }

        public static KeyBoardData toData(byte[] arr)
        {
            byte ID = arr[0];
            byte button = arr[9];
            return new KeyBoardData(ID, button);
        }

        public override string ToString()
        {
            var ret = "";
            if (_ID != 0 || _button != 0)
                ret = _ID + " " + _button;
            return ret;
        }
    }

    public class MouseController
    {   
        //Координаты на экране:     
        int X;
        int Y;
        Point curPos;

        const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;
        const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        const uint MOUSEEVENTF_MOVE = 0x0001;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        const uint MOUSEEVENTF_XDOWN = 0x0080;
        const uint MOUSEEVENTF_XUP = 0x0100;
        const uint MOUSEEVENTF_WHEEL = 0x0800;
        const uint MOUSEEVENTF_HWHEEL = 0x01000;

        public MouseController()
        {
        }
        
        public MouseController(int _x, int _y)
        {
            X = _x;
            Y = _y;
            curPos = Cursor.Position;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, int dwData,int dwExtraInfo);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        public void LeftClick()
        {
            //Выполнение первого клика левой клавишей мыши
            //mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, curPos.X >= X ? -Math.Abs(curPos.X - X) : Math.Abs(curPos.X - X), curPos.Y >= Y ? -Math.Abs(curPos.Y - Y) : Math.Abs(curPos.Y - Y), 0, 0);
            //curPos = new Point(X, Y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public void MiddleClick()
        {
            //Выполнение первого клика левой клавишей мыши
            //mouse_event(MOUSEEVENTF_MIDDLEDOWN | MOUSEEVENTF_MIDDLEUP, curPos.X >= X ? -Math.Abs(curPos.X - X) : Math.Abs(curPos.X - X), curPos.Y >= Y ? -Math.Abs(curPos.Y - Y) : Math.Abs(curPos.Y - Y), 0, 0);
            //curPos = new Point(X, Y);
            mouse_event(MOUSEEVENTF_MIDDLEDOWN | MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
        }

        public void RightClick()
        {
            //Выполнение первого клика левой клавишей мыши
            //mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, curPos.X >= X ? -Math.Abs(curPos.X - X) : Math.Abs(curPos.X - X), curPos.Y >= Y ? -Math.Abs(curPos.Y - Y) : Math.Abs(curPos.Y - Y), 0, 0);
            //curPos = new Point(X, Y);
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
        }

        public void Move()
        {
            //Перемещение курсора на указанные координаты
            //mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, curPos.X >= X ? - Math.Abs(curPos.X - X) : Math.Abs(curPos.X - X), curPos.Y >= Y ? -Math.Abs(curPos.Y - Y) : Math.Abs(curPos.Y - Y), 0, 0);
            //curPos = new Point(X, Y);
            SetCursorPos(X, Y);
            //Console.WriteLine();
        }
    }
}
