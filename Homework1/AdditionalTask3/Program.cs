using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    const uint WM_CLOSE = 0x0010;

    static void Main(string[] args)
    {
        Process[] processes = Process.GetProcessesByName("notepad");

        if (processes.Length > 0)
        {
            Process notepadProcess = processes[0];
            IntPtr hwnd = notepadProcess.MainWindowHandle;

            if (hwnd != IntPtr.Zero)
            {
                SendMessage(hwnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                Console.WriteLine("Закрытие окна Блокнота");
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
    }
}
