using System;
using Newtonsoft.Json;

public class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
}
internal class Convert_Json
{
    public void Convert()
    {
        Car myCar = new Car { Brand = "Toyota", Model = "Camry", Year = 2022 };
        string jsonFile = JsonConvert.SerializeObject(myCar, Formatting.Indented);
        Console.WriteLine(jsonFile);
    }
}