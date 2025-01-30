using System;

class MatrixOperations
{
    // Method to create a random matrix with given rows and columns
    static int[,] CreateRandomMatrix(int rows, int cols)
    {
        Random rand = new Random();
        int[,] matrix = new int[rows, cols];
        
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.Next(1, 10);  // Random values between 1 and 9
            }
        }
        return matrix;
    }

    // Method to add two matrices
    static int[,] AddMatrices(int[,] matrix1, int[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }
        return result;
    }

    // Method to subtract two matrices
    static int[,] SubtractMatrices(int[,] matrix1, int[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] - matrix2[i, j];
            }
        }
        return result;
    }

    // Method to multiply two matrices
    static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int rows2 = matrix2.GetLength(0);
        int cols2 = matrix2.GetLength(1);

        if (cols1 != rows2)
        {
            throw new InvalidOperationException("Matrix multiplication is not possible due to incompatible dimensions.");
        }

        int[,] result = new int[rows1, cols2];

        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < cols1; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }
        return result;
    }

    // Method to find the transpose of a matrix
    static int[,] TransposeMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] transposed = new int[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                transposed[j, i] = matrix[i, j];
            }
        }
        return transposed;
    }

    // Method to find the determinant of a 2x2 matrix
    static int Determinant2x2(int[,] matrix)
    {
        if (matrix.GetLength(0) == 2 && matrix.GetLength(1) == 2)
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }
        else
        {
            throw new InvalidOperationException("The matrix must be 2x2 to find the determinant.");
        }
    }

    // Method to find the determinant of a 3x3 matrix
    static int Determinant3x3(int[,] matrix)
    {
        if (matrix.GetLength(0) == 3 && matrix.GetLength(1) == 3)
        {
            return matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1]) -
                   matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0]) +
                   matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);
        }
        else
        {
            throw new InvalidOperationException("The matrix must be 3x3 to find the determinant.");
        }
    }

    // Method to find the inverse of a 2x2 matrix
    static double[,] Inverse2x2(int[,] matrix)
    {
        int determinant = Determinant2x2(matrix);
        if (determinant == 0)
        {
            throw new InvalidOperationException("Matrix is not invertible.");
        }

        double[,] inverse = new double[2, 2];
        inverse[0, 0] = matrix[1, 1] / (double)determinant;
        inverse[0, 1] = -matrix[0, 1] / (double)determinant;
        inverse[1, 0] = -matrix[1, 0] / (double)determinant;
        inverse[1, 1] = matrix[0, 0] / (double)determinant;

        return inverse;
    }

    // Method to find the inverse of a 3x3 matrix (Using adjoint method)
    static double[,] Inverse3x3(int[,] matrix)
    {
        int determinant = Determinant3x3(matrix);
        if (determinant == 0)
        {
            throw new InvalidOperationException("Matrix is not invertible.");
        }

        double[,] inverse = new double[3, 3];

        // Finding the adjoint of the matrix
        inverse[0, 0] = (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1]) / (double)determinant;
        inverse[0, 1] = (matrix[0, 2] * matrix[2, 1] - matrix[0, 1] * matrix[2, 2]) / (double)determinant;
        inverse[0, 2] = (matrix[0, 1] * matrix[1, 2] - matrix[0, 2] * matrix[1, 1]) / (double)determinant;
        inverse[1, 0] = (matrix[1, 2] * matrix[2, 0] - matrix[1, 0] * matrix[2, 2]) / (double)determinant;
        inverse[1, 1] = (matrix[0, 0] * matrix[2, 2] - matrix[0, 2] * matrix[2, 0]) / (double)determinant;
        inverse[1, 2] = (matrix[0, 2] * matrix[1, 0] - matrix[0, 0] * matrix[1, 2]) / (double)determinant;
        inverse[2, 0] = (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]) / (double)determinant;
        inverse[2, 1] = (matrix[0, 1] * matrix[2, 0] - matrix[0, 0] * matrix[2, 1]) / (double)determinant;
        inverse[2, 2] = (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]) / (double)determinant;

        return inverse;
    }

    // Method to display a matrix
    static void DisplayMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    // Method to display a double matrix (for inverse)
    static void DisplayMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        int rows = 3;
        int cols = 3;

        // Create two random matrices
        int[,] matrix1 = CreateRandomMatrix(rows, cols);
        int[,] matrix2 = CreateRandomMatrix(rows, cols);

        // Display the matrices
        Console.WriteLine("Matrix 1:");
        DisplayMatrix(matrix1);
        Console.WriteLine("Matrix 2:");
        DisplayMatrix(matrix2);

        // Matrix Operations
        Console.WriteLine("\nMatrix 1 + Matrix 2:");
        DisplayMatrix(AddMatrices(matrix1, matrix2));

        Console.WriteLine("\nMatrix 1 - Matrix 2:");
        DisplayMatrix(SubtractMatrices(matrix1, matrix2));

        Console.WriteLine("\nMatrix 1 * Matrix 2:");
        DisplayMatrix(MultiplyMatrices(matrix1, matrix2));

        Console.WriteLine("\nTranspose of Matrix 1:");
        DisplayMatrix(TransposeMatrix(matrix1));

        // Determinants and Inverses
        Console.WriteLine("\nDeterminant of Matrix 1 (3x3): " + Determinant3x3(matrix1));

        try
        {
            Console.WriteLine("\nInverse of Matrix 1 (3x3):");
            DisplayMatrix(Inverse3x3(matrix1));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
