class Program
{
    static void Main()
    {
        string filePath = "test.txt";

        string textToWrite = "Hello World";

        File.WriteAllText(filePath, textToWrite);
        Console.WriteLine("Текст был успешно записан в файл\n");

        FileInfo fileInfo = new FileInfo(filePath);

        Console.WriteLine("Информация о файле:");
        Console.WriteLine($"Полный путь: {fileInfo.FullName}");
        Console.WriteLine($"Размер: {fileInfo.Length} байт");
        Console.WriteLine($"Дата создания: {fileInfo.CreationTime}");

        string readText = File.ReadAllText(filePath);
        Console.WriteLine("\nТекст считанный с файла:");
        Console.WriteLine(readText);
    }
}
