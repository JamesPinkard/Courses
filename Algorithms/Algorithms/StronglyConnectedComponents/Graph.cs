using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace StronglyConnectedComponents
{
    class Graph : IEnumerable<KeyValuePair<int, Vertex>>
    {
        Dictionary<int, Vertex> listEdges = new Dictionary<int, Vertex>();
        public Vertex this[int vertex]
        {
            get { return listEdges[vertex]; }
            set { listEdges[vertex] = value; }
        }

        public int Count { get { return listEdges.Count; } }

        public void AddEdge(int tail, int head)
        {
            if (!ContainsKey(head))
            {
                listEdges[head] = new Vertex(head);
            }

            if (!ContainsKey(tail))
            {
                listEdges[tail] = new Vertex(tail);
            }

            listEdges[tail].Add(listEdges[head]);
        }

        public Graph Reverse()
        {
            Graph revGraph = new Graph();

            foreach (var item in listEdges)
            {
                foreach (var head in item.Value.Edges)
                {
                    if (!revGraph.ContainsKey(head.Index))
                    {
                        revGraph[head.Index] = new Vertex(head.Index);
                    }
                    revGraph.AddEdge(head.Index,item.Value.Index);
                }
            }
            return revGraph;
        }

        public bool ContainsKey(int vertex)
        {
            return listEdges.ContainsKey(vertex);
        }

        public List<Vertex> GetValues()
        {
            return listEdges.Values.ToList<Vertex>();
        }


        public IEnumerator<KeyValuePair<int, Vertex>> GetEnumerator()
        {
            return listEdges.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return listEdges.GetEnumerator();
        }
    }
}
