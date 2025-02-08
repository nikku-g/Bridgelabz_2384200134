using System;

// Base class: Person
class Person
{
    public string Name { get; set; }
    public int Id { get; set; }

    public Person(string name, int id)
    {
        Name = name;
        Id = id;
    }
}

// Interface: Worker
interface Worker
{
    void PerformDuties();
}

// Subclass: Chef
class Chef : Person, Worker
{
    public string Specialty { get; set; }

    public Chef(string name, int id, string specialty) : base(name, id)
    {
        Specialty = specialty;
    }

    public void PerformDuties()
    {
        Console.WriteLine("Chef {0} (ID: {1}) is preparing {2} dishes.", Name, Id, Specialty);
    }
}

// Subclass: Waiter
class Waiter : Person, Worker
{
    public int TableCount { get; set; }

    public Waiter(string name, int id, int tableCount) : base(name, id)
    {
        TableCount = tableCount;
    }

    public void PerformDuties()
    {
        Console.WriteLine("Waiter {0} (ID: {1}) is serving {2} tables.", Name, Id, TableCount);
    }
}

// Main program
class Program
{
    static void Main()
    {
        Worker chef = new Chef("Gordon", 101, "Italian");
        Worker waiter = new Waiter("James", 202, 5);
        
        chef.PerformDuties();
        waiter.PerformDuties();
    }
}
