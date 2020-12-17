using System;

namespace RockScissorsPaper
{
    enum Choice
    {
        Rock = 0,
        Scissors = 1,
        Paper = 2
    }

    class Program
    {
        static void Main(string[] args)
        {

            Random rand = new Random();
            int aiChoice = rand.Next(0, 3);

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case (int)Choice.Rock:
                    Console.WriteLine("Your choice is rock.");
                    break;
                case (int)Choice.Scissors:
                    Console.WriteLine("Your choice is scissors.");
                    break;
                case (int)Choice.Paper:
                    Console.WriteLine("Your choice is paper.");
                    break;
            }

            switch (aiChoice)
            {
                case (int)Choice.Rock:
                    Console.WriteLine("AI choice is rock.");
                    break;
                case (int)Choice.Scissors:
                    Console.WriteLine("AI choice is scissors.");
                    break;
                case (int)Choice.Paper:
                    Console.WriteLine("AI choice is paper.");
                    break;
            }

            if(choice == (int)Choice.Rock)
            {
                if(aiChoice == (int)Choice.Rock)
                {
                    Console.WriteLine("Draw :|");
                }
                else if(aiChoice == (int)Choice.Scissors)
                {
                    Console.WriteLine("Win :)");
                }
                else
                {
                    Console.WriteLine("Lose :(");
                }
            }
            else if(choice == (int)Choice.Scissors)
            {
                if (aiChoice == (int)Choice.Rock)
                {
                    Console.WriteLine("Lose :(");
                }
                else if (aiChoice == (int)Choice.Scissors)
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
                if (aiChoice == (int)Choice.Rock)
                {
                    Console.WriteLine("Win :)");
                }
                else if (aiChoice == (int)Choice.Scissors)
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
