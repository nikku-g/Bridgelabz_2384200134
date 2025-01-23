using System;

class Thirteen{
    static void Main(string[]args){
        // Prompt the user to input a number
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
		int total = 0;
		int sum =0;

        // Check the number is a natural number
        if (number > 0){
			// Calculate the sum of the first n given natural numbers
            sum = (number * (number + 1)) / 2;
			
			// using while loop add the first n natural number
			for(int i=number;i>=0;i--){
				total += i;
				if (number == 0){
					break;
				}
			}
        }
        else{
            Console.WriteLine("The number {0} is not a natural number",number);
        }
		
		Console.WriteLine("the sum of natural numbers by using for loop {0} and by using formula {1}",total, sum);
		
		// check both result are same or not
		if (sum == total){
			Console.WriteLine("both result are same");
		}
		else {
			Console.WriteLine("both result are not same");
		}
    }
}
