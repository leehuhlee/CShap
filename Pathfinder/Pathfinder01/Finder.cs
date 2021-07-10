using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinder01
{
    public class Finder
    {
        public class Pos
        {
            public int x;
            public int y;
            public Pos(int x, int y) { this.x = x; this.y = y; }
            public Pos[] neighbours() 
            { 
                return new Pos[] { new Pos(x - 1, y), new Pos(x + 1, y), new Pos(x, y - 1), new Pos(x, y + 1) }; // left, right, up. down
            }
            public bool onPath(char[][] g) 
            { 
                return x >= 0 && x < g[0].Length && y >= 0 && y < g.Length && g[y][x] == '.';  // check barrier
            }
        }
        
        public static bool PathFinder(string maze)
        {
            string[] rows = maze.Split("\n");
            char[][] grid = new char[rows.Length][];
            for (int i = 0; i < rows.Length; i++) 
                grid[i] = rows[i].ToCharArray();
            return findExit(new Pos(0, 0), grid); // start point is (0,0)
        }

        public static bool findExit(Pos p, char[][] g)
        {
            if (p.x == g.Length - 1 && p.x == p.y) // return true if size is 1
                return true;
            if (!p.onPath(g)) 
                return false; // return false if current position is not on path
            g[p.y][p.x] = 'V'; // check visited
            Pos[] n = p.neighbours();
            return findExit(n[0], g) || findExit(n[1], g) || findExit(n[2], g) || findExit(n[3], g);
        }
    }
}
