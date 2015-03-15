using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace StronglyConnectedComponents
{
    class Program
    {
        static void Main(string[] args)
        {
            int stackSize = 1024 * 1024 * 128;
            Thread th = new Thread(() =>
                {
                    string[] fileNumbers = File.ReadAllLines(@"C:\Users\jpink_000\Documents\GitHub\Courses\Algorithms\SCC.txt");
                    Graph myGraph = new Graph();

                    foreach (var line in fileNumbers)
                    {
                        string[] mySplit = line.Split();
                        int firstNum = Convert.ToInt32(mySplit[0]);

                        if (!myGraph.ContainsKey(firstNum))
                        {
                            myGraph[firstNum] = new Vertex(firstNum);
                        }

                        int num = Convert.ToInt32(mySplit[1]);
                        myGraph.AddEdge(firstNum, num);
                    }

                    Graph revGraph = myGraph.Reverse();

                    DFSLoop(revGraph);

                    Graph finishTimeGraph = new Graph();

                    foreach (KeyValuePair<int, Vertex> ri in revGraph)
                    {
                        finishTimeGraph[ri.Value.FinishingTime] = myGraph[ri.Value.Index];
                    }

                    DFSForLoop(finishTimeGraph);

                    List<Vertex> listVertices = finishTimeGraph.GetValues();

                    var leaders = from v in listVertices
                                  group v by v.Leader into lGroup
                                  select lGroup;

                    List<int> leaderCount = new List<int>();

                    foreach (var group in leaders)
                    {
                        leaderCount.Add(group.Count());
                    }

                    leaderCount.Sort();
                    leaderCount.Reverse();

                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine(leaderCount[i]);
                    }
                }, stackSize);

            th.Start();
            th.Join();
            Console.ReadLine();
        }

        static int t;
        static int s;
        
        static void DFSForLoop(Graph G)
        {
            t = 0;
            s = 0;
            
            for (int i = G.Count; i > 0; i--)
            {
                if (!G[i].Explored)
                {
                    s = i;
                    DFS(G, G[i]);
                }                
            }
        }

        static void DFSLoop(Graph G)
        {
            t = 0;
            s = 0;

            foreach (KeyValuePair<int,Vertex> node in G)
            {
                if (!node.Value.Explored)
                {
                    s = node.Key;
                    DFS(G, node.Value);
                }
            }
        }

        private static void DFS(Graph G, Vertex vertex)
        {
            vertex.Explored = true;
            vertex.Leader = s;

            foreach (var arc in vertex.Edges)
            {                
                if (!arc.Explored)
                {
                    DFS(G, arc);
                }
            }

            t++;
            vertex.FinishingTime = t;
        }

        static void Print(int num)
        {
            Console.WriteLine(num);
        }

    }
}
