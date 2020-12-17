using System;

namespace TextRPG
{
    class Program
    {
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Magicion = 3

        }

        struct Player
        {
            public int hp;
            public int attack;
        }

        enum MonsterType
        {
            None = 0,
            Slime = 1,
            Orc = 2,
            Skeleton = 3
        }

        struct Monster
        {
            public int hp;
            public int attack;
        }

        static ClassType ChooseClass()
        {
            Console.WriteLine("Select your position!");
            Console.WriteLine("[1] Knight");
            Console.WriteLine("[2] Archer");
            Console.WriteLine("[3] Magicion");

            ClassType choice = ClassType.None;
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    choice = ClassType.Knight;
                    break;
                case "2":
                    choice = ClassType.Archer;
                    break;
                case "3":
                    choice = ClassType.Magicion;
                    break;
            }

            return choice;
        }

        static void CreatePlayer(ClassType choice, out Player player)
        {
            // Knight(100/10) Archer(75/12) magicion(50/15)
            switch (choice)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.Archer:
                    player.hp = 75;
                    player.attack = 12;
                    break;
                case ClassType.Magicion:
                    player.hp = 50;
                    player.attack = 15;
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
        }

        static void CreateRandomMonster(out Monster monster)
        {

            Random rand = new Random();
            int randMonster = rand.Next(1, 4);

            switch (randMonster)
            {
                case (int)MonsterType.Slime:
                    monster.hp = 20;
                    monster.attack = 2;
                    Console.WriteLine("Slime is responed!");
                    break;
                case (int)MonsterType.Orc:
                    monster.hp = 40;
                    monster.attack = 4;
                    Console.WriteLine("Orc is responed!");
                    break;
                case (int)MonsterType.Skeleton:
                    monster.hp = 30;
                    monster.attack = 3;
                    Console.WriteLine("Skeleton is responed!");
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
        }

        static void Fight(ref Player player, ref Monster monster)
        {
            while (true)
            {
                // Player attacks monster
                monster.hp -= player.attack;
                if (monster.hp <= 0)
                {
                    Console.WriteLine("You Win! :)");
                    Console.WriteLine($"Your hp : {player.hp}");
                    break;
                }

                // Monster attacks player
                player.hp -= monster.attack;
                if (player.hp <= 0)
                {
                    Console.WriteLine("You Lose! :(");
                    break;
                }
            }
        }

        static void EnterField(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("You entered field!");

                // Create Monster
                Monster monster;

                // Respon one monster among 3 random monsters
                CreateRandomMonster(out monster);

                Console.WriteLine("[1] Change Battle Mode");
                Console.WriteLine("[2] Run away to town with a certain chance");

                String input = Console.ReadLine();
                if (input == "1")
                {
                    Fight(ref player, ref monster);
                }
                else if (input == "2")
                {
                    // Run away chance: 33%
                    Random rand = new Random();
                    int randValue = rand.Next(0, 101);
                    if (randValue <= 33)
                    {
                        Console.WriteLine("You successed to run away!");
                        break;
                    }
                    else
                    {
                        Fight(ref player, ref monster);
                    }
                }
            }
        }

        static void EnterGame(ref Player player)
        {
            while (true)
            {
                Console.WriteLine("You entered town!");
                Console.WriteLine("[1] Go to field.");
                Console.WriteLine("[2] Return to lobby.");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    EnterField(ref player);
                }
                else if (input == "2")
                {
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                ClassType choice = ChooseClass();
                if (choice == ClassType.None)
                    continue;

                // Create Player
                Player player;
                CreatePlayer(choice, out player);
                // Go to field and fight with monster
                EnterGame(ref player);
            }
        }
    }
}
