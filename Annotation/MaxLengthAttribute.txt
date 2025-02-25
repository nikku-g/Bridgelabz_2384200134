using System;
using System.Reflection;

// Step 1: Define the MaxLength attribute
[AttributeUsage(AttributeTargets.Property)]
public class MaxLength : Attribute
{
    public int Value { get; }

    public MaxLength(int value)
    {
        Value = value;
    }
}
// Step 2: Apply MaxLength to a class field
public class User
{
    [MaxLength(10)] // Restrict Username length to 10 characters
    public string Username { get; }

    public User(string username)
    {
        ValidateMaxLength(this, nameof(Username), username);
        Username = username;
    }

    private void ValidateMaxLength(object obj, string propertyName, string value)
    {
        PropertyInfo property = obj.GetType().GetProperty(propertyName);
        if (property != null)
        {
            var maxLengthAttr = (MaxLength)Attribute.GetCustomAttribute(property, typeof(MaxLength));
            if (maxLengthAttr != null && value.Length > maxLengthAttr.Value)
            {
                throw new ArgumentException($"Error: {propertyName} exceeds max length of {maxLengthAttr.Value} characters.");
            }
        }
    }
}

// Step 3: Test the validation
class Program
{
    static void Main()
    {
        try
        {
            User user1 = new User("ShortName");
            Console.WriteLine($"User created successfully: {user1.Username}");

            User user2 = new User("VeryLongUsername"); // This should trigger an exception
            Console.WriteLine($"User created successfully: {user2.Username}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}