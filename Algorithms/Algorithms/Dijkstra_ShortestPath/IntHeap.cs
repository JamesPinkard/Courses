using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_ShortestPath
{
    class IntHeap
    {
        private List<int> _baseHeap;
        public int Count { get { return _baseHeap.Count; } }

        public IntHeap()
        {
            this._baseHeap = new List<int>();
        }

        public IntHeap(IEnumerable<int> queueList)
        {
            _baseHeap = queueList.ToList<int>();
            Heapify();
        }

        public void Insert(int num)
        {
            int length = _baseHeap.Count;
            _baseHeap.Add(num);
            BubbleUp(length);
        }

        public int PopMin()
        {
            int min = GetMin();
            DeleteMin();
            return min;
        }

        private int GetMin()
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

        public void Heapify()
        {
            int length = _baseHeap.Count;
            for (int i = length - 1; i >= 0; i--)
            {
                BubbleDown(i);
            }
        }
        
        private void BubbleUp(int index)
        {
            if (index == 0)
            {
                return;
            }

            int parentIndex = (index - 1) / 2;

            if (_baseHeap[parentIndex] > _baseHeap[index])
            {
                int temp = _baseHeap[parentIndex];
                _baseHeap[parentIndex] = _baseHeap[index];
                _baseHeap[index] = temp;
                BubbleUp(parentIndex);
            }
        }
        
        private void BubbleDown(int index)
        {
            int length = _baseHeap.Count;
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            if (leftChildIndex >= length)
            {
                return; // index is a leaf
            }

            int minIndex = index;

            
            if (_baseHeap[index] > _baseHeap[leftChildIndex])
            {
                minIndex = leftChildIndex;
            }

            if ((rightChildIndex < length) && (_baseHeap[minIndex] > _baseHeap[rightChildIndex]))
            {
                minIndex = rightChildIndex;
            }

            if (minIndex != index)
            {
                // need to swap
                int temp = _baseHeap[index];
                _baseHeap[index] = _baseHeap[minIndex];
                _baseHeap[minIndex] = temp;
                BubbleDown(minIndex);
            }
        }
    }
}
