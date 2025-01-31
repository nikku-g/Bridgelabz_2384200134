using System;

class NumberGuessingGame
{
    static Random random = new Random();

    // Function to generate a random guess between the low and high range
    static int GenerateGuess(int low, int high)
    {
        return random.Next(low, high + 1); 
    }

    // Function to get user feedback about the guess
    static string GetFeedback(int guess)
    {
        Console.WriteLine("Is your number {0}? (Enter 'high' if your number is lower, 'low' if your number is higher, 'correct' if the guess is correct)",guess);
        string feedback = Console.ReadLine().ToLower();
        return feedback;
    }

    // Function to play the game
    static void PlayGame()
    {
        int low = 1;
        int high = 100;
        string feedback = "";

        Console.WriteLine("Think a number between 1 and 100, and I will try to guess it.");
        Console.WriteLine("You can tell me if my guess is 'high', 'low', or 'correct'.");
        
        while (true)
        {
            int guess = GenerateGuess(low, high); // Generate a new guess based on the current range
            feedback = GetFeedback(guess); // Get feedback from the user about the guess

            if (feedback == "correct")
            {
                Console.WriteLine("Hooray! I guessed your number {0} correctly.",guess);
                break;
            }
            else if (feedback == "high")
            {
                high = guess - 1; // Adjust the high boundary
            }
            else if (feedback == "low")
            {
                low = guess + 1; // Adjust the low boundary
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'high', 'low', or 'correct'.");
            }
        }
    }

    static void Main(string[] args)
    {
        PlayGame(); // Start the game
    }
}
