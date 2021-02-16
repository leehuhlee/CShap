using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MergeJoin
{
    class Player : IComparable<Player>
    {
        public int playerId;

        public int CompareTo(Player other)
        {
            if (playerId == other.playerId)
                return 0;
            return (playerId > other.playerId) ? 1 : -1;
        }
    }

    class Salary : IComparable<Salary>
    {
        public int playerId;

        public int CompareTo(Salary other)
        {
            if (playerId == other.playerId)
                return 0;
            return (playerId > other.playerId) ? 1 : -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            players.Add(new Player() { playerId = 0 });
            players.Add(new Player() { playerId = 9 });
            players.Add(new Player() { playerId = 1 });
            players.Add(new Player() { playerId = 3 });
            players.Add(new Player() { playerId = 4 });

            List<Salary> salaries = new List<Salary>();
            salaries.Add(new Salary() { playerId = 0 });
            salaries.Add(new Salary() { playerId = 5 });
            salaries.Add(new Salary() { playerId = 0 });
            salaries.Add(new Salary() { playerId = 2 });
            salaries.Add(new Salary() { playerId = 9 });

            // Step 1) Sort (if already sorted, SKIP)
            // O(N * Log(N))
            players.Sort();
            salaries.Sort();

            // One-To-Many(players is unique)
            // Step 2) Merge
            // outer [0,1,3,4,9]
            // inner [0,0,2,5,9]

            int p = 0;
            int s = 0;

            List<int> result = new List<int>();

            // O(N+M)
            while (p<players.Count && s<salaries.Count)
            {
                if(players[p].playerId == salaries[s].playerId)
                {
                    result.Add(players[p].playerId);
                    s++;
                }
                else if(players[p].playerId < salaries[s].playerId)
                {
                    p++;
                }
                else
                {
                    s++;
                }
            }

            // Many-To-Many(Player is not unique)
            // outer [0,0,0,0,0] -> N
            // inner [0,0,0,0,0] -> N
            // O(N+M)


        }
    }
}
