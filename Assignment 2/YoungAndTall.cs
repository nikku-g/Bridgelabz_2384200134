using System;

class YoungAndTall {
	public static void Main()
    {
        // Input ages and heights for Amar, Akbar, and Anthony
        Console.Write("Enter Amar's age: ");
        int amarAge = int.Parse(Console.ReadLine());
        Console.Write("Enter Amar's height in cm: ");
        int amarHeight = int.Parse(Console.ReadLine());

        Console.Write("Enter Akbar's age: ");
        int akbarAge = int.Parse(Console.ReadLine());
        Console.Write("Enter Akbar's height in cm: ");
        int akbarHeight = int.Parse(Console.ReadLine());

        Console.Write("Enter Anthony's age: ");
        int anthonyAge = int.Parse(Console.ReadLine());
        Console.Write("Enter Anthony's height in cm: ");
        int anthonyHeight = int.Parse(Console.ReadLine());

        // Find the youngest and tallest friends using separate methods
        string youngest = FindYoungest(amarAge, akbarAge, anthonyAge);
        string tallest = FindTallest(amarHeight, akbarHeight, anthonyHeight);

        // Display the results
        Console.WriteLine("\nThe youngest friend is: {0}", youngest);
        Console.WriteLine("The tallest friend is: {0}", tallest);
    }

    // Method to find the youngest friend
    static string FindYoungest(int amarAge, int akbarAge, int anthonyAge)
    {
        if (amarAge <= akbarAge && amarAge <= anthonyAge)
        {
            return "Amar";
        }
        else if (akbarAge <= amarAge && akbarAge <= anthonyAge)
        {
            return "Akbar";
        }
        else
        {
            return "Anthony";
        }
    }

    // Method to find the tallest friend
    static string FindTallest(int amarHeight, int akbarHeight, int anthonyHeight)
    {
        if (amarHeight >= akbarHeight && amarHeight >= anthonyHeight)
        {
            return "Amar";
        }
        else if (akbarHeight >= amarHeight && akbarHeight >= anthonyHeight)
        {
            return "Akbar";
        }
        else
        {
            return "Anthony";
        }
    }
}