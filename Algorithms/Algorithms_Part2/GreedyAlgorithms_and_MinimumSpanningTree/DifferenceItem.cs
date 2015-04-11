using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgorithms_and_MinimumSpanningTree
{
    public struct DifferenceItem : IComparable<DifferenceItem>
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


        public DifferenceItem(int length, int weight)
        {
            this.length = length;
            this.weight = weight;
            this.score = weight - length; 
            taken = 0;
        }

        readonly int length;
        readonly int weight;
        readonly double score;

        public int CompareTo(DifferenceItem other)
        {
            if (this.Score == other.Score)
            {
                return this.Weight.CompareTo(other.Weight);
            }
            else
            {
                return this.Score.CompareTo(other.Score);
            }
        }
    }
}
