using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra_ShortestPath
{
    class WeightedVertex : IComparable <WeightedVertex>
    {
        public Dictionary<WeightedVertex, int> Edges = new Dictionary<WeightedVertex, int>();        
        public WeightedVertex Predecessor;
        
        public int PathDistance
        {
            get { return pathDistance; }
            set { pathDistance = value; }
        }
                
        public int Index
        {
            get { return index; }            
        }

        private int pathDistance;
        private int index;

        public WeightedVertex()
        {

        }

        public WeightedVertex(int v)
        {
            index = v;
        }

        public void InsertEdge(WeightedVertex edge, int weight)
        {
            Edges[edge] = weight;
        }

        public int CompareTo(WeightedVertex other)
        {
            if (this.PathDistance < other.PathDistance) return -1;
            else if (this.PathDistance > other.PathDistance) return 1;
            else return 0;

            // Could also use
            // return this.PathDistance.CompareTo(other.PathDistance);
        }
    }
}
