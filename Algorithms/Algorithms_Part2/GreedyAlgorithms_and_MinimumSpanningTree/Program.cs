using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GreedyAlgorithms_and_MinimumSpanningTree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lines = readLinesIn(@"C:\Users\jpink_000\SkyDrive\Courses\Algorithms\Algorithm_Pt2\ProgrammingAssignments\week1_jobs.txt");

                        // parse the data in the file
            string[] firstLine = lines.First().TrimEnd().Split();
            int items = int.Parse(firstLine[0]);

            DifferenceItem[] myItems = new DifferenceItem[items];
            

            for (int i = 1; i < items + 1; i++)
            {
                string line = lines[i];
                string[] parts = line.TrimEnd().Split();

                int iWeight = int.Parse(parts[0]);
                int iLength = int.Parse(parts[1]);

                DifferenceItem anItem = new DifferenceItem(iLength, iWeight);
                myItems[i - 1] = anItem;
            }

            Array.Sort(myItems);
            Array.Reverse(myItems);

            Int64 ct = 0;
            Int64 weightedTime = 0;
            Int64 sum = 0;
            foreach (var item in myItems)
            {
                ct += item.Length;
                weightedTime = ct * item.Weight;
                sum += weightedTime;
            }

            Console.WriteLine(sum);
            Console.ReadLine();
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
    }
}
