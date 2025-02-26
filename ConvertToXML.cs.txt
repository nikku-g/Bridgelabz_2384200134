using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;

class Program
{
    static void Main()
    {
        // Sample JSON
        string json = @"{
            ""Person"": {
                ""Name"": ""Alice"",
                ""Age"": 30,
                ""City"": ""New York""
            }
        }";

        // Convert JSON to XML
        XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(json, "Root");

        // Print XML
        Console.WriteLine(xmlDoc.OuterXml);
    }
}
