using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreeMaze
{
    class Board
    {
        const char CIRCLE = '\u25cf';
        public TileType[,] _tile;
        public int _size;


        public enum TileType
        {
            Empty,
            Wall,
        }

        public void GeneratedByBinaryTree(int size)
        {
            if (size % 2 == 0)
                return;

            _tile = new TileType[size, size];
            _size = size;

            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    // Make wall when x or y is enum
                    if (x % 2 == 0 || y % 2 == 0)
                        _tile[y, x] = TileType.Wall;

                    else
                        _tile[y, x] = TileType.Empty;

                }
            }

            Random rand = new Random();

            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    if (x == _size - 2 && y == _size - 2)
                        continue;

                    if (y == _size - 2)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == _size - 2)
                    {
                        _tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (rand.Next(0, 2) == 0)
                        _tile[y, x + 1] = TileType.Empty;
                    else
                        _tile[y + 1, x] = TileType.Empty;

                }
            }
        }

        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;

            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    Console.ForegroundColor = GetTileColor(_tile[y, x]);
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }
        }

        ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Green;
            }
        }
    }
}
