using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HeapsAndHashes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileNumbers = File.ReadAllLines(@"E:\SkyDrive\Courses\Algorithms\algorithm_pt1\Median.txt");
            
            List<int> myNums = new List<int>();
            List<int> medians = new List<int>();

            foreach (var line in fileNumbers)
            {
                var myLine = line.TrimEnd();
                Int32 firstNum = Convert.ToInt32(myLine);

                myNums.Add(firstNum);
                myNums.Sort();

                if (myNums.Count % 2 == 0)
                {
                    int index = myNums.Count / 2;
                    medians.Add(myNums[index - 1]);
                }

                else
                {
                    int index = (myNums.Count + 1) / 2;
                    medians.Add(myNums[index - 1]);
                }
            }

            Int64 medianSum = medians.Sum();

            Console.WriteLine("The answer is: {0}", medianSum % 10000);
            Console.ReadLine();
        }

        private static void TwoSumExample()
        {
            string[] fileNumbers = File.ReadAllLines(@"C:\Users\jpink_000\Documents\GitHub\Courses\Algorithms\prob-2sum.txt");
            Dictionary<Int64, Int64> intDict = new Dictionary<Int64, Int64>();

            foreach (var line in fileNumbers)
            {
                var myLine = line.TrimEnd();
                Int64 firstNum = Convert.ToInt64(myLine);

                intDict[firstNum] = firstNum;
            }

            Int64 total = 0;

            for (Int64 i = -10000; i < 10001; i++)
            {
                total += twoSum(intDict, i);
            }


            Console.WriteLine(total);

            using (StreamWriter writer = File.CreateText(@"C:\Users\jpink_000\Documents\GitHub\Courses\Algorithms\TwoSumOutput.txt"))
            {
                writer.Write("The answer is: {0}", total);
            }

            Console.ReadLine();
        }

        static int twoSum(Dictionary<Int64, Int64> myDict, Int64 target)
        {
            foreach (var x in myDict.Keys)
            {
                if (myDict.ContainsKey(target - x))
                {
                    return 1;
                }                
            }

            return 0;
        }
    }


}
