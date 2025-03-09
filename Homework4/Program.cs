using System;
using System.Threading;

class BankAccount
{
    private decimal balance;
    private readonly object _lock = new object();

    public BankAccount(decimal startBalance)
    {
        balance = startBalance;
    }

    public void Withdraw(decimal amount)
    {
        Monitor.Enter(_lock);
        try
        {
            if (balance >= amount)
            {
                Console.WriteLine($"Снятие {amount} с баланса");
                balance -= amount;
                Console.WriteLine($"Остаток: {balance}");
            }
            else
            {
                Console.WriteLine("Недостаточно средств для снятия");
            }
        }
        finally
        {
            Monitor.Exit(_lock); 
        }
    }

    public decimal GetBalance()
    {
        return balance;
    }
}

class Program
{
    static BankAccount account = new BankAccount(1000);
    static void Main(string[] args)
    {
        Thread client1 = new Thread(() => ClientOperations("Клиент 1"));
        Thread client2 = new Thread(() => ClientOperations("Клиент 2"));

        client1.Start();
        client2.Start();

        client1.Join();
        client2.Join();

        Console.WriteLine($"Итоговый баланс: {account.GetBalance()}");
    }

    static void ClientOperations(string clientName)
    {
        Random random = new Random();
        int elapsedTime = 0;

        while (elapsedTime < 5)
        {
            decimal amount = random.Next(50, 200);
            account.Withdraw(amount);

            Thread.Sleep(random.Next(500, 1500));
            elapsedTime++;
        }
    }
}
