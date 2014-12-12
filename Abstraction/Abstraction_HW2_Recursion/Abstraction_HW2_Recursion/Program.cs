using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_HW2_Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            var testNums = new List<int>() { 1, 2, 5};
            Console.WriteLine(CanMakeSum(testNums, 4) );
            Console.WriteLine(testNums.Sum());
            Console.ReadKey();
        }

        private static void RunRecursionPrintInBinary()
        {
            Console.WriteLine("Enter Number:");
            string mynum = Console.ReadLine();
            int num = int.Parse(mynum);
            PrintInBinary(num);
        }

        static void PrintInBinary(int num)
        {
            if (num==0)
            {
                Console.Write(0);
            }
            else
            {
                int bit = num % 2;
                int half = num / 2;
                PrintInBinary(half);
                Console.Write(bit);
            }
        }      

        
        static bool CanMakeSum(List<int> nums, int targetSum)
        {
            List<int> soFar = new List<int>();
            return RecMakeSum(soFar, nums, targetSum);            
        }

        static bool RecMakeSum(List<int> soFar, List<int> nums, int targetSum)
        {
            if (nums.Count == 0)
            {
                Console.WriteLine(soFar);
                return soFar.Sum() == targetSum;
            }
            else
            {
                List<int> nextNums = new List<int>();
                nextNums = nums.GetRange(1, nums.Count - 1);

                List<int> nextSoFar = new List<int>();
                nextSoFar.AddRange(soFar);
                nextSoFar.Add(nums[0]);

                if (RecMakeSum(nextSoFar, nextNums, targetSum)) return true;
                if (RecMakeSum(soFar, nextNums, targetSum)) return true;
                else
                {
                    return false;
                }
            }            
        }
        
    }
}
