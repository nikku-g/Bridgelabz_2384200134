using System;

class Fourth{
    static void Main(string[]args){
        // Prompt the user to input a number
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Check the number is a natural number
        if (number > 0){
            // Calculate the sum of the first given natural numbers
            int sum = (number * (number + 1)) / 2;
            Console.WriteLine("The sum of {0} natural numbers is {1}", number, sum);
        }
        elsestring[]args{
            Console.WriteLine($"The number {number} is not a natural number");
        }
    }
}
