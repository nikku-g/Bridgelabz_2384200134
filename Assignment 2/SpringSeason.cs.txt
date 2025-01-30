using System;

public class SpringSeason
{
	//create the boolean method to check month and day lie in the spring Season 
      public static bool IsSpringSeason(int month, int day)
      {
          if ((month == 3 && day >= 20 && day <= 31) ||
              (month == 4 && day >= 1 && day <= 30) ||
              (month == 5 && day >= 1 && day <= 31) ||
              (month == 6 && day >= 1 && day <= 20))
          {
              return true; // if yes return true
          }
          return false;	// if no return false
      }
	
	public static void Main(string[] args)
      {	
		//check the length of the arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Provide month and day as command-line arguments.");
                return;
            }
		
		    // Taking input from command-line
               int month = int.Parse(args[0]);
               int day = int.Parse(args[1]);

		// Print if month and day lie in the IsSpringSeason method  
            if (IsSpringSeason(month, day))
            {
                Console.WriteLine("It's a Spring Season.");
            }
		//Print if month and day not lie in the IsSpringSeason method  
        else
        {
            Console.WriteLine("Not a Spring Season.");
        }
    }
}