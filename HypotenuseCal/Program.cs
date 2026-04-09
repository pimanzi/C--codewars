using System;

namespace  HypotenuseCal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hypotenuse Calculator");
            Console.Write("Enter the length of first side of triangle: ");
            int length = int.Parse(Console.ReadLine());
            Console.Write("Enter the length of second side of triangle: ");
            int length2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"The length of hypotenuse is {Math.Sqrt(Math.Pow(length, 2) + Math.Pow(length2, 2))}");

        }
    }
    
};

