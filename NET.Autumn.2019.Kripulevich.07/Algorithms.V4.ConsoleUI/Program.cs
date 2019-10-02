using System;
using Algorithms.V4.StaticClasses;

namespace Algorithms.V4.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the integers with a space for calculating GCD:");

            string sNumbers = Console.ReadLine();
            string[] str = sNumbers.Split(' ');
            int[] numbers = new int[str.Length];
            int i = 0;

            foreach (string s in str)
            {
                numbers[i++] = int.Parse(s);
            }

            int result = GCDAlgorithms.FindGcdByEuclidean(numbers[0], numbers[1]);

            Console.WriteLine($"GCD: {result}.");
            Console.WriteLine($"Algorithms time: " +
                $"{GCDAlgorithms.timeDecorator.TimeInMilliseconds} milliseconds");

            Console.ReadKey();
        }
    }
}
