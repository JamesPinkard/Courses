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

        public List<Item> GetItemListCopy()
        {
            return items.ToList();
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public void AddItem(Item item)
        {
            item.Taken = 1;
            items.Add(item);
        }


    }
}
