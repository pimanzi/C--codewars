using System;

namespace GuessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Guess Number, Guess a number between 1 and 10");
            Random rand = new Random();
            int number = rand.Next(1,11);
            Console.Write("Guess: ");
            bool checkInput = int.TryParse(Console.ReadLine(), out int userResult);
            
            while (userResult !=number)
            {
                if (!checkInput)
                {
                    Console.WriteLine("Please enter a number between 1 and 10: ");
                }
                else if (userResult < number)
                {
                    Console.WriteLine("The number is below the correct number");
                }
                else
                {
                    Console.WriteLine("The number is above the correct number");
                }
                Console.Write("Guess: ");
                checkInput = int.TryParse(Console.ReadLine(), out userResult);
            }
            
            Console.WriteLine($"Congratulations! the correct number is {userResult}");
            
            

        }
    }
}

