using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQRPG
{
    public enum ClassType
    {
        Knight,
        Archer,
        Mage
    }
    public class Player
    {
        public ClassType ClassType { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public List<int> item { get; set; } = new List<int>();
    }
    class Program
    {
        static List<Player> _players = new List<Player>();
        
        static void Main(string[] args)
        {
            Random rand = new Random();

            for(int i=0; i<100; i++)
            {
                ClassType type = ClassType.Knight;
                switch (rand.Next(0, 3))
                {
                    case 0:
                        type = ClassType.Knight;
                        break;
                    case 1:
                        type = ClassType.Archer;
                        break;
                    case 2:
                        type = ClassType.Mage;
                        break;
                }

                Player player = new Player
                {
                    ClassType = type,
                    Level = rand.Next(0, 100),
                    Hp = rand.Next(100, 1000),
                    Attack = rand.Next(5, 50)
                };

                for (int j = 0; j < 5; j++)
                    player.item.Add(rand.Next(0, 100));

                _players.Add(player);
            }

            // 1. C# /////////////////////////////////////////
            {
                List<Player> players = GetHightLevelKnights();
                foreach (Player p in players)
                {
                    Console.WriteLine($"{p.Level} {p.Hp}");
                }
            }
            //////////////////////////////////////////////////
            
            Console.WriteLine();

            // 2. LINQ ///////////////////////////////////////
            {
                var players =
                    from p in _players
                    where p.ClassType == ClassType.Knight && p.Level >= 50
                    orderby p.Level
                    select p;

                foreach (Player p in players)
                {
                    Console.WriteLine($"{p.Level} {p.Hp}");
                }
            }

            {
                var playerItems =
                    from p in _players
                    from i in p.item
                    where i < 30
                    select new { p, i };

                var li = playerItems.ToList();
            }

            {
                var playerByLevel =
                    from p in _players
                    group p by p.Level into g
                    orderby g.Key
                    select new { g.Key, Players = g };
            }

            {
                List<int> levels = new List<int>() { 1, 5, 10 };
                var playerLevels = 
                    from p in _players
                    join l in levels
                    on p.Level equals l
                    select p;
            }

            {
                var players =
                    from p in _players
                    where p.ClassType == ClassType.Knight && p.Level >= 50
                    orderby p.Level ascending
                    select p;

                var players2 = _players
                    .Where(p => p.ClassType == ClassType.Knight && p.Level >= 50)
                    .OrderBy(p => p.Level)
                    .Select(p => p);
            }
            //////////////////////////////////////////////////
        }

        static public List<Player> GetHightLevelKnights()
        {
            List<Player> players = new List<Player>();

            foreach(Player player in _players)
            {
                if (player.ClassType != ClassType.Knight)
                    continue;
                if (player.Level < 50)
                    continue;

                players.Add(player);
            }

            players.Sort((lhs, rhs) => { return lhs.Level - rhs.Level; });

            return players;
        }
    }
}
