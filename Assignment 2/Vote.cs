using System;

class Vote{
    static void Main(string[] args){
        // Define an array of 10 integer elements to store students' ages
        int[] ages = new int[10];

        // Loop to take input for all 10 students
        for (int i = 0; i < ages.Length; i++){
            Console.WriteLine("Enter the age of student " +(i + 1)+ ":");
            bool isValidInput = int.TryParse(Console.ReadLine(), out ages[i]);

            // Check for invalid input
            if (!isValidInput || ages[i] < 0){
                Console.WriteLine("Invalid age./n Please enter a non-negative number.");
				// Decrease the counter to re-enter the age for this student
                i--; 
            }
        }

        // Loop through the array to check if each student can vote
        for (int i = 0; i < ages.Length; i++){
            if (ages[i] >= 18){
                Console.WriteLine("The student with the age "+(ages[i])+ "can vote.");
            }
            else if (ages[i] >= 0){
                Console.WriteLine("The student with the age "+(ages[i])+ "cannot vote.");
            }
        }
    }
}
