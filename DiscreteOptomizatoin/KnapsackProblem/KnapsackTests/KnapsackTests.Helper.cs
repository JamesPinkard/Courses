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
        private static Knapsack getKnapsack()
        {
            Knapsack myKnapsack = new Knapsack(10);
            return myKnapsack;
        }

    }
}
