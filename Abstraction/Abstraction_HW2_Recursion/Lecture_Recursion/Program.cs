using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            ListSubsets("abcdefg");
            Console.ReadKey();
        }

        static int Raise(int baseNum, int exp)
        {
            if (exp == 0)
                return 1;
            else
                return baseNum * Raise(baseNum, exp - 1);
        }

        static int EfficientRaise(int baseNum, int exp)
        {
            if (exp == 0)
                return 1;
            else
            {
                int half = Raise(baseNum, exp / 2);
                if (exp % 2 == 0)
                    return half * half;
                else
                    return baseNum * half * half;
            }
        }

        static bool IsPalindrome(string s)
        {
            if (s.Length <= 1) return true;
            return s[0] == s[s.Length - 1] && IsPalindrome(s.Substring(1, s.Length - 2));
        }

        static readonly int NOTFOUND = -1;
        static int BSearch(List<int> numbers, int start, int stop, int key)
        {
            if (start > stop) return NOTFOUND;

            int mid = (start + stop) / 2;
            if (key == numbers[mid])
                return mid;
            else if (key < numbers[mid])
                return BSearch(numbers, start, mid - 1, key);
            else
                return BSearch(numbers, mid + 1, stop, key);
        }

        static int C(int n, int k)
        {
            if (k == 0 || k == n)
                return 1;
            else
                return C(n - 1, k) + C(n - 1, k - 1);
        }

        static void RecPermute(string soFar, string rest)
        {
            if (rest == "")
                Console.WriteLine(soFar);
            else
            {
                for (int i = 0; i < rest.Length; i++)
                {
                    string next = soFar + rest[i];
                    string remaining = rest.Substring(0, i) + rest.Substring(i + 1);
                    RecPermute(next, remaining);
                }
            }
        }

        // wrapper function
        static void ListPermutations(string s)
        {
            RecPermute("", s);
        }

        static void RecSubsets(string soFar, string rest)
        {
            if (rest == "")
                Console.WriteLine(soFar);
            else
            {
                RecSubsets(soFar + rest[0], rest.Substring(1));
                RecSubsets(soFar, rest.Substring(1));
            }
        }

        static void ListSubsets(string str)
        {
            RecSubsets("", str);
        }
    }
}
