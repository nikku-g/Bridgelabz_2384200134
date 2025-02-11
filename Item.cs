using System;
using System.Collections.Generic;

public class Item
{
    public string ItemName { get; set; }
    public int ItemID { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public Item(string itemName, int itemID, int quantity, double price)
    {
        ItemName = itemName;
        ItemID = itemID;
        Quantity = quantity;
        Price = price;
    }
}


public class Node
{
    public Item Data;
    public Node Next;

    public Node(Item data)
    {
        Data = data;
        Next = null;
    }
}


public class Inventory
{
    private Node head;

    public Inventory()
    {
        head = null;
    }

    // Add an item at the beginning
    public void AddAtBeginning(Item item)
    {
        Node newNode = new Node(item);
        newNode.Next = head;
        head = newNode;
    }

    // Add an item at the end
    public void AddAtEnd(Item item)
    {
        Node newNode = new Node(item);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
        }
    }

    // Add an item at a specific position
    public void AddAtPosition(Item item, int position)
    {
        Node newNode = new Node(item);
        if (position == 0)
        {
            AddAtBeginning(item);
            return;
        }

        Node temp = head;
        for (int i = 0; temp != null && i < position - 1; i++)
        {
            temp = temp.Next;
        }

        if (temp == null)
        {
            Console.WriteLine("Position is out of bounds.");
            return;
        }

        newNode.Next = temp.Next;
        temp.Next = newNode;
    }

    // Remove an item by Item ID
    public void RemoveByItemID(int itemID)
    {
        if (head == null)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        // If head node itself holds the Item ID
        if (head.Data.ItemID == itemID)
        {
            head = head.Next;
            Console.WriteLine($"Item with Item ID {itemID} has been removed.");
            return;
        }

        // Search for item in the list
        Node current = head;
        while (current.Next != null && current.Next.Data.ItemID != itemID)
        {
            current = current.Next;
        }

        if (current.Next == null)
        {
            Console.WriteLine("Item not found.");
        }
        else
        {
            current.Next = current.Next.Next;
            Console.WriteLine($"Item with Item ID {itemID} has been removed.");
        }
    }

    // Update the quantity of an item by Item ID
    public void UpdateQuantity(int itemID, int newQuantity)
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.Data.ItemID == itemID)
            {
                temp.Data.Quantity = newQuantity;
                Console.WriteLine($"Quantity for Item ID {itemID} updated to {newQuantity}.");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Item not found.");
    }

    // Search for an item by Item ID or Item Name
    public void SearchItem(string searchTerm)
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.Data.ItemID.ToString() == searchTerm || temp.Data.ItemName.Equals(searchTerm, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Item found: ID: {temp.Data.ItemID}, Name: {temp.Data.ItemName}, Quantity: {temp.Data.Quantity}, Price: {temp.Data.Price}");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Item not found.");
    }

    // Calculate and display the total value of inventory
    public void CalculateTotalValue()
    {
        double totalValue = 0;
        Node temp = head;
        while (temp != null)
        {
            totalValue += temp.Data.Price * temp.Data.Quantity;
            temp = temp.Next;
        }
        Console.WriteLine($"Total value of inventory: {totalValue:C}");
    }

    // Sort the inventory based on Item Name or Price (ascending or descending)
    public void SortInventory(string sortBy, bool ascending = true)
    {
        if (head == null || head.Next == null)
        {
            return; // List is already sorted or empty
        }

        bool swapped;
        do
        {
            swapped = false;
            Node current = head;
            while (current.Next != null)
            {
                bool condition = false;
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    condition = ascending ? string.Compare(current.Data.ItemName, current.Next.Data.ItemName) > 0 :
                        string.Compare(current.Data.ItemName, current.Next.Data.ItemName) < 0;
                }
                else if (sortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    condition = ascending ? current.Data.Price > current.Next.Data.Price : current.Data.Price < current.Next.Data.Price;
                }

                if (condition)
                {
                    // Swap the data
                    Item tempItem = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = tempItem;
                    swapped = true;
                }
                current = current.Next;
            }
        } while (swapped);
        Console.WriteLine($"Inventory sorted by {sortBy} in {(ascending ? "ascending" : "descending")} order.");
    }

    // Display all items in the inventory
    public void DisplayAllItems()
    {
        if (head == null)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        Node temp = head;
        Console.WriteLine("Inventory List:");
        while (temp != null)
        {
            Console.WriteLine($"Item ID: {temp.Data.ItemID}, Name: {temp.Data.ItemName}, Quantity: {temp.Data.Quantity}, Price: {temp.Data.Price:C}");
            temp = temp.Next;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        Inventory inventory = new Inventory();

        // Add items to the inventory
        inventory.AddAtEnd(new Item("Laptop", 101, 50, 799.99));
        inventory.AddAtEnd(new Item("Smartphone", 102, 200, 499.99));
        inventory.AddAtBeginning(new Item("Headphones", 100, 150, 99.99));

        // Display all items
        Console.WriteLine("Displaying all items:");
        inventory.DisplayAllItems();

        // Update quantity of an item
        Console.WriteLine("\nUpdating quantity of item ID 101 to 60:");
        inventory.UpdateQuantity(101, 60);

        // Search for an item by name
        Console.WriteLine("\nSearching for 'Smartphone':");
        inventory.SearchItem("Smartphone");

        // Calculate total value of inventory
        Console.WriteLine("\nCalculating total value of inventory:");
        inventory.CalculateTotalValue();

        // Remove an item by Item ID
        Console.WriteLine("\nRemoving item with Item ID 102:");
        inventory.RemoveByItemID(102);

        // Display all items after removal
        Console.WriteLine("\nDisplaying all items after removal:");
        inventory.DisplayAllItems();

        // Sort inventory by Price in descending order
        Console.WriteLine("\nSorting inventory by Price (descending):");
        inventory.SortInventory("Price", false);
        inventory.DisplayAllItems();

        // Sort inventory by Name in ascending order
        Console.WriteLine("\nSorting inventory by Name (ascending):");
        inventory.SortInventory("Name", true);
        inventory.DisplayAllItems();
    }
}
