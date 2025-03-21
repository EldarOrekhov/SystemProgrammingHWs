using System;

class Program
{
    static unsafe void Main()
    {
        Console.Write("Введите первое число: ");
        int x = int.Parse(Console.ReadLine());

        Console.Write("Введите второе число: ");
        int y = int.Parse(Console.ReadLine());

        Console.WriteLine($"До обмена: x = {x}, y = {y}");

        int* ptrX = &x, ptrY = &y;
        *ptrX = *ptrX + *ptrY;
        *ptrY = *ptrX - *ptrY;
        *ptrX = *ptrX - *ptrY;

        Console.WriteLine($"После обмена: x = {x}, y = {y}");
    }
}
