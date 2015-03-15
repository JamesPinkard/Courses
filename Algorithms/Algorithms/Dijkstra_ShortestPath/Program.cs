using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dijkstra_ShortestPath
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            string[] fileNumbers = File.ReadAllLines(@"C:\Users\jpink_000\Documents\GitHub\Courses\Algorithms\dijkstraData.txt");
            Graph myGraph = new Graph();

            foreach (var line in fileNumbers)
            {
                var myLine = line.TrimEnd('\r', '\n', ' ').TrimEnd();
                
                string[] mySplit = myLine.Split();
                int firstNum = Convert.ToInt32(mySplit[0]);

                if (!myGraph.ContainsKey(firstNum))
                {
                    myGraph[firstNum] = new WeightedVertex(firstNum);
                }

                if (mySplit.Length > 1)
                {
                    for (int i = 1; i < mySplit.Length; i++)
                    {
                        string[] weightSplit = mySplit[i].Split(',');
                        int[] weightPair = new int[] { Convert.ToInt32(weightSplit[0]), Convert.ToInt32(weightSplit[1]) };
                        myGraph.AddEdge(firstNum, weightPair[0], weightPair[1]);
                    }
                }
            }

            Dictionary<int, WeightedVertex> pathListing = DijkstraShortestPath(myGraph, myGraph[1]);
            PrintAllInGraph(pathListing);
            // PrintHWList(pathListing);

            int[] checkList = new int[] { 7, 37, 59, 82, 99, 115, 133, 165, 188, 197 };
            // Get a StreamWriter and write string data.
            using (StreamWriter writer = File.CreateText(@"C:\Users\jpink_000\Documents\GitHub\Courses\Algorithms\dijkstraOutput.txt"))
            {
                foreach (var i in checkList)
                {
                    writer.Write("{0},", pathListing[i].PathDistance);
                }
            }

            var testVertex = pathListing[188];

            while (testVertex.Index != 1)
            {
                var tempVertex = testVertex.Predecessor;
                Console.Write("{0} to {1} dist: {2},", testVertex.Index, tempVertex.Index, tempVertex.Edges[testVertex]);
                testVertex = tempVertex;
            }
            Console.ReadLine();
        }

        private static void PrintAllInGraph(Dictionary<int, WeightedVertex> pathListing)
        {
            for(int i = 1; i <= 200; i++)
            {
                Console.WriteLine("{0} is this far: {1} with predecessor {2}", pathListing[i].Index, pathListing[i].PathDistance, pathListing[i].Predecessor.Index);
            }
        }

        private static void PrintHWList(Dictionary<int, WeightedVertex> pathListing)
        {
            int[] checkList = new int[] { 7, 37, 59, 82, 99, 115, 133, 165, 188, 197 };

            foreach (var i in checkList)
            {
                Console.WriteLine("distance for {0} is {1}, ",pathListing[i].Index, pathListing[i].PathDistance);
            }
        }

        private static void testGraphPrinting(Graph myGraph)
        {
            var testVert = myGraph[1];
            Console.WriteLine("Vertex Index: {0}", testVert.Index);
            foreach (var weightedEdge in testVert.Edges)
            {
                Console.WriteLine("Edge Vertex: {0}, Distance: {1}", weightedEdge.Key.Index, weightedEdge.Value);
            }

        }

        private static void HeapExample()
        {
            var testList = new List<int>() { 5, 3, 7, 2, 9, 10, 1, 6 };

            var testHeap = new HeapQueue<int>(testList);

            testHeap.Insert(0);
            int len = testHeap.Count;

            for (int i = 0; i < len; i++)
            {
                Console.WriteLine("Count: {0}, Min: {1}", testHeap.Count, testHeap.PopMin());
            }            
        }

        private static Dictionary<int, WeightedVertex> DijkstraShortestPath(Graph G, WeightedVertex startVertex)
        {
            initSource(G, startVertex);
            Dictionary<int, WeightedVertex> processedVertices = new Dictionary<int, WeightedVertex>();
            HeapQueue<WeightedVertex> priorityQ = new HeapQueue<WeightedVertex>();

            foreach (var vertex in G.listVertices.Values)
            {
                priorityQ.Insert(vertex);
            }

            while (!(priorityQ.Count == 0))
            {
                var nextVert = priorityQ.PopMin();
                processedVertices[nextVert.Index] = nextVert;
                foreach (var adjVertex in nextVert.Edges.Keys)
                {
                    Relax(nextVert, adjVertex, priorityQ);
                }
            }            
            
            return processedVertices;
        }

        private static void initSource(Graph myGraph, WeightedVertex startVertex)
        {
            foreach (KeyValuePair<int, WeightedVertex> dict in myGraph)
            {
                var vertex = dict.Value;
                vertex.PathDistance =  Int16.MaxValue;
                vertex.Predecessor = new WeightedVertex();
            }

            startVertex.PathDistance = 0;
        }

        private static void Relax(WeightedVertex u, WeightedVertex v, HeapQueue<WeightedVertex> PriorityQueue)
        {
            if (v.PathDistance > (u.PathDistance + u.Edges[v]))
            {
                v.PathDistance = u.PathDistance + u.Edges[v];
                v.Predecessor = u;
                PriorityQueue.Heapify();

            }
        }
    }
}
