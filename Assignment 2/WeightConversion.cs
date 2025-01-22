using System;

class WeightConversion
{
    static void Main()
    {
        Console.Write("Enter the weight in pounds: ");
        double weightInPounds = Convert.ToDouble(Console.ReadLine());

        double poundsToKg = 2.2;

        double weightInKg = weightInPounds * poundsToKg;

        Console.WriteLine("The weight of the person in pounds is {0} and in kg is {1}", weightInPounds, weightInKg);
    }
}
