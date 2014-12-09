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
            Console.WriteLine("Enter Number:");
            string mynum = Console.ReadLine();
            int num = int.Parse(mynum);
            PrintInBinary(num);
            Console.ReadKey();
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

        /*
        static bool CanMakeSum(List<int> nums, int targetSum)
        {
            if (nums.Count == 0)
                return false;
            else
            {
                int first = nums.First();
                var remaining = nums.GetRange(1, nums.Count - 1);
                CanMakeSum(remaining, targetSum);               
            }
        }
         */
    }
}
