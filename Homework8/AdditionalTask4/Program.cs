class Program
{
    static void Main()
    {
        string filePath = "data.txt";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            Console.Write("Введите текст для записи в файл: ");
            string input = Console.ReadLine();
            writer.WriteLine(input);
            Console.WriteLine("Данные записаны в файл");
        }

        using (StreamReader reader = new StreamReader(filePath))
        {
            string content = reader.ReadToEnd();
            Console.WriteLine("Содержимое файла:");
            Console.WriteLine(content);
        }
    }
}
