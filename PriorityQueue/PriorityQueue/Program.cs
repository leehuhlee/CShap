using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace PriorityQueue
{
    class PriorityQueue<T> where T: IComparable<T>
    {
        List<T> _heap = new List<T>();

        // O(logN)
        public void Push(T data)
        {
            // Add new data on end
            _heap.Add(data);

            int now = _heap.Count - 1;

            // Start
            while (now > 0)
            {
                // Try
                int next = (now - 1) / 2;
                if (_heap[now].CompareTo(_heap[next]) < 0)
                    break;

                // Change
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                // Change check location
                now = next;
            }
        }

        // O(logN)
        public T Pop()
        {
            // Save return data
            T ret = _heap[0];

            // Move last data to root
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            // Reverse
            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;
                // If left is bigger than now, move left
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;
                // If right is bigger than now, move right
                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;

                // If left/right is smaller than now, stop
                if (next == now)
                    break;

                // change
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                // change check location
                now = next;
            }

            return ret;
        }

        public int Count()
        {
            return _heap.Count;
        }
    }

    class Knight : IComparable<Knight>
    {
        public int Id { get; set; }

        public int CompareTo([AllowNull] Knight other)
        {
            if (Id == other.Id)
                return 0;
            return Id > other.Id ? 1 : -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<Knight> q = new PriorityQueue<Knight>();
            q.Push(new Knight(){ Id = 20 });
            q.Push(new Knight() { Id = 10 });
            q.Push(new Knight() { Id = 30 });
            q.Push(new Knight() { Id = 90 });
            q.Push(new Knight() { Id = 40 });

            while(q.Count() > 0)
            {
                Console.WriteLine(q.Pop().Id);
            }

        }
    }
}
