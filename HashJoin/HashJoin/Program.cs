using System;
using System.Collections.Generic;

namespace HashJoin
{
    class Player
    {
        public int playerId;
    }

    class Salary
    {
        public int playerId;
    }

    // 41 % 10 = 1(Key)
    // 51 % 10 = 1(Key)
    // 41? -> 1(Key)

    // HashTable [0 List][1 List][2 List][3][4][5][6][7][8][9]
    // give place, receive speed
    // same value => same Bucket(YES)
    // same Bucker => same Value(NO)

    // hanna / hannsbest123
    // hanna / Hash(hannabest123) => '123asdfiqwetlksdf23'

    class HashTable
    {
        int _bucketCount;
        List<int>[] _buckets;

        public HashTable(int bucketCount = 100)
        {
            _bucketCount = bucketCount;
            _buckets = new List<int>[bucketCount];

            for (int i = 0; i < bucketCount; i++)
                _buckets[i] = new List<int>();

        }

        public void Add(int value)
        {
            int key = value % _bucketCount;
            _buckets[key].Add(value);
        }

        public bool Find(int value)
        {
            int key = value % _bucketCount;
            // _buckets[key].Contains(value);
            foreach(int v in _buckets[key])
            {
                if (v == value)
                    return true;
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            List<Player> players = new List<Player>();
            for (int i = 0; i < 1000; i++)
            {
                if (rand.Next(0, 2) == 0)
                    continue;

                players.Add(new Player() { playerId = i });
            }

            List<Salary> salaries = new List<Salary>();
            for (int i = 0; i < 1000; i++)
            {
                if (rand.Next(0, 2) == 0)
                    continue;

                salaries.Add(new Salary() { playerId = i });
            }

            // TEMP HashTable
            /*Dictionary<int, Salary> hash = new Dictionary<int, Salary>();       
            foreach (Salary s in salaries)
                hash.Add(s.playerId, s);

            List<int> result = new List<int>();
            foreach(Player p in players)
            {
                if (hash.ContainsKey(p.playerId))
                    result.Add(p.playerId);
            }*/

            HashTable hash = new HashTable();
            foreach (Salary s in salaries)
                hash.Add(s.playerId);

            List<int> result = new List<int>();
            foreach(Player p in players)
            {
                if (hash.Find(p.playerId))
                    result.Add(p.playerId);
            }
        }
    }
}
