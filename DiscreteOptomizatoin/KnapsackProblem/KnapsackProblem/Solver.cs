using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KnapsackProblem
{
    class Solver
    {
        static void Main(string[] args)
        {
            try
            {
                solve(args);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
        }

        // Read the instance, solve it, and print the solution in the standard output
        private static void solve(string[] args)
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
                Item anItem = new Item();

                anItem.Value = int.Parse(parts[0]);
                anItem.Weight = int.Parse(parts[1]);

                myItems[i - 1] = anItem;
            }

            // a trivial greedy algorithm for filling the knapsack
            // it takes itmes in order until the knapsack is full 
            int[] taken = new int[items];

            foreach(var item in myItems)
            {
                if (myKnapsack.Weight + item.Weight <= capacity)
                {
                    myKnapsack.Add(item);  
                }
            }

            // prpare the solution in the specified output format
            PrintOutput(myItems, myKnapsack);
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
            foreach (var item in myItems)
            {
                Console.Write("{0} ", item.Taken);
            }
            Console.WriteLine();
        }
    }
}
