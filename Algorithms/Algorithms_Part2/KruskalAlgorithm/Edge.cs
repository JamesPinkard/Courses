using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruskalAlgorithm
{
    class Edge : IComparable<Edge>
    {
        public readonly LinkedListNode<Vertex> NodeA;
        public readonly LinkedListNode<Vertex> NodeB;
        public int WeightValue { get; set; }

        public Edge(LinkedListNode<Vertex> nodeA, LinkedListNode<Vertex> nodeB, int weight)
        {
            this.NodeA = nodeA;
            this.NodeB = nodeB;
            this.WeightValue = weight;
        }

        public int CompareTo(Edge other)
        {
            return WeightValue.CompareTo(other.WeightValue);
        }
    }
}
