using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

internal class Validate_Json
{
    public void Validate()
    {
        string schemaText = File.ReadAllText("schema.json");
        string jsonString = File.ReadAllText("user.json");

        JSchema schema = JSchema.Parse(schemaText);
        JObject jsonData = JObject.Parse(jsonString);

        if (jsonData.IsValid(schema))
            Console.WriteLine("JSON is valid!");
        else
            Console.WriteLine("Invalid JSON!");
    }
}