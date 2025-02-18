using System;
using System.Collections.Generic;

namespace MealPlanGenerator
{
    // Interface IMealPlan that defines basic functionality for meal plans
    public interface IMealPlan
    {
        string Name { get; set; }
        List<string> Ingredients { get; set; }
        void DisplayMealDetails();
    }

    // Vegetarian Meal class implementing IMealPlan
    public class VegetarianMeal : IMealPlan
    {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }

        public VegetarianMeal(string name)
        {
            Name = name;
            Ingredients = new List<string> { "Vegetables", "Grains", "Tofu" };
        }

        public void DisplayMealDetails()
        {
            Console.WriteLine($"[Vegetarian Meal] {Name} - Ingredients: {string.Join(", ", Ingredients)}");
        }
    }

    // Vegan Meal class implementing IMealPlan
    public class VeganMeal : IMealPlan
    {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }

        public VeganMeal(string name)
        {
            Name = name;
            Ingredients = new List<string> { "Veggies", "Fruits", "Nuts" };
        }

        public void DisplayMealDetails()
        {
            Console.WriteLine($"[Vegan Meal] {Name} - Ingredients: {string.Join(", ", Ingredients)}");
        }
    }

    // Generic class Meal<T> where T must implement IMealPlan
    public class Meal<T> where T : IMealPlan
    {
        public T MealPlan { get; set; }

        // Constructor to initialize the meal plan
        public Meal(T mealPlan)
        {
            MealPlan = mealPlan;
        }

        // Generic method to validate and display the meal plan
        public void GenerateMealPlan()
        {
            Console.WriteLine("Validating meal plan...");
            if (MealPlan != null)
            {
                MealPlan.DisplayMealDetails();
            }
            else
            {
                Console.WriteLine("Meal plan is invalid.");
            }
        }
    }

    // Main program class
    class Program
    {
        static void Main(string[] args)
        {
            // Creating meal plans for different categories
            Meal<VegetarianMeal> vegetarianMeal = new Meal<VegetarianMeal>(new VegetarianMeal("Vegetarian Pasta"));
            Meal<VeganMeal> veganMeal = new Meal<VeganMeal>(new VeganMeal("Vegan Salad"));

            // Generating meal plans
            vegetarianMeal.GenerateMealPlan();
            veganMeal.GenerateMealPlan();
        }
    }
}