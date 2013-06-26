using System;
using System.Collections.Generic;

namespace CableCompany
{
    public class CableCompanyMain
    {
        public static void Main(string[] args)
        {
            Edge[] edges = new Edge[]
            {
                new Edge('A', 'C', 5),
                new Edge('A', 'B', 4),
                new Edge('A', 'D', 9),
                new Edge('B', 'D', 2),
                new Edge('C', 'D', 20),
                new Edge('C', 'E', 7),
                new Edge('E', 'D', 8),
                new Edge('E', 'F', 12),
            };

            HashSet<char> visitedNodes = new HashSet<char>();
            char[] startNodes = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };

            for (int i = 0; i < startNodes.Length; i++)
            {
                visitedNodes.Clear();
                var minSpanTreeEdges = FindMinSpanningTree(startNodes[i], edges, visitedNodes);

                // Print the edges of the minimum spannin tree
                foreach (var edge in minSpanTreeEdges)
                {
                    Console.WriteLine(edge);
                }

                Console.WriteLine();
            }
        }

        public static HashSet<Edge> FindMinSpanningTree(char startNode, Edge[] edges, HashSet<char> visitedNodes)
        {
            HashSet<Edge> minSpanTreeEdges = new HashSet<Edge>();
            MinHeap<Edge> heap = new MinHeap<Edge>();

            // Add all edges that have a node - the startNode to the heap
            for (int i = 0; i < edges.Length; i++)
            {
                if (edges[i].StartNode == startNode || edges[i].EndNode == startNode)
                {
                    heap.Add(edges[i]);
                }
            }

            // Mark the start node as visited
            visitedNodes.Add(startNode);

            // Construct the minimum spanning tree
            while (heap.Count > 0)
            {
                Edge currentMinEdge = heap.Remove();

                if (!visitedNodes.Contains(currentMinEdge.StartNode))
                {
                    visitedNodes.Add(currentMinEdge.StartNode);
                    minSpanTreeEdges.Add(currentMinEdge);

                    // Add all the unsvisited edges that contains the visited node to the heap
                    for (int i = 0; i < edges.Length; i++)
                    {
                        if (edges[i].StartNode == currentMinEdge.StartNode ||
                            edges[i].EndNode == currentMinEdge.StartNode)
                        {
                            if (!minSpanTreeEdges.Contains(edges[i]))
                            {
                                heap.Add(edges[i]);
                            }
                        }
                    }
                }
                else if (!visitedNodes.Contains(currentMinEdge.EndNode))
                {
                    visitedNodes.Add(currentMinEdge.EndNode);
                    minSpanTreeEdges.Add(currentMinEdge);

                    // Add all the unvisited edges that contains the visited node to the heap
                    for (int i = 0; i < edges.Length; i++)
                    {
                        if (edges[i].StartNode == currentMinEdge.EndNode ||
                            edges[i].EndNode == currentMinEdge.EndNode)
                        {
                            if (!minSpanTreeEdges.Contains(edges[i]))
                            {
                                heap.Add(edges[i]);
                            }
                        }
                    }
                }
            }

            return minSpanTreeEdges;
        }
    }
}
