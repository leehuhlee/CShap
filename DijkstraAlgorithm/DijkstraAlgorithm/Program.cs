using System;
using System.Collections.Generic;

namespace DijkstraAlgorithm
{
    class Graph
    {
        int[,] adj = new int[6, 6]
        {
            { -1, 15, -1, 35, -1, -1 },
            { 15, -1, 05, 10, -1, -1 },
            { -1, 05, -1, -1, -1, -1 },
            { 35, 10, -1, -1, 05, -1 },
            { -1, -1, -1, 05, -1, 05 },
            { -1, -1, -1, -1, 05, -1 },
        };

        public void Dijkstra(int start)
        {
            bool[] visited = new bool[6];
            int[] distance = new int[6];
            int[] parent = new int[6];
            Array.Fill(distance, Int32.MaxValue);

            distance[start] = 0;
            parent[start] = 0;

            while (true)
            {
                // Find best node

                // Save distance and number who is best
                int closest = Int32.MaxValue;
                int now = -1;

                for (int i = 0; i < 6; i++)
                {
                    // Skip visited node
                    if (visited[i])
                        continue;

                    // Skip not visited or far than previous node
                    if (distance[i] == Int32.MaxValue || distance[i] >= closest)
                        continue;

                    // node is best, so update
                    closest = distance[i];
                    now = i;
                }

                // no next node -> end
                if (now == -1)
                    break;

                // visit best node
                visited[now] = true;

                // search adjacent nodes of current node, update shortest distance(depands on situation)
                for(int next = 0; next<6; next++)
                {
                    // Skip not linked node
                    if (adj[now, next] == -1)
                        continue;

                    // already visited node
                    if (visited[next])
                        continue;

                    // Calculate shortest distance of new node
                    int nextDist = distance[now] + adj[now, next];

                    // If previous shortest distance is bigger than new shortest distance, update
                    if(nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parent[next] = now;
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.Dijkstra(0);
        }
    }
}
