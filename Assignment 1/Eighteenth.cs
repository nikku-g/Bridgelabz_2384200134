using System;

class Eighteenth{
    static void Main(string[]args){
        Console.Write("Enter a number between 6-9 : ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Check the number is between 6-9 or not
        if ((number >=6) && (number <=9)){
			// Using a for loop to iterate from 1 to 10
			for (int i=1;i<=10;i++){
				int value = i*number;
				Console.WriteLine("{0} * {1} = {2}",number,i,value);
			}
        }
        else{
           Console.WriteLine("please enter a value between 6-9");
        }
    }
}
