using System;

namespace RockScissorsPaper
{
    class Program
    {
        static void Main(string[] args)
        {

            Random rand = new Random();
            int aiChoice = rand.Next(0, 3);

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    Console.WriteLine("Your choice is rock.");
                    break;
                case 1:
                    Console.WriteLine("Your choice is scissors.");
                    break;
                case 2:
                    Console.WriteLine("Your choice is paper.");
                    break;
            }

            switch (aiChoice)
            {
                case 0:
                    Console.WriteLine("AI choice is rock.");
                    break;
                case 1:
                    Console.WriteLine("AI choice is scissors.");
                    break;
                case 2:
                    Console.WriteLine("AI choice is paper.");
                    break;
            }

            if(choice == 0)
            {
                if(aiChoice == 0)
                {
                    Console.WriteLine("Draw :|");
                }
                else if(aiChoice == 1)
                {
                    Console.WriteLine("Win :)");
                }
                else
                {
                    Console.WriteLine("Lose :(");
                }
            }
            else if(choice == 1)
            {
                if (aiChoice == 0)
                {
                    Console.WriteLine("Lose :(");
                }
                else if (aiChoice == 1)
                {
                    Console.WriteLine("Draw :|");
                }
                else
                {
                    Console.WriteLine("Win :)");
                }
            }
            else
            {
                if (aiChoice == 0)
                {
                    Console.WriteLine("Win :)");
                }
                else if (aiChoice == 1)
                {
                    Console.WriteLine("Lose :(");
                }
                else
                {
                    Console.WriteLine("Draw :|");
                }
            }
        }
    }
}
