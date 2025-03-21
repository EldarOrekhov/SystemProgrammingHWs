class Program
{
    static unsafe void Main(string[] args)
    {
        Random random = new Random();
        int first = random.Next();
        int second = random.Next();
        int third;
        byte* bytes = (byte*)&third;

        byte* firstBytes = (byte*)&first;
        byte* secondBytes = (byte*)&second;

        bytes[0] = firstBytes[0];
        bytes[1] = firstBytes[1];
        bytes[2] = secondBytes[0];
        bytes[3] = secondBytes[1];

        Console.Write($"Первое число: {first} (");
        for (int i = 0; i < 4; i++) Console.Write($"{firstBytes[i]:X2}-");
        Console.Write("\b)\n");

        Console.Write($"Второе число: {second} (");
        for (int i = 0; i < 4; i++) Console.Write($"{secondBytes[i]:X2}-");
        Console.Write("\b)\n");

        Console.Write($"Третье число: {third} (");
        for (int i = 0; i < 4; i++) Console.Write($"{bytes[i]:X2}-");
        Console.Write("\b)\n");
    }
}