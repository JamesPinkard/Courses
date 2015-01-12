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
            List<int> testList = new List<int>() { 4,3,4,1,7,8};
            int num = CutStock(testList, 10);
            Console.WriteLine(num);
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
            List<int> copyList = new List<int>();
            copyList.AddRange(requests);
            return recCutStock(copyList, stockLength);
        }

        private static int recCutStock(List<int> subList, int stockLength)
        {
            if (subList.Count == 0)
            {
                return 0;
            }
            else
            {
                // remove subset
                List<int> remaining = new List<int>();
                List<int> runningList = new List<int>();
                List<int> leftOver = new List<int>();
                remaining = removeSubset(subList, runningList, leftOver, stockLength);
                
                // 1 + evaluate remaining
                return 1 + recCutStock(remaining, stockLength);
            }
        }

        private static List<int> removeSubset(List<int> subList, List<int> runningList, List<int> leftOver, int stockLength)
        {
            if (subList.Count == 0)
            {
                return leftOver;
            }
            else
            {                
                List<int> addedRunninglist = new List<int>();
                addedRunninglist.AddRange(runningList);
                addedRunninglist.Add(subList[0]);

                if (CanMakeSum(subList,stockLength))
                {
                    List<int> soFar = new List<int>();
                    var subset = MakeSum(soFar, subList, stockLength);
                    foreach (var item in subset)
                    {
                        subList.Remove(item);
                    }
                    return subList;                                       
                }

                else
                {

                    if (addedRunninglist.Sum() < stockLength )
                    {
                        return removeSubset(subList.GetRange(1, subList.Count - 1), addedRunninglist, leftOver, stockLength);
                    }                
                    else
                    {
                        leftOver.Add(subList[0]);
                        return removeSubset(subList.GetRange(1, subList.Count - 1), runningList, leftOver, stockLength);
                    }                
                }
            }        
        }

        static List<int> MakeSum(List<int> soFar, List<int> nums, int targetSum)
        {
            if (nums.Count == 0)
            {                
                if (soFar.Sum() == targetSum)
                {
                    return soFar;
                }
                else
                {
                    return new List<int>();
                }
            }
            else
            {
                List<int> nextNums = new List<int>();
                nextNums = nums.GetRange(1, nums.Count - 1);

                List<int> nextSoFar = new List<int>();
                nextSoFar.AddRange(soFar);
                nextSoFar.Add(nums[0]);

                var origList = MakeSum(nextSoFar, nextNums, targetSum);
                var remainingList = MakeSum(soFar, nextNums, targetSum);
                if (origList.Sum() == targetSum)
                {
                    return origList;
                }
                if (remainingList.Sum()== targetSum)
                {
                    return remainingList;
                }

                else
                {
                    return new List<int>();
                }
            }
        }

    }
}
