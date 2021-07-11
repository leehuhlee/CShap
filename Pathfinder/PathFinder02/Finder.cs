using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PathFinder02
{
    public class Finder
    {
        private static int INF = int.MaxValue;
        private static int[][] graph;

        public static int PathFinder(string maze)
        {
            InitGraph(maze);
            GoTo(0, 0, 0);
            return (graph[graph.Length - 1][graph.Length - 1] == INF) ? -1 : graph[graph.Length - 1][graph.Length - 1];
        }

        private static void InitGraph(string maze)
        {
            string[] lines = maze.Split("\n");
            graph = new int[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                graph[i] = new int[lines.Length];
                for (int j = 0; j < lines.Length; j++)
                {
                    graph[i][j] = (lines[i][j] == 'W') ? -1 : INF;
                }
            }
        }

        private static void GoTo(int i, int j, int step)
        {
            if (i == -1 || i == graph.Length || j == -1 || j == graph.Length || graph[i][j] <= step)
                return;

            graph[i][j] = step;

            GoTo(i, j - 1, step + 1);
            GoTo(i, j + 1, step + 1);
            GoTo(i + 1, j, step + 1);
            GoTo(i - 1, j, step + 1);
        }
    }
}
