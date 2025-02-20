using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Ask user for their name, age, and favorite programming language
        Console.WriteLine("Please enter your name:");
        string name = Console.ReadLine();

        Console.WriteLine("Please enter your age:");
        int age;
        while (!int.TryParse(Console.ReadLine(), out age))
        {
            Console.WriteLine("Invalid input. Please enter a valid age.");
        }

        Console.WriteLine("Please enter your favorite programming language:");
        string favoriteLanguage = Console.ReadLine();

        // Prepare the file path
        string filePath = "user_info.txt";

        // Check if the file can be written to and if the directory exists
        if (File.Exists(filePath) || Directory.Exists(Path.GetDirectoryName(filePath)))
        {
            // Write the collected information to a file using StreamWriter
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("User Information:");
                writer.WriteLine($"Name: {name}");
                writer.WriteLine($"Age: {age}");
                writer.WriteLine($"Favorite Programming Language: {favoriteLanguage}");
            }

            Console.WriteLine("\nYour information has been saved to 'user_info.txt'.");
        }
        else
        {
            // Handle case where file or directory cannot be accessed
            Console.WriteLine("An error occurred while trying to access the file or directory.");
        }
    }
}
