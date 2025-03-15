using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var people = new[]
        {
            new Person("Name1", 30),
            new Person("Name2", 25),
            new Person("Name3", 40)
        };

        var cts = new CancellationTokenSource();

        try
        {
            Person foundPerson = await FindPersonAsync(people, "Name2", cts);

            if (foundPerson != null)
                Console.WriteLine($"Найден человек: {foundPerson.Name}, Возраст: {foundPerson.Age}");
            else
                Console.WriteLine("Человек не найден");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Операция была отменена");
        }
    }

    static async Task<Person> FindPersonAsync(Person[] people, string nameToFind, CancellationTokenSource cts)
    {
        foreach (var person in people)
        {
            cts.Token.ThrowIfCancellationRequested();
            await Task.Delay(500);
            Console.WriteLine(person.Name);

            if (person.Name.Equals(nameToFind, StringComparison.OrdinalIgnoreCase))
            {
                cts.Cancel();
                return person;
            }
        }

        return null;
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
