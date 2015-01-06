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
            List<int> testList = new List<int>() { 3,1,2,3,0};
            Console.WriteLine(Solvable(0, testList));
            Console.ReadKey();
        }

        // Practice 1
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

        private static void RunPractice2()
        {
            var testNums = new List<int>() { 1, 2, 5 };
            Console.WriteLine(CanMakeSum(testNums, 4));
            Console.WriteLine(testNums.Sum());
        }
        
        // Practice 2
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
        
       // HW Problem 1
        static int CountWays(int numStairs)
        {
            if (numStairs == 1 || numStairs == 0)
            {
                return 1;
            }
            else
            {
                int runningTotal = CountWays(numStairs - 1);
                return runningTotal + CountWays(numStairs - 2);
            }
        }

        static int SimplerCountWays(int numStairs)
        {
            if (numStairs == 1 || numStairs == 0)
            {
                return 1;
            }
            else
            {                
                return CountWays(numStairs - 1) + CountWays(numStairs - 2);
            }
        }

        // HW Problem 3


        static int CountCriticalVotes(List<int> blocks, int blockIndex)
        {
            int targetSum = (blocks.Sum()/2) +1;
            int targetBlock = blocks[blockIndex];
            blocks.RemoveAt(blockIndex);
            List<int> Avotes = new List<int>();

            return recCriticalVotes(Avotes, blocks, targetBlock, targetSum);
        }

        private static int recCriticalVotes(List<int> Avotes, List<int> blocks,int targetBlock, int targetSum)
        {
            if (blocks.Count == 0)
            {                
                if (Avotes.Sum() <= targetSum && Avotes.Sum() + targetBlock >= targetSum)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                List<int> nextSoFar = new List<int>();
                nextSoFar.AddRange(Avotes);
                nextSoFar.Add(blocks[0]);

                List<int> nextNums = new List<int>();
                nextNums = blocks.GetRange(1, blocks.Count - 1);


                return recCriticalVotes(nextSoFar, nextNums, targetBlock, targetSum) + recCriticalVotes(Avotes, nextNums, targetBlock, targetSum);
            }
        }

        // HW Problem 5

        private static bool Solvable(int start, List<int> squares)
        {
            List<int> sofar = new List<int>();
            return recSolvable(start, squares, sofar);
        }

        private static bool recSolvable(int start, List<int> squares, List<int> sofar)
        {
            if (squares[start] == 0)
            {
                return true;
            }
            else
            {
                if (start + squares[start] < squares.Count)
                {
                    int moveRight = start + squares[start];
                    sofar.Add(moveRight);
                    if (recSolvable(moveRight, squares, sofar)) return true;
                }

                if (start - squares[start] >= 0)
                {
                    int moveLeft = start - squares[start];                    
                    if( sofar.Contains(moveLeft)) return false;
                    sofar.Add(moveLeft);
                    if (recSolvable(moveLeft, squares, sofar)) return true;
                }
            }
            return false;
        }

        // HW Problem 6

        private static int CutStock(List<int> requests, int stockLength)
        {
            List<int> soFar = new List<int>();
            return recCutStock(soFar, requests, stockLength);
        }

        private static int recCutStock(List<int> soFar, List<int> requests, int stockLength)
        {
            if (soFar.Sum() == stockLength)
            {
                return 1;
            }
            else
            {

            }
        }
    }
}
