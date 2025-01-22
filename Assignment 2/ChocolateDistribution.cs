using System;

class ChocolateDistribution
{
    static void Main()
    {
        Console.Write("enter the number of chocolates : ");
        int numberOfChocolates = Convert.ToInt32(Console.ReadLine());

        Console.Write("enter the number of children : ");
        int numberOfChildren = Convert.ToInt32(Console.ReadLine());

        int chocolatesPerChild = numberOfChocolates / numberOfChildren;
        int remainingChocolates = numberOfChocolates % numberOfChildren;

        Console.WriteLine("The number of chocolates each child gets is {0} and the number of remaining chocolates is {1}", chocolatesPerChild, remainingChocolates);
    }
}
