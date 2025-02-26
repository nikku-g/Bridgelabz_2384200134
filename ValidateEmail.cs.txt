using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

class Program
{
    static void Main()
    {
        // Define JSON schema with email validation
        string schemaJson = @"
        {
            ""type"": ""object"",
            ""properties"": {
                ""Email"": { ""type"": ""string"", ""format"": ""email"" }
            },
            ""required"": [""Email""]
        }";

        // JSON data to validate
        string validJson = @"{ ""Email"": ""user@example.com"" }";
        string invalidJson = @"{ ""Email"": ""invalid-email"" }";

        // Parse schema
        JSchema schema = JSchema.Parse(schemaJson);

        // Validate valid JSON
        ValidateJson(validJson, schema);
        
        // Validate invalid JSON
        ValidateJson(invalidJson, schema);
    }

    static void ValidateJson(string json, JSchema schema)
    {
        JObject jsonObject = JObject.Parse(json);
        if (jsonObject.IsValid(schema, out IList<string> errors))
        {
            Console.WriteLine($"Valid JSON: {json}");
        }
        else
        {
            Console.WriteLine($"Invalid JSON: {json}");
            foreach (var error in errors)
            {
                Console.WriteLine($"- {error}");
            }
        }
    }
}
