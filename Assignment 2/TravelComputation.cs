using System;

class TravelComputaion
{
    static void Main()
    {
        Console.Write("enter your name: ");
        string name = Console.ReadLine();

        Console.Write("enter your departure city: ");
        string fromCity = Console.ReadLine();

        Console.Write("enter the city via you will pass: ");
        string viaCity = Console.ReadLine();

        Console.Write("enter your final destination city: ");
        string toCity = Console.ReadLine();

        Console.Write("enter the distance from " + fromCity + " to " + viaCity + " in miles: ");
        double fromToVia = Convert.ToDouble(Console.ReadLine());

        Console.Write("enter the distance from " + viaCity + " to " + toCity + " in miles: ");
        double viaToFinalCity = Convert.ToDouble(Console.ReadLine());

        Console.Write("enter the time taken in the journey in hours: ");
        double timeTaken = Convert.ToDouble(Console.ReadLine());

        double totalDistance = fromToVia + viaToFinalCity; 

        Console.WriteLine("The results of the trip are: {0}, traveling from {1} to {2} to {3}, covering a total distance of {4} miles.", name, fromCity, viaCity, toCity, totalDistance);
    }
}
