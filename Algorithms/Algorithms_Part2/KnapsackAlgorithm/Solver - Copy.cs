using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace KnapsackAlgorithm
{
    public class Solver_Big
    {
        static void Main_v2(string[] args)
        {

            int maxStackSize = 128 * 1024 * 1024;
            object token = new object();
            Console.WriteLine("What is the input file path:");
            string inputPath = @"E:\SkyDrive\Courses\Algorithms\Algorithm_Pt2\ProgrammingAssignments\knapsack_big.txt";

            try
            {
                Thread th = new Thread(Solver_Big.delSolve, maxStackSize);
                th.Start(inputPath);
                th.Join();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        public static void delSolve(object obj)
        {
            string myArgs = (string)obj;
            solve(myArgs);
        }

        // Read the instance, solve it, and print the solution in the standard output
        public static void basicSolve(string fileName)
        { 
            // read the lines out of the file
            List<string> lines = readLinesIn(fileName);

            // parse the data in the file
            string[] firstLine = lines.First().TrimEnd().Split();
            int items = int.Parse(firstLine[1]);
            int capacity = int.Parse(firstLine[0]);

            int[] Values = new int[items + 1];
            int[] Weights = new int[items + 1];
            Knapsack myKnapsack = new Knapsack(capacity);

            for (int i = 1; i < items + 1; i++)
            {
                string line = lines[i];
                string[] parts = line.TrimEnd().Split();


                Values[i] = int.Parse(parts[0]);
                Weights[i] = int.Parse(parts[1]);
            }

            Values[0] = 0;
            Weights[0] = 0;


            // a trivial greedy algorithm for filling the knapsack
            // it takes itmes in order until the knapsack is full 
            int[,] optTable = new int[capacity + 1, items + 1];

            for (int j = 0; j < items; j++)
            {
                optTable[0, j] = 0;
            }

            for (int w = 0; w < capacity; w++)
            {
                optTable[w, 0] = 0;
            }
             
            for (int j = 1; j <= items; j++)
            {
                for (int w = 1; w <= capacity; w++)
                {
                    if (Weights[j] > w)
                    {
                        optTable[w, j] = optTable[w, j - 1];
                    }
                    else
                    {
                        optTable[w, j] = Math.Max(
                            optTable[w - Weights[j], j - 1] + Values[j],
                            optTable[w, j - 1]);
                    }
                }
            }

            int optimumValue = optTable[capacity, items];

            int row = capacity;
            int[] taken = new int[items];

            for (int col = items; col > 0; col--)
            {
                if (optTable[row, col] == optTable[row, col - 1])
                {
                    taken[col - 1] = 0;
                }
                else // entry is used in optimal solution
                {
                    taken[col - 1] = 1;
                    row -= Weights[col];
                }
            }

            // prpare the solution in the specified output format
            PrintOptimalSolution(optimumValue, taken);
        }

        private static void PrintOptimalSolution(int solution, int[] takenItems)
        {
            Console.WriteLine("{0} 0", solution);
            foreach (var item in takenItems)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }

        // original solve algorithm
        private static void oldSolve(string[] args)
        {
            string fileName = null;

            // Get the temp file name
            fileName = getTempFileName(args, fileName);

            if (fileName == null)
            {
                return;
            }

            // read the lines out of the file
            List<string> lines = readLinesIn(fileName);

            // parse the data in the file
            string[] firstLine = lines.First().TrimEnd().Split();
            int items = int.Parse(firstLine[0]);
            int capacity = int.Parse(firstLine[1]);

            Item[] myItems = new Item[items];
            Knapsack myKnapsack = new Knapsack(capacity);

            for (int i = 1; i < items + 1; i++)
            {
                string line = lines[i];
                string[] parts = line.TrimEnd().Split();

                int iValue = int.Parse(parts[0]);
                int iWeight = int.Parse(parts[1]);

                Item anItem = new Item(iValue, iWeight);
                myItems[i - 1] = anItem;
            }

            // a trivial greedy algorithm for filling the knapsack
            // it takes itmes in order until the knapsack is full 
            int[] taken = new int[items];

            foreach (var item in myItems)
            {
                if (myKnapsack.Weight + item.Weight <= capacity)
                {
                    myKnapsack.Add(item);
                }
            }

            // prpare the solution in the specified output format
            PrintOutput(myItems, myKnapsack);
        }

        // original solve algorithm
        private static void solve(string fileName)
        {           

            // read the lines out of the file
            List<string> lines = readLinesIn(fileName);

            // parse the data in the file
            string[] firstLine = lines.First().TrimEnd().Split();
            int items = int.Parse(firstLine[1]);
            int capacity = int.Parse(firstLine[0]);

            Item[] myItems = new Item[items];
            Knapsack myKnapsack = new Knapsack(capacity);

            for (int i = 1; i < items + 1; i++)
            {
                string line = lines[i];
                string[] parts = line.TrimEnd().Split();

                int iValue = int.Parse(parts[0]);
                int iWeight = int.Parse(parts[1]);

                Item anItem = new Item(iValue, iWeight);
                anItem.Index = i;
                myItems[i - 1] = anItem;
            }

            Array.Sort(myItems);
            Array.Reverse(myItems);            

            Knapsack optKnapsack = GetOptimumKnapsack(myKnapsack, myItems, 0, 0);

            // prpare the solution in the specified output format
            PrintOutput(myItems, optKnapsack);
        }

        private static List<string> readLinesIn(string fileName)
        {
            List<string> lines = new List<string>();

            try
            {
                lines = File.ReadAllLines(fileName).ToList();
            }
            catch (IOException)
            {
                throw;
            }
            return lines;
        }

        private static string getTempFileName(string[] args, string fileName)
        {
            foreach (string arg in args)
            {
                if (arg.StartsWith("-file="))
                {
                    string mydir = Directory.GetCurrentDirectory();
                    string myArg = arg.Replace("-file=", "");
                    fileName = Path.Combine(mydir, myArg);
                }
            }
            return fileName;
        }

        private static void PrintOutput(Item[] myItems, Knapsack myKnapsack)
        {
            Console.WriteLine("{0} 0", myKnapsack.Value);
            List<Item> takenItems = myKnapsack.GetItemListCopy();

            int[] takenValues = new int[takenItems.Count];
            int i = 0;
            foreach (var t in takenItems)
            {
                takenValues[i] = t.Index;
                i++;
            }

            foreach (var item in myItems)
            {
                if (takenValues.Contains(item.Index))
                {
                    Console.Write("{0} ", 1);
                }
                else
                {
                    Console.Write("{0} ", 0);
                }
            }
            Console.WriteLine();
        }

        public static Knapsack GetOptimumKnapsack(Knapsack myKnapsack, Item[] itemArray, int i, int weight)
        {            
            int kValue = myKnapsack.Value;

            int arrayLength = itemArray.Length;
            int leftover = arrayLength - i;            
            int foundMax = myKnapsack.FoundMax;
            int origKnapsackWeight = weight;
            int capacity = myKnapsack.Capacity;

            if (leftover < 1)
            {
                if (kValue > foundMax)
                {
                    myKnapsack.FoundMax = kValue;
                    return myKnapsack;
                }
                else
                {
                    return myKnapsack;
                }
            }

            int itemWeight = itemArray[i].Weight;
            int addedKnapsackWeight = origKnapsackWeight + itemWeight;

            if (addedKnapsackWeight <= capacity)
            {

                Knapsack kOriginal = GetOptimumKnapsack(myKnapsack, itemArray, i + 1, origKnapsackWeight);

                Knapsack addedKnapsack = myKnapsack.Copy();
                addedKnapsack.Add(itemArray[i]);
                Knapsack kAdded = GetOptimumKnapsack(addedKnapsack, itemArray, i + 1, addedKnapsackWeight);

                return Knapsack.GetMaxKnapsack(kAdded, kOriginal);
            }
            else
            {
                return myKnapsack;
            }
        }
    }
}
