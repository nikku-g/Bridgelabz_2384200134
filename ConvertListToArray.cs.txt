using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
}

class Program
{
    static void Main()
    {
        List<Car> cars = new List<Car>
        {
            new Car { Make = "Toyota", Model = "Camry", Year = 2022 },
            new Car { Make = "Honda", Model = "Civic", Year = 2021 },
            new Car { Make = "Ford", Model = "Mustang", Year = 2023 }
        };

        string json = JsonConvert.SerializeObject(cars, Formatting.Indented);
        Console.WriteLine(json);
    }
}
