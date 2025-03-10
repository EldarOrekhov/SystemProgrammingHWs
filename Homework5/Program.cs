class Program
{
    static async Task Main()
    {
        Task task1 = Task.Run(() =>
        {
            int[] nums = new int[100];
            for (int i = 0; i < 100;)
                nums[i++] = i;

            Console.WriteLine($"Сумма чисел от 1 до 100: {nums.Sum()}");
        });

        Task task2 = Task.Run(async () =>
        {
            Random random = new Random();
            int[] nums = new int[20];
            for (int i = 0; i < 20; i++)
                nums[i] = random.Next(1, 101);

            await File.WriteAllLinesAsync("file1.txt", nums.Select(e => e.ToString()));
        });

        Task task3 = task2.ContinueWith(async _ =>
        {
            string[] lines = await File.ReadAllLinesAsync("file1.txt");
            string[] binary = lines.Select(e => Convert.ToString(int.Parse(e), 2)).ToArray();
            await File.WriteAllLinesAsync("file2.txt", binary);
        });

        await Task.WhenAll(task1, task2, task3);
        Console.WriteLine("Все задачи выполнены");
    }
}
