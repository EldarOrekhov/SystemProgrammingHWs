using System;
using System.Runtime.InteropServices;

namespace ConsoleApp2;

class Program
{
    [DllImport("user32.dll", SetLastError = true)]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

    static void Main()
    {
        bool playing = true;

        while (playing)
        {
            MessageBox(IntPtr.Zero, "Загадайте число от 0 до 100", "Начало игры", 0);

            int low = 0;
            int high = 100;
            int guess = 50;
            bool guessed = false;

            while (!guessed)
            {
                guess = (low + high) / 2;

                string message = $"Ваше число: {guess}? Введите: 1 - если больше, 2 - если меньше, 0 - если число отгадано";
                MessageBox(IntPtr.Zero, message, "Возможное число", 0);

                Console.WriteLine("Ваш ответ:");
                string response = Console.ReadLine().Trim();

                switch (response) 
                {
                    case "0":
                        guessed = true;
                        MessageBox(IntPtr.Zero, $"число: {guess} отгадано", "Победа", 0);
                        break;
                    case "1":
                        low = guess + 1;
                        break;
                    case "2":
                        high = guess - 1;
                        break;
                    default:
                        MessageBox(IntPtr.Zero, "Неверный ввод, доступно для ввода: 1,2,0", "Ошибка", 0);
                        break;
                }
            }

            Console.WriteLine("Введите 1 - для продолжения игры, 0 - для выхода");
            string playAgainResponse = Console.ReadLine().Trim();

            if (playAgainResponse != "1")
            {
                playing = false;
                MessageBox(IntPtr.Zero, "Завершение игры", "Конец", 0);
            }
        }
    }
}
