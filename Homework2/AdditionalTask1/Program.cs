using System;
using System.Net;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread downloadThread = new Thread(DownloadFile);
        downloadThread.Start();
        Console.WriteLine("Загрузка началась");

        while (true)
        {
            Console.WriteLine("\nНажмите на любую кнопку для получения статуса загрузки\nHажмите на q для выхода из программы");
            var key = Console.ReadKey();
            if (key.KeyChar == 'q')
            {
                if (downloadThread.IsAlive)
                {
                    Console.WriteLine("\nОжидание завершения загрузки");
                    downloadThread.Join();
                }
                break;
            }
            if (downloadThread.IsAlive)
                Console.WriteLine("\nИдет загрузка файла");
            else 
                Console.WriteLine("\nЗагрузка завершена");
        }
    }

    static void DownloadFile()
    {
        string url = "https://link.testfile.org/70MB";
        string fileName = "bigfile.exe";

        using (WebClient client = new WebClient())
        {
            client.DownloadFile(url, fileName);
        }
    }
}
