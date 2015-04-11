using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnapsackProblem;
using NUnit.Framework;

namespace KnapsackTests
{
    partial class KnapsackTests
    {
        private static Knapsack getTenCapacityKnapsack()
        {
            Knapsack myKnapsack = new Knapsack(10);
            return myKnapsack;
        }

        private static Item[] GetTestItems()
        {
            Item myItem = new Item(45, 5);
            Item newItem = new Item(48, 8);
            Item thirdItem = new Item(35, 3);
            Item[] itemArray = new Item[] { myItem, newItem, thirdItem };
            return itemArray;
        }
    }
}
