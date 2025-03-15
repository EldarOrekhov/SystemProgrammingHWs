class Program
{
    static void Main()
    {
        Console.Write("Введите путь к каталогу: ");
        string currentPath = Console.ReadLine();

        while (true)
        {
            if (Directory.Exists(currentPath))
            {
                Console.Clear();
                Console.WriteLine($"Содержимое каталога: {currentPath}\n");

                string[] directories = Directory.GetDirectories(currentPath);
                string[] files = Directory.GetFiles(currentPath);

                Console.WriteLine("[Папки]");
                foreach (var dir in directories)
                    Console.WriteLine("  " + Path.GetFileName(dir));

                Console.WriteLine("\n[Файлы]");
                foreach (var file in files)
                    Console.WriteLine("  " + Path.GetFileName(file));

                Console.WriteLine("\nВведите название папки или \"..\" для выхода на уровень выше: ");
                string input = Console.ReadLine();

                if (input == "..")
                    currentPath = Directory.GetParent(currentPath)?.FullName ?? currentPath;

                else if (directories.Any(d => Path.GetFileName(d) == input))
                    currentPath = Path.Combine(currentPath, input);

                else
                    Console.WriteLine("Неверный ввод");
            }
            else
            {
                Console.WriteLine("Каталог не найден, введите еще раз: ");
                currentPath = Console.ReadLine();
            }
        }
    }
}