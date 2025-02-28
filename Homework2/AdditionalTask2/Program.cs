using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;

class Program
{
    static void Main()
    {
        OrderQueue orderQueue = new OrderQueue();
        List<Waiter> waiters = new List<Waiter>();
        List<Cook> cooks = new List<Cook>();

        for (int i = 1; i <= 3; i++)
        {
            waiters.Add(new Waiter(orderQueue, i));
        }
        for (int i = 1; i <= 2; i++)
        {
            cooks.Add(new Cook(orderQueue, i));
        }

        foreach (Waiter waiter in waiters) { waiter.Start(); }
        foreach (Cook cook in cooks) { cook.Start(); }

        Thread.Sleep(10000);

        foreach (Waiter waiter in waiters) { waiter.Stop(); }
        foreach (Cook cook in cooks) { cook.Stop(); }

        Console.WriteLine("Operations stopped");
    }
}

class OrderQueue
{
    private ConcurrentQueue<string> _orders = new ConcurrentQueue<string>();
    private object _lock = new object();

    public void AddOrder(string order)
    {
        lock (_lock)
        {
            _orders.Enqueue(order);
            Console.WriteLine($"Order received: {order}");
        }
    }

    public bool GetOrder(out string order)
    {
        lock (_lock)
        {
            return _orders.TryDequeue(out order);
        }
    }
}

class Waiter
{
    private static readonly Random _random = new Random();
    private OrderQueue _orderQueue;
    private static int _orderCounter = 1;
    private Thread _thread;
    private bool _isRunning;
    private int _id;

    public Waiter(OrderQueue orderQueue, int id)
    {
        _orderQueue = orderQueue;
        _id = id;
        _thread = new Thread(TakeOrders);
        _isRunning = true;
    }
    public void Start() { _thread.Start(); }
    public void Stop() { _isRunning = false; }

    private void TakeOrders()
    {
        while (_isRunning)
        {
            Thread.Sleep(_random.Next(1000, 3000));
            string order = $"Order {_orderCounter++} from waiter {_id}";
            _orderQueue.AddOrder(order);
        }
    }
}

class Cook
{
    private static readonly Random _random = new Random();
    private OrderQueue _orderQueue;
    private Thread _thread;
    private bool _isRunning;
    private int _id;

    public Cook(OrderQueue orderQueue, int id)
    {
        _orderQueue = orderQueue;
        _id = id;
        _thread = new Thread(ProcessOrders);
        _isRunning = true;
    }
    public void Start() { _thread.Start(); }
    public void Stop() { _isRunning = false; }

    private void ProcessOrders()
    {
        while (_isRunning)
        {
            if (_orderQueue.GetOrder(out string order))
            {
                Console.WriteLine($"Cook {_id} is preparing {order}");
                Thread.Sleep(_random.Next(2000, 5000));
                Console.WriteLine($"Cook {_id} has prepared {order}");
            }
            else
            {
                Thread.Sleep(500);
            }
        }
    }
}
