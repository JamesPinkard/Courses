using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Dijkstra_ShortestPath
{
    class Graph : IEnumerable<KeyValuePair<int, WeightedVertex>>
    {
        public Dictionary<int, WeightedVertex> listVertices = new Dictionary<int, WeightedVertex>();
        public WeightedVertex this[int vertex]
        {
            get { return listVertices[vertex]; }
            set { listVertices[vertex] = value; }
        }

        public int Count { get { return listVertices.Count; } }

        public void AddEdge(int tail, int head, int distance)
        {
            if (!ContainsKey(head))
            {
                listVertices[head] = new WeightedVertex(head);
            }

            if (!ContainsKey(tail))
            {
                listVertices[tail] = new WeightedVertex(tail);
            }

            listVertices[tail].InsertEdge(listVertices[head], distance);
        }

        public Graph Reverse()
        {
            Graph revGraph = new Graph();

            foreach (var item in listVertices)
            {
                foreach (var head in item.Value.Edges.Keys)
                {
                    if (!revGraph.ContainsKey(head.Index))
                    {
                        revGraph[head.Index] = new WeightedVertex(head.Index);
                    }
                    revGraph.AddEdge(head.Index, item.Value.Index, item.Value.Edges[head]);
                }
            }
            return revGraph;
        }

        public bool ContainsKey(int vertex)
        {
            return listVertices.ContainsKey(vertex);
        }

        public List<WeightedVertex> GetValues()
        {
            return listVertices.Values.ToList<WeightedVertex>();
        }


        public IEnumerator<KeyValuePair<int, WeightedVertex>> GetEnumerator()
        {
            return listVertices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return listVertices.GetEnumerator();
        }
    }
}
