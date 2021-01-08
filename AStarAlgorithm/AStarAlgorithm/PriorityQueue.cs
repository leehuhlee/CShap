using System;
using System.Collections.Generic;
using System.Text;

namespace AStarAlgorithm
{
    class PriorityQueue<T> where T: IComparable<T>
    {
        List<T> _heap = new List<T>();

        //O(logN)
        public void Push(T data)
        {
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

            // Sort
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

        public int Count { get { return _heap.Count; } }

    }
}
