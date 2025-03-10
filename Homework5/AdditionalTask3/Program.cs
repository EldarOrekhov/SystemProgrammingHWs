class Program
{
    static async Task Main()
    {
        Random random = new Random();
        int[] numbers = new int[15];
        for (int i = 0; i < numbers.Length; i++) numbers[i] = random.Next(1, 21);
        int searchValue = 10;

        Task<int[]> removeTask = Task.Run(() => numbers.Distinct().ToArray());

        Task<int[]> sortTask = removeTask.ContinueWith(task =>
        {
            int[] arr = task.Result;
            Array.Sort(arr);
            return arr;
        });

        Task<int> searchTask = sortTask.ContinueWith(task =>
        {
            int[] sortedArray = task.Result;
            return Array.BinarySearch(sortedArray, searchValue);
        });

        int[] sortedArray = await sortTask;
        int searchResult = await searchTask;

        Console.Write("Отсортированный массив без дубликатов: ");
        foreach (int num in sortedArray) Console.Write($"{num} ");
        Console.WriteLine();
        Console.WriteLine(searchResult >= 0 ? $"Индекс {searchValue} - {searchResult}" : $"Элемент {searchValue} не найден");
    }
}