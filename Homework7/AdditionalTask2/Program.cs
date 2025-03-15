class Program
{
    static void Main()
    {
        Console.Write("Введите путь к каталогу: ");
        string directoryPath = Console.ReadLine();

        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Каталог не найден");
            return;
        }

        var files = Directory.GetFiles(directoryPath);
        var groupedFiles = files.GroupBy(file => Path.GetExtension(file).ToLower())
                                .OrderBy(group => group.Key);

        Console.Clear();
        Console.WriteLine($"Файлы в директории {directoryPath} згрупированные по типам:\n");

        foreach (var group in groupedFiles)
        {
            Console.WriteLine($"Тип файлов: {group.Key} ({group.Count()} шт)");
            foreach (var file in group)
            {
                Console.WriteLine("  " + Path.GetFileName(file));
            }
            Console.WriteLine();
        }
    }
}