using System;

public class StockSpan
{
    // Method to calculate the stock span for each day
    public int[] CalculateStockSpan(int[] prices)
    {
        int n = prices.Length;
        int[] spans = new int[n];  // Array to store the span of each day
        int[] stack = new int[n];  // Array to store indices of stock prices
        int top = -1;  // Pointer for the top of the stack

        // Traverse through the prices
        for (int i = 0; i < n; i++)
        {
            // Pop elements from stack while the stack is not empty and the current price is greater than or equal to
            // the price at the index at the top of the stack
            while (top >= 0 && prices[stack[top]] <= prices[i])
            {
                top--;  // Pop the top element of the stack
            }

            // If stack is empty, it means the current price is greater than all the previous prices
            spans[i] = (top == -1) ? (i + 1) : (i - stack[top]);

            // Push the current index to the stack
            top++;
            stack[top] = i;
        }

        return spans;
    }

    // Helper method to print the array
    public void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        StockSpan stockSpan = new StockSpan();

        // Sample stock prices for 7 days
        int[] prices = { 100, 80, 60, 70, 60, 75, 85 };

        // Calculate stock spans
        int[] spans = stockSpan.CalculateStockSpan(prices);

        // Print the calculated stock spans
        Console.WriteLine("Stock spans are:");
        stockSpan.PrintArray(spans);
    }
}
