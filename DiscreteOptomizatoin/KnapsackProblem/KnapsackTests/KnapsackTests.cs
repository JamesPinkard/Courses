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
        [Test]
        public void AddItemToKnapsack()
        {
            Item myItem = new Item(5, 3);            
            Knapsack myKnapsack = getTenCapacityKnapsack();           

            myKnapsack.Add(myItem);

            List<Item> copyItems = myKnapsack.GetItemListCopy();
            Item kpItem = copyItems[0];
            Assert.That(kpItem.Value, Is.EqualTo(myItem.Value));
            Assert.That(kpItem.Weight, Is.EqualTo(myItem.Weight));
        }

        [Test]
        public void RemoveLastItemFromKnapsack()
        {
            Item myItem = new Item(5, 3);
            Knapsack myKnapsack = getTenCapacityKnapsack();
            myKnapsack.Add(myItem);

            Assert.That(myKnapsack.Value, Is.EqualTo(5));
            Assert.That(myKnapsack.Weight, Is.EqualTo(3));

            myKnapsack.RemoveLastItem();

            Assert.That(myKnapsack.Value, Is.EqualTo(0));
            Assert.That(myKnapsack.FoundMax, Is.EqualTo(0));
        }

        [Test]
        public void AddedItemHasTakenFlag()
        {
            Item myItem = new Item(5, 3);
            Assert.That(myItem.Taken, Is.EqualTo(0));
            Knapsack myKnapsack = getTenCapacityKnapsack();

            myKnapsack.Add(myItem);

            List<Item> copyItems = myKnapsack.GetItemListCopy();
            Item kpItem = copyItems[0];
            Assert.That(kpItem.Taken, Is.EqualTo(1));
        }

        [Test]
        public void KnapsackReflectsItemWeight()
        {
            Item myItem = new Item(5, 3);
            Item newItem = new Item(2, 5);
            Knapsack myKnapsack = getTenCapacityKnapsack();

            myKnapsack.Add(myItem);
            myKnapsack.Add(newItem);
            

            Assert.That(myKnapsack.Weight, Is.EqualTo(myItem.Weight + newItem.Weight));            
        }

        [Test]
        public void KnapsackGetsThreeItemAvailbleMax()
        {
            Item[] itemArray = GetTestItems();
            Knapsack myKnapsack = getTenCapacityKnapsack();
            Array.Sort(itemArray);
            Array.Reverse(itemArray);

            int result = myKnapsack.GetAvailableMax(itemArray);

            Assert.That(result, Is.EqualTo(92));
        }

        [Test]
        public void KnapsackAddsItemThenGetsAvailableMax()
        {
            Item myItem = new Item(45, 5);            
            Item thirdItem = new Item(35, 3);
            Item[] itemArray = new Item[] { thirdItem };
            Knapsack myKnapsack = getTenCapacityKnapsack();
            myKnapsack.Add(myItem);
            Array.Sort(itemArray);
            Array.Reverse(itemArray);

            int result = myKnapsack.GetAvailableMax(itemArray);

            Assert.That(result, Is.EqualTo(80));
        }

        [Test]
        public void KnapsackGetsAvailableMaxFromTwoItems()
        {            
            Item newItem = new Item(48, 8);
            Item thirdItem = new Item(35, 3);
            Item[] itemArray = new Item[] { thirdItem, newItem };
            Knapsack myKnapsack = getTenCapacityKnapsack();            
            Array.Sort(itemArray);
            Array.Reverse(itemArray);

            int result = myKnapsack.GetAvailableMax(itemArray);

            Assert.That(result, Is.EqualTo(77));
        }

        [Test]
        public void SolverGetsOptimumKnapsack()
        {
            Item[] itemArray = GetTestItems();
            Knapsack myKnapsack = getTenCapacityKnapsack();
            Array.Sort(itemArray);
            Array.Reverse(itemArray);
            

            Knapsack optKnapsack = Solver.GetOptimumKnapsack(myKnapsack, itemArray);

            Assert.That(optKnapsack.Value, Is.EqualTo(80));
        }
    }
}
