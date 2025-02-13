using System;

class CustomDeque
{
    private int[] deque;
    private int front, rear, size;

    public CustomDeque(int capacity)
    {
        deque = new int[capacity];
        front = rear = -1;
        size = 0;
    }

    // Check if deque is empty
    public bool IsEmpty()
    {
        return size == 0;
    }

    // Insert at rear
    public void InsertRear(int value)
    {
        if (size == deque.Length) return; // No overflow handling needed for our use case

        if (IsEmpty()) front = 0;
        rear = (rear + 1) % deque.Length;
        deque[rear] = value;
        size++;
    }

    // Remove from front
    public void RemoveFront()
    {
        if (IsEmpty()) return;

        front = (front + 1) % deque.Length;
        size--;
        if (size == 0) front = rear = -1; // Reset for empty deque
    }

    // Remove from rear
    public void RemoveRear()
    {
        if (IsEmpty()) return;

        rear = (rear - 1 + deque.Length) % deque.Length;
        size--;
        if (size == 0) front = rear = -1; // Reset for empty deque
    }

    // Get front element
    public int GetFront()
    {
        return IsEmpty() ? -1 : deque[front];
    }

    // Get rear element
    public int GetRear()
    {
        return IsEmpty() ? -1 : deque[rear];
    }
}

class SlidingWindowMax
{
    public static int[] SlidingWindowMaximum(int[] arr, int k)
    {
        int n = arr.Length;
        if (n == 0 || k == 0) return new int[0];

        CustomDeque deque = new CustomDeque(n);
        int[] result = new int[n - k + 1];
        int index = 0;

        for (int i = 0; i < n; i++)
        {
            // Remove elements that are out of the current window
            while (!deque.IsEmpty() && deque.GetFront() < i - k + 1)
                deque.RemoveFront();

            // Remove smaller elements in deque since they are useless
            while (!deque.IsEmpty() && arr[deque.GetRear()] <= arr[i])
                deque.RemoveRear();

            // Add current index at the rear of deque
            deque.InsertRear(i);

            // Store result after the first k elements
            if (i >= k - 1)
                result[index++] = arr[deque.GetFront()];
        }

        return result;
    }

    static void Main()
    {
        int[] arr = { 1, 3, -1, -3, 5, 3, 6, 7 };
        int k = 3;
        int[] maxValues = SlidingWindowMaximum(arr, k);

        Console.WriteLine("Sliding Window Maximum:");
        foreach (var val in maxValues)
            Console.Write(val + " ");
    }
}
