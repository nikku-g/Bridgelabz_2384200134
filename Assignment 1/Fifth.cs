using System;

class Fifth{
    static void Main(string[]args){
        // prompt the user to input there age
        Console.Write("Enter your age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        // Check the age of person is 18 or older
        if (age >= 18){
            Console.WriteLine("The person's age is {0} and can vote.", age);
        }
        else{
            Console.WriteLine("The person's age is {0} and cannot vote.", age);
        }
    }
}
