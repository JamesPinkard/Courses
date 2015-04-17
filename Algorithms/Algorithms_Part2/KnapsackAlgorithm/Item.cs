using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackAlgorithm
{
    public struct Item : IComparable<Item>
    {
        public int Index { get { return index; } set { index = value; } }
        public int Value { get { return value; } }
        public int Weight { get { return weight; } }
        public int Density { get { return density; } }
        private int taken;

        public int Taken
        {
            get { return taken; }
            set { taken = value; }
        }


        public Item(int value, int weight)
        {
            this.value = value;
            this.weight = weight;
            this.density = value / weight;
            this.index = 0;
            taken = 0;
        }

        readonly int value;
        readonly int weight;
        readonly int density;
        public int index;

        public int CompareTo(Item other)
        {
            return this.Density.CompareTo(other.Density);
        }
    }
}
