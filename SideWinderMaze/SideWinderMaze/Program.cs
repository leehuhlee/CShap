using System;

namespace SideWinderMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Player player = new Player();

            board.Initialize(25, player);
            player.Initialize(1, 1, board);

            Console.CursorVisible = false;

            const int WAIT_TICK = 1000 / 30;
            int lastTick = 0;

            while (true)
            {
                // Frame
                int currentTick = System.Environment.TickCount;
                if (currentTick - lastTick < WAIT_TICK)
                    continue;
                int deltaTick = currentTick - lastTick;
                lastTick = currentTick;
                // Input

                // Logic
                player.Update(deltaTick);

                // Rendering
                Console.SetCursorPosition(0, 0);
                board.Render();
            }
        }
    }
}
