using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        string csvFilePath = "data.csv"; // Replace with your CSV file path

        // Read CSV file
        string[] lines = File.ReadAllLines(csvFilePath);

        if (lines.Length == 0)
        {
            Console.WriteLine("CSV file is empty.");
            return;
        }

        // Extract headers
        string[] headers = lines[0].Split(',');

        // Convert CSV to JSON
        var jsonList = new List<Dictionary<string, string>>();
        foreach (string line in lines.Skip(1))
        {
            string[] values = line.Split(',');
            var entry = new Dictionary<string, string>();
            for (int i = 0; i < headers.Length; i++)
            {
                entry[headers[i]] = values.Length > i ? values[i] : "";
            }
            jsonList.Add(entry);
        }

        // Serialize to JSON
        string json = JsonConvert.SerializeObject(jsonList, Formatting.Indented);

        Console.WriteLine(json);
    }
}
