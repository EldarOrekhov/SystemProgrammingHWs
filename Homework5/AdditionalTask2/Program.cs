class Program
{
    static async Task Main()
    {
        int[] numbers = new int[100];
        for (int i = 0; i < 100;)
            numbers[i++] = i;

        int partitionSize = numbers.Length / 4;
        Task<int>[] tasks = new Task<int>[4];

        for (int i = 0; i < 4; i++)
        {
            int start = i * partitionSize;
            int end = (i == 3) ? numbers.Length : start + partitionSize;
            tasks[i] = Task.Run(() => SumRange(numbers, start, end));
        }

        int[] results = await Task.WhenAll(tasks);

        Console.WriteLine($"Общая сумма массива: {results.Sum()}");
    }

    static int SumRange(int[] array, int start, int end)
    {
        int sum = 0;
        for (int i = start; i < end; i++)
            sum += array[i];

        return sum;
    }
}
