using System;
using System.Collections.Generic;
using System.Text;

namespace AStarAlgorithm
{
	class Pos
	{
		public Pos(int y, int x) { Y = y; X = x; }
		public int Y;
		public int X;
	}

	class Player
	{
		public int PosY { get; private set; }
		public int PosX { get; private set; }
		Random _random = new Random();
		Board _board;

		enum Dir
		{
			Up = 0,
			Left = 1,
			Down = 2,
			Right = 3
		}

		int _dir = (int)Dir.Up;
		List<Pos> _points = new List<Pos>();

		public void Initialize(int posY, int posX, Board board)
		{
			PosY = posY;
			PosX = posX;
			_board = board;

			AStar();
		}

		struct PQNode : IComparable<PQNode>
		{
			public int F;
			public int G;
			public int Y;
			public int X;

			public int CompareTo(PQNode other)
			{
				if (F == other.F)
					return 0;
				return F < other.F ? 1 : -1;
			}
		}

		void AStar()
		{
			// U L D R UL DL DR UR
			int[] deltaY = new int[] { -1, 0, 1, 0 };
			int[] deltaX = new int[] { 0, -1, 0, 1 };
			int[] cost = new int[] { 10, 10, 10, 10 };

			// Calculate Score
			// F = G + H
			// F = Result Score (The Smaller, The better, Depends on path)
			// G = Cost to go destination from start (The Smaller, The better, Depends on path)
			// H = how close from destination (The Smaller, The better, fixed)

			// check (y, x) is closed
			bool[,] closed = new bool[_board.Size, _board.Size]; // CloseList

			// check way to go (y, x) is found
			// found X => MaxValue
			// found O => F = G + H
			int[,] open = new int[_board.Size, _board.Size]; // OpenList
			for (int y = 0; y < _board.Size; y++)
				for (int x = 0; x < _board.Size; x++)
					open[y, x] = Int32.MaxValue;

			Pos[,] parent = new Pos[_board.Size, _board.Size];

			// Among datas in Open List, choose the best nimonee fast
			PriorityQueue<PQNode> pq = new PriorityQueue<PQNode>();

			// Find Start (open)
			open[PosY, PosX] = 10 * (Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX));
			pq.Push(new PQNode() { F = 10 * (Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX)), G = 0, Y = PosY, X = PosX });
			parent[PosY, PosX] = new Pos(PosY, PosX);

			while (pq.Count > 0)
			{
				// Search the best nimonee
				PQNode node = pq.Pop();
				// Search same coordinate with several path, if it is closed by more fast path, skip
				if (closed[node.Y, node.X])
					continue;

				// Close
				closed[node.Y, node.X] = true;
				// Stop when destination
				if (node.Y == _board.DestY && node.X == _board.DestX)
					break;

				// Check coordinate is able to move, and open
				for (int i = 0; i < deltaY.Length; i++)
				{
					int nextY = node.Y + deltaY[i];
					int nextX = node.X + deltaX[i];

					// Skip if unvalid range
					if (nextX < 0 || nextX >= _board.Size || nextY < 0 || nextY >= _board.Size)
						continue;
					// Skip if wall
					if (_board.Tile[nextY, nextX] == Board.TileType.Wall)
						continue;
					// Skip if closed
					if (closed[nextY, nextX])
						continue;

					// Calculate cost
					int g = node.G + cost[i];
					int h = 10 * (Math.Abs(_board.DestY - nextY) + Math.Abs(_board.DestX - nextX));
					// If more fast way is found in other path, skip
					if (open[nextY, nextX] < g + h)
						continue;

					// Open
					open[nextY, nextX] = g + h;
					pq.Push(new PQNode() { F = g + h, G = g, Y = nextY, X = nextX });
					parent[nextY, nextX] = new Pos(node.Y, node.X);
				}
			}

			CalcPathFromParent(parent);
		}

		void CalcPathFromParent(Pos[,] parent)
		{
			int y = _board.DestY;
			int x = _board.DestX;
			while (parent[y, x].Y != y || parent[y, x].X != x)
			{
				_points.Add(new Pos(y, x));
				Pos pos = parent[y, x];
				y = pos.Y;
				x = pos.X;
			}
			_points.Add(new Pos(y, x));
			_points.Reverse();
		}

		const int MOVE_TICK = 30;
		int _sumTick = 0;
		int _lastIndex = 0;
		public void Update(int deltaTick)
		{
			if (_lastIndex >= _points.Count)
			{
				_lastIndex = 0;
				_points.Clear();
				_board.Initialize(_board.Size, this);
				Initialize(1, 1, _board);
			}

			_sumTick += deltaTick;
			if (_sumTick >= MOVE_TICK)
			{
				_sumTick = 0;

				PosY = _points[_lastIndex].Y;
				PosX = _points[_lastIndex].X;
				_lastIndex++;
			}
		}
	}
}