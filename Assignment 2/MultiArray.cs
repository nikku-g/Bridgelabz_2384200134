using System;

class MultiArray{
    static void Main(string[] args){
        // Take user input for rows and columns
        Console.WriteLine("Enter the number of rows:");
        int rows = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the number of columns:");
        int columns = int.Parse(Console.ReadLine());

        // Create a 2D array (Matrix) with the given rows and columns
        int[,] matrix = new int[rows, columns];

        // Input elements for the 2D array (matrix)
        Console.WriteLine("Enter the elements of the matrix:");
		// Outer loop for rows
        for (int i = 0; i < rows; i++){
			// Inner loop for columns
            for (int j = 0; j < columns; j++){
                Console.Write("Enter element "+({i + 1}, {j + 1})+": ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Create a 1D array to store elements of the 2D array
        int[] array = new int[rows * columns];

        // Copy elements from the 2D array to the 1D array
        int index = 0;  // Index for the 1D array
        for (int i = 0; i < rows; i++){  // Outer loop for rows
            for (int j = 0; j < columns; j++){  // Inner loop for columns
                // Copy the element from the 2D array into the 1D array
                array[index] = matrix[i, j];
                index++;  
            }
        }

        // Display the 1D array elements
        Console.WriteLine("\nElements of the 1D array:");
        foreach (int item in array){
            Console.Write(item + " ");
        }
    }
}
