using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace CountInversions
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileNumbers = File.ReadAllLines(@"C:\Users\jpink_000\Documents\GitHub\Courses\Algorithms\QuickSort.txt");
            List<int> numberList = new List<int>();
            foreach (string item in fileNumbers)
            {
                int myNum = Convert.ToInt32(item);
                numberList.Add(myNum);
            }
            
            QuickSortList QL = new QuickSortList(numberList);

            QuickSort(QL,0,QL.NumCount());

            //foreach (var item in QL.Numbers)
            //{
              //  Console.WriteLine(item);
            //}
            Console.WriteLine();
            Console.WriteLine(QL.ScanCount);

            Console.WriteLine();
            int check = 9 % 2;
            Console.WriteLine(check);
            Console.ReadKey();
        }

        private static void MergeSplitTest()
        {
            string[] fileNumbers = File.ReadAllLines(@"C:\Users\jpink_000\Documents\GitHub\Courses\Algorithms\IntegerArray.txt");
            List<int> numberList = new List<int>();
            foreach (string item in fileNumbers)
            {
                int myNum = Convert.ToInt32(item);
                numberList.Add(myNum);
            }




            InversionList testNums = new InversionList(numberList);

            InversionList simpleNums = new InversionList(new List<int> { 5, 6, 7, 8, 1, 2, 3, 4 });

            InversionList result = SortAndCountInversions(testNums);
            foreach (var item in result.Numbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(result.InversionCount);
            Console.WriteLine(result.Numbers.Max());
            Console.WriteLine(result.Numbers.Min());
            Console.WriteLine(testNums.NumCount());


            Console.ReadKey();
        }

        private static void TestCheck(List<int> nums)
        {
            int cnt = nums.Count();

            List<int> firstHalf = nums.GetRange(0, cnt / 2);

            foreach (var item in firstHalf)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Second half");

            List<int> secondHalf = nums.GetRange(cnt / 2, cnt / 2);

            foreach (var item in secondHalf)
            {
                Console.WriteLine(item);
            }
        }

        static InversionList SortAndCountInversions(InversionList invList)
        {
            if (invList.NumCount() == 1)
            {
                return invList;
            }
            else
            {
                InversionList firstInvList = SortAndCountInversions(invList.GetFirstHalf());
                InversionList secondInvList = SortAndCountInversions(invList.GetSecondHalf());
                InversionList splitInvList = MergeSplit(firstInvList, secondInvList);
                splitInvList.InversionCount = splitInvList.InversionCount + firstInvList.InversionCount + secondInvList.InversionCount;
                return splitInvList;
            }
        }

        private static InversionList MergeSplit(InversionList firstInvList, InversionList secondInvList)
        {
            InversionList mergedInvList = new InversionList();
            int mergedCount = firstInvList.NumCount() + secondInvList.NumCount();

            int i = 0;
            int j = 0;
            int SENTINEL = 999999999;

            firstInvList.Add(SENTINEL);
            secondInvList.Add(SENTINEL);
            
            for (int k = 0; k < mergedCount; k++)
            {
                if ( firstInvList[i] <= secondInvList[j])
                {
                    mergedInvList.Add(firstInvList[i]);
                    i++;
                }
                else
                {
                    int invCount = firstInvList.NumCount() - (i + 1);
                    mergedInvList.InversionCount += invCount;
                    mergedInvList.Add(secondInvList[j]);
                    j++;
                }
            }

            return mergedInvList;
        }

        private static void QuickSort(QuickSortList A, int lo, int hi)
        {
            if (hi == lo)
            {
                return;
            }
            else
            {
                ChoosePivot(A, lo, hi);
                int p = Partition(A, lo, hi);
                QuickSort(A, lo, p - 1);
                QuickSort(A, p, hi);
            }
        }

        private static void ChoosePivot(QuickSortList A, int lo, int hi)
        {
            TakeMidpoint(A, lo, hi);

        }

        private static void TakeMidpoint(QuickSortList A, int lo, int hi)
        {
            int length = hi - lo;
            int mid;
            if (length % 2 == 0)
            {
                mid = lo + (length / 2) - 1;
            }
            else
            {
                mid = lo + (length / 2);
            }

            int[] sub = new int[] { A[lo], A[hi - 1], A[mid] };

            Array.Sort(sub);
            if (A[hi - 1] == sub[1])
            {
                Swap(A, hi - 1, lo);
            }
            if (A[mid] == sub[1])
            {
                Swap(A, mid, lo);
            }
        }

        private static int Partition(QuickSortList A, int lo, int hi)
        {
            int t = A[lo];
            int i = lo + 1;
            A.ScanCount += hi - i;
            for (int j = lo + 1; j < hi; j++)
            {
                if (A[j] < t)
                {
                    Swap(A, i, j);
                    i += 1;
                }
            }
            Swap(A, lo, i - 1);
            return i;
        }

        private static void Swap(QuickSortList A, int i, int j)
        {
            int orig = A[j];
            A[j] = A[i];
            A[i] = orig;
        }
    }
}
