using System;
using System.Collections.Generic;
using System.Linq;

namespace PathFinder03
{
    public class Finder
    {
        public static int INF = int.MaxValue;

        public static int PathFinder(string maze)
        {
            var field = maze.Split('\n').Select(s => s.Select(c => Int32.Parse(c.ToString())).ToArray()).ToArray();
            field = field.Select(r => (r.Length < field[field.Length - 1].Length) ? r.Concat(Enumerable.Repeat(field[0].Last(), (field[field.Length - 1].Length - r.Length))).ToArray() : r.ToArray()).ToArray();
            return dijkstra(field, (0, 0), (field[field.Length - 1].Length - 1, field.Length - 1));
        }

        private static int dijkstra(int[][] field, (int x, int y) startPos, (int x, int y) endPos)
        {
            Func<(int x, int y), IEnumerable<(int x, int y)>> getNig = 
                pos => new (int x, int y)[] { (pos.x - 1, pos.y), (pos.x + 1, pos.y),(pos.x, pos.y - 1), (pos.x, pos.y + 1)}
                        .Where(p => p.y >= 0 && p.y < field.Length && p.x >= 0 && p.x < field[p.y].Length);

            var dist = new Dictionary<(int x, int y), int>();

            for (int y = 0; y < field.Length; y++)
                for (int x = 0; x < field[y].Length; x++)
                    dist[(x, y)] = INF;

            dist[(0, 0)] = 0;

            var Q = new SortedList<(int x, int y), int>();
            Q.Add((0, 0), 0);
            while (Q.Count > 0)
            {
                var v = Q.First();
                Q.Remove(v.Key);

                foreach (var node in getNig(v.Key))
                {
                    var alt = dist[v.Key] + Math.Abs(field[v.Key.y][v.Key.x] - field[node.y][node.x]);
                    if (alt < dist[node])
                    {
                        Q.Remove(node);
                        dist[node] = alt;
                        Q.Add(node, alt);
                    }
                }
            }
            return dist[endPos];
        }
    }
}
