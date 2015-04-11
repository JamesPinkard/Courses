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
        public int FoundMax { get; set; }

        public List<Item> GetItemListCopy()
        {
            return items.ToList();
        }

        public Knapsack Copy()
        {
            Knapsack copy = new Knapsack(Capacity);
            copy.FoundMax = FoundMax;
            copy.items = GetItemListCopy();
            copy.Weight = Weight;
            copy.Value = Value;
            return copy;
        }

        static public Knapsack GetMaxKnapsack(Knapsack K1, Knapsack K2)
        {
            if (K1.Value > K2.Value)
            {
                return K1;
            }
            else
            {
                return K2;
            }
        }

        public void Remove(Item item)
        {
            item.Taken = 0;
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

        public void RemoveLastItem()
        {            
            Item lastItem = items[items.Count - 1];
            Remove(lastItem);
        }

        public int GetAvailableMax(Item[] itemArray)
        {
            int availableWeight = this.Capacity - this.Weight;
            int maxValue = 0;
            int i = 0;
            while (availableWeight > 0 && i < itemArray.Count())
            {
                int iWeight = itemArray[i].Weight;
                int iValue = itemArray[i].Value;
                if (iWeight > availableWeight)
                {
                    maxValue += iValue * availableWeight / iWeight;
                    return this.Value + maxValue;
                }
                else
                {
                    maxValue += iValue;
                    availableWeight -= iWeight;
                }
                i++;
            }
            return this.Value + maxValue;
        }
    }
}
