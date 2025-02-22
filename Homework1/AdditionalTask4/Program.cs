using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    const uint WM_SETTEXT = 0x000C;

    static void Main(string[] args)
    {
        while (true)
        {
            Process[] processes = Process.GetProcessesByName("notepad");

            if (processes.Length > 0)
            {
                Process notepadProcess = processes[0];
                IntPtr hwnd = notepadProcess.MainWindowHandle;

                if (hwnd != IntPtr.Zero)
                {
                    string currentTime = DateTime.Now.ToString("HH:mm:ss");
                    IntPtr lParam = Marshal.StringToHGlobalAuto(currentTime);
                    SendMessage(hwnd, WM_SETTEXT, IntPtr.Zero, lParam);
                    Marshal.FreeHGlobal(lParam);

                    Console.WriteLine("Заголовок обновлен с текущим временем: " + currentTime);
                }
                else
                {
                    Console.WriteLine("Не удалось получить дескриптор окна Блокнота");
                }
            }
            else
            {
                Console.WriteLine("Не удалось найти процесс Блокнота");
            }

            Thread.Sleep(1000);
        }
    }
}
