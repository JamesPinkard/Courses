using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_ShortestPath
{
    class HeapQueue<T> where T : IComparable<T>
    {
        private List<T> _baseHeap;

        public int Count { get { return _baseHeap.Count; } }

        public HeapQueue()
        {
            this._baseHeap = new List<T>();
        }

        public HeapQueue(IEnumerable<T> queueList)
        {
            _baseHeap = queueList.ToList<T>();
            Heapify();
        }

        public void Insert(T num)
        {
            int length = _baseHeap.Count;
            _baseHeap.Add(num);
            BubbleUp(length);
        }

        public T PopMin()
        {
            T min = GetMin();
            DeleteMin();
            return min;
        }

        public void Heapify()
        {
            int length = _baseHeap.Count;
            for (int i = length - 1; i >= 0; i--)
            {
                BubbleDown(i);
            }
        }

        public void BubbleUp(int index)
        {
            if (index == 0)
            {
                return;
            }

            int parentIndex = (index - 1) / 2;

            if (_baseHeap[parentIndex].CompareTo(_baseHeap[index]) == 1)
            {
                T temp = _baseHeap[parentIndex];
                _baseHeap[parentIndex] = _baseHeap[index];
                _baseHeap[index] = temp;
                BubbleUp(parentIndex);
            }
        }

        public void BubbleDown(int index)
        {
            int length = _baseHeap.Count;
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            if (leftChildIndex >= length)
            {
                return; // index is a leaf
            }

            int minIndex = index;


            if (_baseHeap[index].CompareTo(_baseHeap[leftChildIndex]) == 1)
            {
                minIndex = leftChildIndex;
            }

            if ((rightChildIndex < length) && (_baseHeap[minIndex].CompareTo(_baseHeap[rightChildIndex]) == 1))
            {
                minIndex = rightChildIndex;
            }

            if (minIndex != index)
            {
                // need to swap
                T temp = _baseHeap[index];
                _baseHeap[index] = _baseHeap[minIndex];
                _baseHeap[minIndex] = temp;
                BubbleDown(minIndex);
            }
        }
        
        private T GetMin()
        {
            return _baseHeap[0];
        }

        private void DeleteMin()
        {
            int length = _baseHeap.Count;

            if (length == 0)
            {
                return;
            }

            _baseHeap[0] = _baseHeap[length - 1];
            _baseHeap.RemoveAt(length - 1);

            BubbleDown(0);
        }
        
    }
}
