using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MinimumCut
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileNumbers = File.ReadAllLines(@"C:\Users\jpink_000\Documents\GitHub\Courses\Algorithms\kargerMinCut.txt");
            Dictionary<int, List<int>> myDict = new Dictionary<int, List<int>>();

            foreach (var line in fileNumbers)
            {
                List<int> numberList = new List<int>();
                string[] mySplit = line.Split();

                for (int i = 1; i < mySplit.Length - 1; i++)
                {
                    int num = Convert.ToInt32(mySplit[i]);
                    numberList.Add(num);
                }

                int firstNum = Convert.ToInt32(mySplit[0]);

                myDict[firstNum] = numberList;
            }

            Random rnd = new Random();

            int minCut = 999999;

            for (int i = 0; i < 300; i++)
            {
                int newCut = getMinimumCut(myDict, rnd);

                if (newCut < minCut)
                    minCut = newCut;
            }

            Console.WriteLine(minCut);

            Console.ReadKey();
        }

        private static int getMinimumCut(Dictionary<int, List<int>> myDict, Random rnd)
        {
            Dictionary<int, List<int>> copyDict = new Dictionary<int, List<int>>();

            foreach (var pair in myDict)
            {
                copyDict[pair.Key] = pair.Value.ToList<int>();
            }
            
            List<int> keyList = copyDict.Keys.ToList<int>();

            while (copyDict.Count > 2)
            {
                // Select edge by picking a key and a integer value
                int vertIndex = rnd.Next(copyDict.Count);
                int myKey = keyList[vertIndex];

                List<int> edgeList = copyDict[myKey];
                int targetIndex = rnd.Next(edgeList.Count);
                int myTarget = edgeList[targetIndex];

                ContractVertices(copyDict, myKey, myTarget);
                RemoveSelfLoops(copyDict, myKey);
                keyList.Remove(myTarget);
            }

            int minCut = copyDict.First().Value.Count;
            return minCut;
        }

        private static void RemoveSelfLoops(Dictionary<int, List<int>> myDict, int myKey)
        {
            List<int> keyEdges = myDict[myKey];
            keyEdges.RemoveAll(i => i == myKey);
        }

        private static void ContractVertices(Dictionary<int, List<int>> myDict, int myKey, int myTarget)
        {
            RemoveEdge(myDict, myKey, myTarget);
            AddAllEdges(myDict, myKey, myTarget);
            RemoveAllEdges(myDict, myTarget);
            myDict.Remove(myTarget);           
        }

        private static void RemoveAllEdges(Dictionary<int, List<int>> myDict, int myTarget)
        {
            List<int> targetEdges = myDict[myTarget];
            int[] edgeCounter = myDict[myTarget].ToArray();

            foreach (var edge in edgeCounter)
            {
                RemoveEdge(myDict, myTarget, edge);
            }
        }

        private static void RemoveEdge(Dictionary<int, List<int>> myDict, int myKey, int myTarget)
        {
            List<int> keyEdges = myDict[myKey];
            List<int> targetEdges = myDict[myTarget];

            keyEdges.Remove(myTarget);
            targetEdges.Remove(myKey);
        }
        
        private static void AddAllEdges(Dictionary<int, List<int>> myDict, int myKey, int myTarget)
        {
            List<int> targetEdges = myDict[myTarget];
            int[] edgeCounter = myDict[myTarget].ToArray();

            foreach (var edge in edgeCounter)
            {
                addEdge(myDict, myKey, edge);
            }
        }

        private static void addEdge(Dictionary<int, List<int>> myDict, int myKey, int myTarget)
        {
            List<int> keyEdges = myDict[myKey];
            List<int> targetEdges = myDict[myTarget];

            keyEdges.Add(myTarget);
            targetEdges.Add(myKey);
        }

        private static void PrintDictionary(Dictionary<int, List<int>> myDict)
        {
            foreach (var pair in myDict)
            {
                Console.Write("{0} = ", pair.Key);
                pair.Value.ForEach(Print);

                Console.WriteLine();
            }
        }

        static void Print(int s)
        {
            Console.Write("{0}, ", s.ToString());
        }
    }
}
