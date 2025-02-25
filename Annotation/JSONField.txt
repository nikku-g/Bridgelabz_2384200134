using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

// Step 1: Define the JsonField attribute
[AttributeUsage(AttributeTargets.Property)]
public class JsonField : Attribute
{
    public string Name { get; }
    
    public JsonField(string name)
    {
        Name = name;
    }
}
// Step 2: Apply JsonField to a User class
public class User
{
    [JsonField("user_name")]
    public string Username { get; set; }

    [JsonField("user_age")]
    public int Age { get; set; }

    [JsonField("email_address")]
    public string Email { get; set; }

    public User(string username, int age, string email)
    {
        Username = username;
        Age = age;
        Email = email;
    }
}
// Step 3: Method to serialize object using JsonField attribute
public static class JsonSerializerCustom
{
    public static string SerializeToJson(object obj)
    {
        Dictionary<string, object> jsonDict = new Dictionary<string, object>();
        Type type = obj.GetType();

        foreach (PropertyInfo property in type.GetProperties())
        {
            var attr = (JsonField)Attribute.GetCustomAttribute(property, typeof(JsonField));
            string jsonKey = attr != null ? attr.Name : property.Name;
            object value = property.GetValue(obj);
            jsonDict[jsonKey] = value;
        }

        return JsonSerializer.Serialize(jsonDict, new JsonSerializerOptions { WriteIndented = true });
    }
}
// Step 4: Test Serialization
class Program
{
    static void Main()
    {
        User user = new User("john_doe", 25, "john@example.com");
        string json = JsonSerializerCustom.SerializeToJson(user);
        Console.WriteLine(json);
    }
}