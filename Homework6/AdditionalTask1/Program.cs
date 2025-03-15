using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        int[] array1 = { 5, 3, 8, 4, 2, 7, 1, 6 };
        int[] array2 = { 5, 3, 8, 4, 2, 7, 1, 6 };

        Task<int[]> linqRes = SortLinq(array1);
        Task<int[]> arrayRes = SortArray(array2);

        int[][] sortedArrays = await Task.WhenAll(linqRes, arrayRes);

        Console.Write("Linq sort: ");
        foreach (int num in sortedArrays[0]) Console.Write($"{num} ");
        Console.WriteLine();

        Console.Write("Array sort: ");
        foreach (int num in sortedArrays[1]) Console.Write($"{num} ");
        Console.WriteLine();
    }

    static async Task<int[]> SortLinq(int[] array)
    {
        int[] sortedArray = array.OrderBy(x => x).ToArray();
        
        return sortedArray;
    }

    static async Task<int[]> SortArray(int[] array)
    {
        Array.Sort(array);
        return array;
    }
}
