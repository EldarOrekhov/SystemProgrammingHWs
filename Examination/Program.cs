using System;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Program
{
    private static readonly object logLock = new();
    private static readonly object archiveLock = new();
    private static readonly TimeSpan executionTime = TimeSpan.FromSeconds(20);

    static async Task Main()
    {
        Console.WriteLine("Начало логирования");
        string logsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
        string archivePath = Path.Combine(Directory.GetCurrentDirectory(), "logs_archive.zip");
        string errorLogPath = Path.Combine(Directory.GetCurrentDirectory(), "ErrorLogs.txt");
        Directory.CreateDirectory(logsDirectory);

        Task[] tasks = new Task[5];
        for (int i = 0; i < 5; i++)
        {
            int threadId = i + 1;
            tasks[i] = Task.Run(() => WriteLogsAsync(threadId, logsDirectory));
        }

        Task monitorTask = Task.Run(() => MonitorLogFiles(logsDirectory, archivePath));
        Task analyzeTask = Task.Run(() => AnalyzeLogs(logsDirectory, errorLogPath));

        await Task.Delay(executionTime);

        Console.WriteLine("Логирование остановлено");
        GenerateFinalReport(logsDirectory, errorLogPath, archivePath);
    }

    static async Task WriteLogsAsync(int threadId, string logDirectory)
    {
        string logFile = Path.Combine(logDirectory, $"log_{threadId}.txt");
        Random random = new Random();
        DateTime endTime = DateTime.Now.Add(executionTime);

        int logIndex = 1;
        while (DateTime.Now < endTime)
        {
            string logMessage = GenerateRandomLog(threadId, logIndex++, random);
            lock (logLock)
            {
                File.AppendAllText(logFile, logMessage + Environment.NewLine);
            }
            await Task.Delay(random.Next(500, 1500));
        }
    }

    static string GenerateRandomLog(int threadId, int logIndex, Random random)
    {
        string[] messages = { "Processing data", "Fetching records", "Updating database", "Sending request", "Receiving response" };
        string[] errorTypes = { "Warning", "Exception", "Ошибка" };

        bool isError = random.Next(1, 101) <= 10;
        string logLevel = isError ? errorTypes[random.Next(errorTypes.Length)] : "Info";
        string logMessage = isError ? $"{logLevel}: Issue in thread {threadId}" : messages[random.Next(messages.Length)];

        return $"({DateTime.Now}) Thread {threadId}: {logMessage} (#{logIndex})";
    }

    static async Task MonitorLogFiles(string logDirectory, string archivePath)
    {
        while (true)
        {
            foreach (string logFile in Directory.GetFiles(logDirectory, "*.txt"))
            {
                FileInfo fileInfo = new FileInfo(logFile);
                if (fileInfo.Length > 1024)
                {
                    lock (archiveLock)
                    {
                        string tempFile = logFile + ".tmp";
                        File.Move(logFile, tempFile);

                        using (FileStream zipToOpen = new FileStream(archivePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                        {
                            string entryName = Path.GetFileName(logFile);
                            var existingEntry = archive.GetEntry(entryName);
                            existingEntry?.Delete();
                            archive.CreateEntryFromFile(tempFile, entryName, CompressionLevel.Optimal);
                        }
                        File.Delete(tempFile);
                        File.WriteAllText(logFile, string.Empty);
                        Console.WriteLine($"Архивирован и очищен: {logFile}");
                    }
                }
            }
            await Task.Delay(5000);
        }
    }

    static async Task AnalyzeLogs(string logDirectory, string errorLogPath)
    {
        while (true)
        {
            lock (logLock)
            {
                using StreamWriter errorWriter = new StreamWriter(new FileStream(errorLogPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite));
                foreach (string logFile in Directory.GetFiles(logDirectory, "*.txt"))
                {
                    string[] lines = File.ReadAllLines(logFile);
                    foreach (string line in lines)
                    {
                        if (Regex.IsMatch(line, "(Warning|Exception|Ошибка)", RegexOptions.IgnoreCase))
                        {
                            errorWriter.WriteLine(line);
                        }
                    }
                }
            }
            Console.WriteLine("Выполнен анализ на логи с ошибками/предупреждениями");
            await Task.Delay(10000);
        }
    }

    static void GenerateFinalReport(string logDirectory, string errorLogPath, string archivePath)
    {
        Console.WriteLine("\nСтатистика:");

        foreach (string logFile in Directory.GetFiles(logDirectory, "*.txt"))
        {
            int lineCount = File.ReadAllLines(logFile).Length;
            Console.WriteLine($"{Path.GetFileName(logFile)} - {lineCount} записано линий");
        }

        int errorCount = File.Exists(errorLogPath) ? File.ReadAllLines(errorLogPath).Length : 0;
        Console.WriteLine($"Всего ошибок/предупреждений: {errorCount}");

        long archiveSize = File.Exists(archivePath) ? new FileInfo(archivePath).Length : 0;
        Console.WriteLine($"Размер архива с логами: {archiveSize} байт");
    }
}
