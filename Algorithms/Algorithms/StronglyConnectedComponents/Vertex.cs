using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StronglyConnectedComponents
{
    class Vertex
    {
        public List<Vertex> Edges = new List<Vertex>();
        public int Leader { get; set; }
        public int FinishingTime { get; set; }
        public bool Explored { get; set; }
        private int index;

        public int Index
        {
            get { return index; }            
        }

        public Vertex(int v)
        {
            index = v;
        }

        public void Add(Vertex edge)
        {
            Edges.Add(edge);
        }
    }
}
