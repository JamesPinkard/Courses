using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem
{
    public class Item
    {
        public int Value { get; set; }
        public int Weight { get; set; }
        public int Taken { get; set; }

        public Item(int value, int weight)
        {
            this.Value = value;
            this.Weight = weight;
        }

        public Item()
        {

        }
    }
}
