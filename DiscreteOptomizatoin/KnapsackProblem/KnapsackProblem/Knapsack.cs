using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem
{
    public class Knapsack
    {
        private List<Item> items = new List<Item>();
        public int Capacity { get; set; }

        public Knapsack(int capacity)
        {
            this.Capacity = capacity;
        }

        public int Weight { get; private set; }
        public int Value { get; private set; }

        public List<Item> GetItemListCopy()
        {
            return items.ToList();
        }

        public void Remove(Item item)
        {
            Weight -= item.Weight;
            Value -= item.Value;
            items.Remove(item);
        }

        public void Add(Item item)
        {
            item.Taken = 1;
            items.Add(item);
            Weight += item.Weight;
            Value += item.Value;
        }


    }
}
