using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnapsackProblem;
using NUnit.Framework;

namespace KnapsackProblem.Tests
{
    class KnapsackTests
    {
        [Test]
        public void AddItemToKnapsack()
        {
            Item myItem = new Item();            
            myItem.Value = 5;
            myItem.Weight = 3;
            Knapsack myKnapsack = new Knapsack(10);

            myKnapsack.AddItem(myItem);

            List<Item> copyItems = myKnapsack.GetItemListCopy();
            Item kpItem = copyItems[0];
            Assert.That(kpItem.Value, Is.EqualTo(myItem.Value));
            Assert.That(kpItem.Weight, Is.EqualTo(myItem.Weight));
        }

        [Test]
        public void AddedItemHasTakenFlag()
        {
            Item myItem = new Item(5, 3);
            Assert.That(myItem.Taken, Is.EqualTo(0));
            Knapsack myKnapsack = new Knapsack(10);

            myKnapsack.AddItem(myItem);

            List<Item> copyItems = myKnapsack.GetItemListCopy();
            Item kpItem = copyItems[0];
            Assert.That(kpItem.Taken, Is.EqualTo(1));
        }

        [Test]
        public void 
    }
}
