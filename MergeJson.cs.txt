using System;
using System.IO;
using Newtonsoft.Json.Linq;

internal class Merge_Json
{
    public void Merge()
    {
        string file1 = File.ReadAllText("user.json");
        string file2 = File.ReadAllText("user1.json");

        JObject obj1 = JObject.Parse(file1);
        JObject obj2 = JObject.Parse(file2);

        obj1.Merge(obj2, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Union });
        Console.WriteLine(obj1.ToString());
    }
}