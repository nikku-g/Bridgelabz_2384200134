using System;
using System.IO;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        string filePath = "data.json"; // Replace with your JSON file path

        // Read JSON file
        string jsonContent = File.ReadAllText(filePath);

        // Parse JSON
        JObject jsonObj = JObject.Parse(jsonContent);

        // Print all keys and values
        PrintJson(jsonObj, "");
    }

    static void PrintJson(JToken token, string indent)
    {
        if (token is JObject obj)
        {
            foreach (var property in obj.Properties())
            {
                Console.WriteLine($"{indent}{property.Name}:");
                PrintJson(property.Value, indent + "  ");
            }
        }
        else if (token is JArray array)
        {
            int index = 0;
            foreach (var item in array)
            {
                Console.WriteLine($"{indent}[{index}]:");
                PrintJson(item, indent + "  ");
                index++;
            }
        }
        else
        {
            Console.WriteLine($"{indent}{token}");
        }
    }
}
