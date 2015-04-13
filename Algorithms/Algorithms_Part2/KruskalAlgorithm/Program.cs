using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KruskalAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // string myLaptopPath = @"C:\Users\jpink_000\SkyDrive\Courses\Algorithms\Algorithm_Pt2\ProgrammingAssignments\clustering1.txt";
            string myHomePath = @"E:\SkyDrive\Courses\Algorithms\Algorithm_Pt2\ProgrammingAssignments\clustering1.txt";
            List<string> lines = readLinesIn(myHomePath);

            int numNodes = int.Parse(lines[0].Split()[0]);
            Dictionary<int, LinkedListNode<Vertex>> nodeDict = new Dictionary<int,LinkedListNode<Vertex>>();

            for (int i = 1; i <= numNodes; i++)
			{
                Vertex v = new Vertex(i);
                LinkedListNode<Vertex> node = MakeSet(v);
                nodeDict.Add(i, node);
			}

            Graph G = new Graph();

            for (int j = 1; j < lines.Count; j++)
			{
                string[] parts = lines[j].Split();
                LinkedListNode<Vertex> nodeX = nodeDict[int.Parse(parts[0])];
                LinkedListNode<Vertex> nodeY = nodeDict[int.Parse(parts[1])];
                int weight = int.Parse(parts[2]);

                G.AddEdge(nodeX, nodeY, weight);
			}

            /*
            List<Edge> myMST = KruskalMinSpanTree(G);

            List<int> weights = myMST.Select(edge => edge.WeightValue).ToList<int>();
            int cost = weights.Sum();
            */

            int cost = KruskalMinClustering(G, 4, numNodes);
            Console.WriteLine(cost);
            Console.ReadLine();
        }

        public static LinkedListNode<Vertex> MakeSet(Vertex v)
        {
            LinkedList<Vertex> mySet = new LinkedList<Vertex>();
            mySet.AddFirst(v);
            LinkedListNode<Vertex> myNode = mySet.First;            
            return myNode;
        }
        
        public static List<Edge> KruskalMinSpanTree(Graph G)
        {
            G.SortEdges();
            List<Edge> mst = new List<Edge>();
            foreach (var edge in G.listEdges)
            {
                if (!G.IsCycle(edge.NodeA, edge.NodeB))
                {
                    mst.Add(edge);
                    Union(edge.NodeA, edge.NodeB);
                }
            }

            return mst;
        }

        public static int KruskalMinClustering(Graph G,int kClusters, int numVertices)
        {
            G.SortEdges();
            int numUnions = 0;
            int maxUnions = numVertices - kClusters;
            List<Edge> mst = new List<Edge>();
            foreach (var edge in G.listEdges)
            {
                if (!G.IsCycle(edge.NodeA, edge.NodeB))
                {
                    if (numUnions == maxUnions )
                    {
                        return edge.WeightValue;
                    }
                    mst.Add(edge);
                    Union(edge.NodeA, edge.NodeB);
                    numUnions++;
                }
            }

            return 0;
        }

        public static void Union(LinkedListNode<Vertex> x, LinkedListNode<Vertex> y)
        {
            LinkedList<Vertex> listX = x.List;
            LinkedList<Vertex> listY = y.List;

            LinkedList<Vertex> minList;
            LinkedList<Vertex> maxList;

            if (listX.Count < listY.Count)
            {
                minList = listX;
                maxList = listY;
            }
            else
            {
                minList = listY;
                maxList = listX;
            }

            int minCount = minList.Count;
            for (int k = 0; k < minCount; k++)
            {
                LinkedListNode<Vertex> node = minList.First;
                minList.RemoveFirst();
                maxList.AddLast(node);
            }            
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
