
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;



namespace ConsoleApplication1
{
    class SendKeysDemo
    {
        const string Path_Directory_Save_Link = "c:/Link";

        [STAThreadAttribute]
        static void Main()
        {
            Clipoard_c asd = new Clipoard_c();


            //Clipboard.Clear();
            //Console.WriteLine("Clipboard clear");

            //if (Directory.Exists(Path_Directory_Save_Link))
            //{
            //    Console.WriteLine("Directory {0} deleted ", Path_Directory_Save_Link);
            //    Directory.Delete(Path_Directory_Save_Link, true);
            //}
            //else
            //{
            //    Console.WriteLine("{0} already deleted.", Path_Directory_Save_Link);

            //}


            int EX = 1;
            //Запускаем notepad  Process process = Process.Start("notepad.exe");
            //Ждем пока приложение закончит инициализацию  process.WaitForInputIdle();
            //Находим окно Notepad'a, необязательно только-что запущенного.
            //Понятно, что если бы нам нужно было именно окно запущенного нами
            //приложения - можно воспользоваться свойством process.MainWindowHandle  
            ////но одна из целей примера -  продемонстрировать использование FindWindow  MozillaUIWindowClass
            while (true)
            {
                try
                {


                Console.WriteLine("In number link copy");
                string NumberLinkCopy = Console.ReadLine();

                if (char.IsDigit(NumberLinkCopy, 0))
                {
                    for (int j = 0; j < Convert.ToInt32(NumberLinkCopy); j++)
                    {
                        if (j == 0)
                        { Thread.Sleep(2000); }

                        // IntPtr hWndNotepad = FindWindow("MozillaUIWindowClass", null);
                        //IntPtr hWndNotepad = FindWindow("MozillaUIWindowClass", null);
                        //Делаем найденное окно активным
                        //SetForegroundWindow(hWndNotepad);
                        //Посылаем строку


                        //Thread.Sleep(500);

                        //нажатие alt+D alt 0x12 0x44
                        //нажатие контр+а 0x11+0x41
                        PressKey(0x12, 0x44);
                        Thread.Sleep(100);
                        //нажатие контр+C 0x11+0x43
                        PressKey(0x11, 0x43);
                        Thread.Sleep(100);
                        asd.setText();
                        //нажатие контр+TAB 0x11+ 0x09
                        PressKey(0x11, 0x09);
                        Thread.Sleep(500);
                    }
                    asd.Save_File(EX.ToString());

                    EX++;
                }
                else
                {
                    Console.WriteLine("Exit enter q or e or й or у", Path_Directory_Save_Link);
                    if (NumberLinkCopy == "у" || NumberLinkCopy == "e" || NumberLinkCopy == "й" || NumberLinkCopy == "q")
                        return ;
                    //Clipboard.Clear();
                    //Console.WriteLine("Clipboard clear");
                    EX = 1;
                    //if (Directory.Exists(Path_Directory_Save_Link))
                    //{
                    //    Console.WriteLine("Directory {0} deleted ", Path_Directory_Save_Link);
                    //    Directory.Delete(Path_Directory_Save_Link, true);
                    //}
                    //else {
                    //    Console.WriteLine("{0} already deleted.", Path_Directory_Save_Link);
 
                    //}
                }
                }
                catch (Exception)
                {
                    MessageBox.Show("eRROR MAIN LOOP");
                }
            }


        }
        static void PressKey(byte keyCode_1, byte keyCode_2)
        {

            //const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            // 0x45
            keybd_event(keyCode_1, 0, 0, 0);
            keybd_event(keyCode_2, 0, 0, 0);
            keybd_event(keyCode_2, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(keyCode_1, 0, KEYEVENTF_KEYUP, 0);


            // keybd_event( keyCode, 0x45, KEYEVENTF_EXTENDEDKEY, 0 );
            //keybd_event( keyCode, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0 );
        }



        [DllImport("User32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        //Экспортируем нужные Win32 функции
        [DllImport("User32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr hWnd);
        [DllImport("User32.dll")]
        public static extern IntPtr GetKeyboardLayout(int idThread);
        [DllImport("User32.dll")]
        public static extern IntPtr LoadKeyboardLayout(string df, int sd);
        [DllImport("User32.dll")]
        public static extern IntPtr ActivateKeyboardLayout(IntPtr hWnd, int ssad);
        [DllImport("User32.dll")]
        public static extern IntPtr SetActiveWindow(IntPtr hWnd);
        [DllImport("User32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        //функция winapi показывает окно
        [DllImport("User32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("User32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hW_nd, int nCmdS_how);
        [DllImport("User32.dll")]
        public static extern IntPtr SetFocus(IntPtr hW_nd);
        [DllImport("User32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        [DllImport("User32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern bool AttachThreadInput(uint idAttach, uint idAttachTo,
           bool fAttach);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowInfo(IntPtr hwnd, ref WINDOWINFO pwi);

        [StructLayout(LayoutKind.Sequential)]
        struct WINDOWINFO
        {
            public uint cbSize;
            public RECT rcWindow;
            public RECT rcClient;
            public uint dwStyle;
            public uint dwExStyle;
            public uint dwWindowStatus;
            public uint cxWindowBorders;
            public uint cyWindowBorders;
            public ushort atomWindowType;
            public ushort wCreatorVersion;

            public WINDOWINFO(Boolean? filler)
                : this()   // Allows automatic initialization of "cbSize" with "new WINDOWINFO(null/true/false)".
            {
                cbSize = (UInt32)(Marshal.SizeOf(typeof(WINDOWINFO)));
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        struct RECT
        {
            public int left, top, right, bottom;
        }

        class Clipoard_c
        {
            List<string> list = new List<string>();
            /// <summary>
            /// Получение строки из буфера
            /// </summary>
            public void setText()
            {
                try
                {
                    IDataObject iData = Clipboard.GetDataObject();

                    // Determines whether the data is in a format you can use.
                    if (iData.GetDataPresent(DataFormats.Text))
                    {
                        //Yes it is, so display it in a text box.
                        list.Add((String)iData.GetData(DataFormats.Text));
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Idata null");
                }
            }
            [STAThreadAttribute]
            public void Save_File(string file_name)
            {
                Clipboard.Clear();
                //Directory.CreateDirectory(Path_Directory_Save_Link);
                //string FILE_NAME = Path_Directory_Save_Link+"/Link" + file_name + ".txt";
                try
                {
                    string first_link = list[0];
                    StringBuilder to_clibpord = new StringBuilder();
                    
                    int i = 0;
                    foreach (string sd in list)
                    {
                        if (first_link == sd && i!=0)
                        { break; }
                        to_clibpord.AppendLine(sd);
                        //Console.WriteLine(sd);
                        i++;
                        //вставить в буфер обмена

                    }
                    Clipboard.SetText(to_clibpord.ToString());
                    Thread.Sleep(100);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error set clipboard");
                }
                list.Clear();

                //if (File.Exists(FILE_NAME))
                //{
                //    Console.WriteLine("{0} already exists.", FILE_NAME);
                //    return;
                //}
                //using (StreamWriter sw = File.CreateText(FILE_NAME))
                //{

                //    foreach (string sd in list)
                //    {
                //        sw.WriteLine(sd);

                //    }
                //    list.Clear();
                //    sw.Close();
                //}
                //Thread.Sleep(100);
                //using (StreamReader sr = new StreamReader(FILE_NAME))
                //{
                //    //вставить в буфер обмена
                //    Clipboard.SetText(sr.ReadToEnd());
                //    sr.Close();
                //}
               
            }
        }
      

    }
}
