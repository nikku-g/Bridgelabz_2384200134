using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        string json = @"
        [
            { ""Name"": ""Alice"", ""Age"": 24 },
            { ""Name"": ""Bob"", ""Age"": 30 },
            { ""Name"": ""Charlie"", ""Age"": 28 }
        ]";

        // Deserialize JSON into a List
        List<Person> people = JsonConvert.DeserializeObject<List<Person>>(json);

        // Filter records where Age > 25
        var filteredPeople = people.Where(p => p.Age > 25);

        // Convert the filtered list back to JSON
        string filteredJson = JsonConvert.SerializeObject(filteredPeople, Formatting.Indented);

        Console.WriteLine(filteredJson);
    }
}
