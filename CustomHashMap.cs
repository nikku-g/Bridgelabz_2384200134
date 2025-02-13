using System;

class HashNode
{
    public int Key;
    public int Value;
    public HashNode Next;

    public HashNode(int key, int value)
    {
        Key = key;
        Value = value;
        Next = null;
    }
}

class CustomHashMap
{
    private int capacity;
    private HashNode[] table;

    public CustomHashMap(int size)
    {
        capacity = size;
        table = new HashNode[capacity];
    }

    private int HashFunction(int key)
    {
        return Math.Abs(key) % capacity;
    }

    public void Put(int key, int value)
    {
        int index = HashFunction(key);

        // If no linked list exists, create one
        if (table[index] == null)
        {
            table[index] = new HashNode(key, value);
            return;
        }

        // Traverse the linked list to update the key if it exists
        HashNode current = table[index];
        while (current != null)
        {
            if (current.Key == key)
            {
                current.Value = value; // Update value if key exists
                return;
            }
            if (current.Next == null) break;
            current = current.Next;
        }

        // Insert a new node at the end
        current.Next = new HashNode(key, value);
    }

    public int Get(int key)
    {
        int index = HashFunction(key);
        HashNode current = table[index];

        while (current != null)
        {
            if (current.Key == key)
                return current.Value;
            current = current.Next;
        }

        return -1; // Key not found
    }

    public void Remove(int key)
    {
        int index = HashFunction(key);
        HashNode current = table[index];
        HashNode prev = null;

        while (current != null)
        {
            if (current.Key == key)
            {
                if (prev == null) // Key is at the head
                    table[index] = current.Next;
                else
                    prev.Next = current.Next;

                return; // Key removed
            }
            prev = current;
            current = current.Next;
        }
    }

    public void Display()
    {
        for (int i = 0; i < capacity; i++)
        {
            Console.Write($"Bucket {i}: ");
            HashNode current = table[i];
            while (current != null)
            {
                Console.Write($"[{current.Key} -> {current.Value}] ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        CustomHashMap hashMap = new CustomHashMap(10);

        hashMap.Put(1, 100);
        hashMap.Put(2, 200);
        hashMap.Put(11, 1100); // Collision (same index as 1)
        hashMap.Put(3, 300);

        Console.WriteLine("Value for key 2: " + hashMap.Get(2)); // 200
        Console.WriteLine("Value for key 11: " + hashMap.Get(11)); // 1100

        hashMap.Remove(2);
        Console.WriteLine("Value for key 2 after deletion: " + hashMap.Get(2)); // -1 (not found)

        hashMap.Display(); // Shows remaining key-value pairs
    }
}
