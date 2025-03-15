using System.IO.Compression;

class Program
{
    static async Task Main()
    {
        string directoryPath = @"D:\test";
        string zipFilePath = Path.Combine(directoryPath, "CompressedFiles.zip");

        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Каталог не найден");
            return;
        }

        FileInfo[] files = new DirectoryInfo(directoryPath).GetFiles();

        if (files.Length == 0)
        {
            Console.WriteLine("Каталог пустой");
            return;
        }

        Console.WriteLine($"Найдено {files.Length} файлов. Сжатие в ZIP");

        await FilesToZipAsync(files, zipFilePath);

        Console.WriteLine($"Сжатие завершено. Архив: {zipFilePath}");
    }

    static async Task FilesToZipAsync(FileInfo[] files, string zipFilePath)
    {
        try
        {
            using MemoryStream zipMemoryStream = new();
            using (ZipArchive archive = new(zipMemoryStream, ZipArchiveMode.Create, leaveOpen: true))
            {
                foreach (var file in files)
                {
                    await AddFileToZipAsync(file, archive);
                }
            }

            await File.WriteAllBytesAsync(zipFilePath, zipMemoryStream.ToArray());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при создании ZIP: {ex.Message}");
        }
    }

    static async Task AddFileToZipAsync(FileInfo file, ZipArchive archive)
    {
        try
        {
            ZipArchiveEntry entry = archive.CreateEntry(file.Name, CompressionLevel.Optimal);

            using Stream entryStream = entry.Open();
            using Stream fileStream = file.OpenRead();
            await fileStream.CopyToAsync(entryStream);

            Console.WriteLine($"Добавлено {file.Name} в ZIP");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при добавлении {file.Name} в ZIP: {ex.Message}");
        }
    }
}
