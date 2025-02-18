using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Generics
{
    abstract class WarehouseItem
    {
        public string name { get; set; }
        public double price { get; set; }

        public WarehouseItem(string name,double price)
        {
            this.name = name;
            this.price = price;
        }

        public abstract void ShowDetails();

    }

    class Electronics : WarehouseItem
    {
        public string brand { get; set; }
        public Electronics(string name, double price, string brand) : base(name, price)
        {
            this.brand = brand;
        }
        public override void ShowDetails()
        {
            Console.WriteLine($"[Electronics] {name} - {brand} - ${price}");
        }
    }

    class Groceries : WarehouseItem
    {
        public string expiryDate { get; set; }
        public Groceries(string name, double price, string expiryDate) : base(name, price)
        {
            this.expiryDate = expiryDate;
        }

        public override void ShowDetails()
        {
            Console.WriteLine($"[Groceries] {name} - Expiry: {expiryDate} - ${price}");
        }
    }

    class Furniture : WarehouseItem
    {
        public string material { get; set; }
        public Furniture(string name, double price, string material) : base(name, price)
        {
            this.material = material;
        }

        public override void ShowDetails()
        {
            Console.WriteLine($"[Furniture] {name} - Material: {material} - ${price}");
        }
    }

    class Storage<T> where T : WarehouseItem
    {
        private List<T> items = new List<T>();

        public void AddItem(T item)
        {
            items.Add(item);
        }

        public void DisplayAllItems()
        {
            Console.WriteLine("\nWarehouse Inventory:");
            foreach (var item in items)
            {
                item.ShowDetails();
            }
        }
    }

    class Program1
    {
        static void Main()
        {
            Storage<Electronics> electronicsStorage = new Storage<Electronics>();
            Storage<Groceries> groceriesStorage = new Storage<Groceries>();
            Storage<Furniture> furnitureStorage = new Storage<Furniture>();

            electronicsStorage.AddItem(new Electronics("Laptop", 1200, "Dell"));
            electronicsStorage.AddItem(new Electronics("Smartphone", 800, "Samsung"));

            groceriesStorage.AddItem(new Groceries("Milk", 3, "2025-01-10"));
            groceriesStorage.AddItem(new Groceries("Bread", 2, "2024-02-20"));

            furnitureStorage.AddItem(new Furniture("Table", 150, "Wood"));
            furnitureStorage.AddItem(new Furniture("Chair", 80, "Plastic"));

            electronicsStorage.DisplayAllItems();
            groceriesStorage.DisplayAllItems();
            furnitureStorage.DisplayAllItems();
        }
    }

}
