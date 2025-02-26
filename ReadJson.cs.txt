using System;
using Newtonsoft.Json;
using System.IO;

internal class Read_Json
{
    public void Read()
    {
        string jsonFile = File.ReadAllText("user.json");
        dynamic user = JsonConvert.DeserializeObject(jsonFile);

        Console.WriteLine($"User Name: {user.Name}");
        Console.WriteLine($"User Email: {user.Email}");
    }
    
}