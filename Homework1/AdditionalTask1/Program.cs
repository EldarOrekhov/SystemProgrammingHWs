using System;
using System.Diagnostics;

namespace ConsoleApp2;

class Program
{ 
    static void Main()
    {
        Console.WriteLine("Выберите приложение для запуска:\n" +
                            "1 - Блокнот\n" +
                            "2 - Калькулятор\n" +
                            "3 - Paint\n" +
                            "4 - Запустить chrome\n" +
                            "0 - Выход\n");

        Console.Write("Введите номер вашего выбора: ");
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Process.Start("notepad.exe");
                break;
            case "2":
                Process.Start("calc.exe");
                break;
            case "3":
                Process.Start("mspaint.exe");
                break;
            case "4":
                Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe");
                break;
            case "0":
                break;
            default:
                Console.WriteLine("Неверный ввод");
                break;
        }
    }
}
