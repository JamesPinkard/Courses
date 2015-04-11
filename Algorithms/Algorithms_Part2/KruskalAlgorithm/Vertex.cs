using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruskalAlgorithm
{
    struct Vertex
    {    
        private int index;

        public int Index
        {
            get { return index; }            
        }

        public Vertex(int v)
        {
            index = v;
        }
    }
}
