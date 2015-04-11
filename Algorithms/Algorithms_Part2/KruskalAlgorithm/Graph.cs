using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace KruskalAlgorithm
{
    class Graph
    {
        public List<Edge> listEdges = new List<Edge>();
        public List<Vertex> listVertices = new List<Vertex>();

        public void AddVertex(Vertex v)
        {
            listVertices.Add(v);
        }

        public void AddEdge(LinkedListNode<Vertex> nodeX, LinkedListNode<Vertex> nodeY, int weight)
        {           
            Edge e = new Edge(nodeX, nodeY, weight);
            listEdges.Add(e);
        }

        

        public void SortEdges()
        {
            listEdges.Sort();
        }

        public LinkedListNode<Vertex> FindSet(LinkedListNode<Vertex> v)
        {
            LinkedList<Vertex> mySet = v.List;
            LinkedListNode<Vertex> setHead = mySet.First;
            return setHead;
        }

        public bool IsCycle(LinkedListNode<Vertex> x, LinkedListNode<Vertex> y)
        {
            return FindSet(x) == FindSet(y);
        }
    }
}
