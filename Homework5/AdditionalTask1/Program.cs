class Program
{
    static async Task Main()
    {
        List<Investor> investors = new()
        {
            new Investor { Id = 1, Name = "Вкладчик1", Deposit = 25000 },
            new Investor { Id = 2, Name = "Вкладчик2", Deposit = 80000 },
            new Investor { Id = 3, Name = "Вкладчик3", Deposit = 43000 }
        };

        List<Task> tasks = investors.Select(investor => Task.Run(() =>
        {
            int packs = (int)Math.Ceiling(investor.Deposit / 10000);
            Console.WriteLine($"{investor.Name} требует {packs} пачек денег");
        })).ToList();

        await Task.WhenAll(tasks);
        Console.WriteLine("Подсчет завершен");
    }
}
class Investor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Deposit { get; set; }
}
