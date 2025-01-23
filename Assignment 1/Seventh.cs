using System;

class Seventh{
    static void Main(string[]args){
        // Prompt user for the month and day
        Console.Write("Enter the month in (1-12): ");
        int month = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the day in (1-31): ");
        int day = Convert.ToInt32(Console.ReadLine());

        // Check whether the given month and day fall within the Spring season or not
        if ((month == 3 && day >= 20) || (month > 3 && month < 6) || (month == 6 && day <= 20)){
            Console.WriteLine("It's a Spring Season");
        }
        else{
            Console.WriteLine("Not a Spring Season");
        }
    }
}
