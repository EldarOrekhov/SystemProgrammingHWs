using System;
using System.Net;
using System.Threading;

class Program
{
    static void Main()
    {
        List<Account> accounts = new List<Account> 
        {
            new Account(1, 1000),
            new Account(2, 1500),
            new Account(3, 2000),
            new Account(4, 2500),
            new Account(5, 3000)
        };

        List<Client> clients = new List<Client>();
        foreach (Account account in accounts) { clients.Add(new Client(account)); }

        foreach (Client client in clients) { client.Start(); }

        Thread.Sleep(10000);
        foreach (Client client in clients) { client.Stop(); }
        Console.WriteLine("Operations stoped");
    }
}

class Account
{
    public int Id { get; set; }
    private decimal _balance;
    private readonly object _lock = new object();

    public Account(int id, decimal initialBalance)
    {
        Id = id;
        _balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        lock (_lock)
        {
            _balance += amount;
            Console.WriteLine($"Account - {Id} Deposit: {amount:C}. Current balance: {_balance:C}");
        }
    }

    public void Withdraw(decimal amount)
    {
        lock (_lock) 
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                Console.WriteLine($"Account - {Id} Withdraw: {amount:C}. Current balance: {_balance:C}");
            }
            else
                Console.WriteLine($"Account - {Id} No enough funds to withdraw: {amount:C}. Current balance: {_balance:C}");
        }
    }
    public decimal GetBalance() 
    {
        lock (_lock) 
        {
            return _balance;
        }
    }
}

class Client
{
    private static readonly Random _random = new Random();
    private Account _account;
    private Thread _thread;
    private bool _isRunning;

    public Client(Account account)
    {
        _account = account;
        _thread = new Thread(PerformOperations);
        _isRunning = true;
    }
    public void Start() 
    {
        _thread.Start();
    }

    public void Stop() 
    {
        _isRunning = false;
    }

    private void PerformOperations()
    {
        while (_isRunning)
        {
            Thread.Sleep(_random.Next(1000, 3000));
            decimal amount = _random.Next(1, 100);
            if (_random.Next(0, 2) == 0)
                _account.Deposit(amount);
            else 
                _account.Withdraw(amount);
        }
    }
}