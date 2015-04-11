using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgorithms_and_MinimumSpanningTree
{
    public struct DensityItem : IComparable<DensityItem>
    {
        public int Length { get { return length; } }
        public int Weight { get { return weight; } }
        public double Score { get { return score; } }
        private int taken;

        public int Taken
        {
            get { return taken; }
            set { taken = value; }
        }


        public DensityItem(int length, int weight)
        {
            this.length = length;
            this.weight = weight;
            double divWeight = (double)weight;
            double divLength = (double)length;
            this.score = divWeight / divLength; 
            taken = 0;
        }

        readonly int length;
        readonly int weight;
        readonly double score;

        public int CompareTo(DensityItem other)
        {
            return this.Score.CompareTo(other.Score);         
        }
    }
}
