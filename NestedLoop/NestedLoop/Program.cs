using System;
using System.Collections.Generic;

namespace NestedLoop
{
    class Player
    {
        public int playerId;
    }

    class Salary
    {
        public int playerId;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            // N
            List<Player> players = new List<Player>();
            for(int i=0; i<1000; i++)
            {
                if (rand.Next(0, 2) == 0)
                    continue;

                players.Add(new Player() { playerId = i });
            }

            /* N
            List<Salary> salaries = new List<Salary>();
            for (int i = 0; i < 1000; i++)
            {
                if (rand.Next(0, 2) == 0)
                    continue;

                salaries.Add(new Salary() { playerId = i });
            }
            ////////////////////////////////////////////////*/
            Dictionary<int, Salary> salaries = new Dictionary<int, Salary>();
            for (int i = 0; i < 1000; i++)
            {
                if (rand.Next(0, 2) == 0)
                    continue;

                salaries.Add(i, new Salary() { playerId = i });
            }

                // Nested Loop
                List<int> result = new List<int>();
            foreach (Player p in players)
            {
                /* foreach(Salary s in salaries)
                {
                    if(s.playerId == p.playerId)
                    {
                        result.Add(p.playerId);
                        break;
                    }
                } */

                Salary s = null;
                if (salaries.TryGetValue(p.playerId, out s))
                {
                    result.Add(p.playerId);
                    if (result.Count == 5)
                        break;
                }
                    
            }
        }
    }
}
