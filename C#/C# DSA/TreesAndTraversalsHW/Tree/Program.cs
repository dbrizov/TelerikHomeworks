using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Program
    {
        public static Node<int> FindRoot(Node<int>[] nodes)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].HasParent == false)
                {
                    return nodes[i];
                }
            }

            throw new ArgumentException("The tree has no root");
        }

        public static List<Node<int>> FindLeafs(Node<int>[] nodes)
        {
            List<Node<int>> leafs = new List<Node<int>>();
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].Children.Count == 0)
                {
                    leafs.Add(nodes[i]);
                }
            }

            return leafs;
        }

        public static List<Node<int>> FindMiddleNodes(Node<int>[] nodes)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].HasParent && nodes[i].Children.Count > 0)
                {
                    middleNodes.Add(nodes[i]);
                }
            }

            return middleNodes;
        }

        /// <summary>
        /// Finds the length of the longest path from a specified tree root
        /// </summary>
        /// <param name="root">The root of the tree</param>
        /// <returns>The length the path as an Int32 number</returns>
        public static int FindLongestPathLength(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPathLength = 0;
            foreach (var child in root.Children)
            {
                maxPathLength = Math.Max(maxPathLength, FindLongestPathLength(child));
            }

            return maxPathLength + 1;
        }

        /// <summary>
        /// Finds the first path with a specified path length.
        /// </summary>
        /// <param name="root">The root a tree(subtree)</param>
        /// <param name="path">List of nodes where the path will be saved. Passed as reference.</param>
        /// <param name="pathLength">The specified path length</param>
        /// <param name="currentDepth">The current depth must always be 0</param>
        /// <returns>True if a root with the specified length was found and false otherwise</returns>
        public static bool FindPath(Node<int> root, ref List<Node<int>> path, int pathLength, int currentDepth = 0)
        {
            path.Add(root);
            if (currentDepth == pathLength)
            {
                return true;
            }

            foreach (var child in root.Children)
            {
                if (FindPath(child, ref path, pathLength, currentDepth + 1))
                {
                    return true;
                }

                path.RemoveAt(path.Count - 1);
            }

            return false;
        }

        /// <summary>
        /// Finds all the paths with a specified node's sum int the tree
        /// and all it's subtrees and their substrees...
        /// </summary>
        /// <param name="treeNodes">All of the nodes of the tree</param>
        /// <param name="sum">The specified node's sum</param>
        /// <returns>List of Lists of tree nodes with Int32 value</returns>
        public static List<List<Node<int>>> FindAllPathsWithSpecifiedNodeSum(Node<int>[] treeNodes, int sum)
        {
            var allPaths = new List<List<Node<int>>>();

            for (int i = 0; i < treeNodes.Length; i++)
            {
                var currentPath = new List<Node<int>>();
                FindAllPathsWithSpecifiedNodeSum(treeNodes[i], sum, ref allPaths, ref currentPath);
            }

            return allPaths;
        }

        /// <summary>
        /// Finds all the paths with a specified node's sum
        /// only from the specified root to the end ot the tree
        /// </summary>
        /// <param name="root">The root of the tree</param>
        /// <param name="sum">The specified nodes sum</param>
        /// <param name="paths">The result is collected here</param>
        /// <param name="currentPath">The current path the traversal reached</param>
        private static void FindAllPathsWithSpecifiedNodeSum(Node<int> root, int sum,
            ref List<List<Node<int>>> paths, ref List<Node<int>> currentPath)
        {
            currentPath.Add(root);

            int currentSum = currentPath.Sum(x => x.Value);
            if (currentSum == sum)
            {
                paths.Add(currentPath.ToList()); // ToList() makes a whole new copy. This is needed because currentPath is a reference type
            }

            foreach (var child in root.Children)
            {
                FindAllPathsWithSpecifiedNodeSum(child, sum, ref paths, ref currentPath);
            }

            currentPath.RemoveAt(currentPath.Count - 1);
        }

        /// <summary>
        /// Finds all subtrees with a specified node's sum.
        /// </summary>
        /// <param name="treeNodes">All of the nodes of the tree</param>
        /// <param name="sum">The specified node's sum</param>
        /// <returns>A list of the roots of the substrees</returns>
        public static List<Node<int>> FindAllSubtreesWithSpecifiedNodeSum(Node<int>[] treeNodes, int sum)
        {
            var subtreesRoots = new List<Node<int>>();

            foreach (var node in treeNodes)
            {
                int currentSum = GetSumOfTreeNodes(node);
                if (currentSum == sum)
                {
                    Node<int> copyOfNode = node.Clone();
                    copyOfNode.HasParent = false;
                    subtreesRoots.Add(copyOfNode);
                }
            }

            return subtreesRoots;
        }

        /// <summary>
        /// Gets the sum of all nodes in a tree
        /// </summary>
        /// <param name="root">The root of the tree</param>
        /// <returns>The sum of the nodes of the tree as a Int32 number</returns>
        private static int GetSumOfTreeNodes(Node<int> root)
        {
            int sum = 0;
            sum += root.Value;

            foreach (var child in root.Children)
            {
                sum += GetSumOfTreeNodes(child);
            }

            return sum;
        }

        private static void PrintTree(Node<int> root, string spaces = "")
        {
            if (root == null)
            {
                return;
            }

            Console.WriteLine(spaces + root.Value);
            foreach (var child in root.Children)
            {
                PrintTree(child, spaces + "   ");
            }
        }

        private static void PrintNodes(List<Node<int>> longestPath)
        {
            for (int i = 0; i < longestPath.Count; i++)
            {
                if (i == longestPath.Count - 1)
                {
                    Console.Write("{0} ", longestPath[i].Value);
                }
                else
                {
                    Console.Write("{0}, ", longestPath[i].Value);
                }
            }

            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            // A demo - press alt and drag with the mouse to copy
            // 11
            // 2 4
            // 3 2
            // 5 0
            // 3 5
            // 5 6
            // 5 1
            // 0 7
            // 0 8
            // 0 9
            // 8 10

            int nodesCount = int.Parse(Console.ReadLine());
            Node<int>[] nodes = new Node<int>[nodesCount];

            for (int i = 0; i < nodesCount; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            // Parse the tree
            for (int i = 1; i <= nodesCount - 1; i++)
            {
                string edge = Console.ReadLine();
                string[] edgeNodes = edge.Split(' ');
                int parentValue = int.Parse(edgeNodes[0]);
                int childValue = int.Parse(edgeNodes[1]);

                nodes[parentValue].AddChild(nodes[childValue]);
            }

            // Print the tree
            Console.WriteLine();
            PrintTree(FindRoot(nodes));
            Console.WriteLine();

            // a) Find the root of the tree
            Node<int> root = FindRoot(nodes);
            Console.WriteLine("Root: {0}", root.Value);

            // b) Find the leafs of the tree
            List<Node<int>> leafs = FindLeafs(nodes);
            Console.Write("Leafs: ");
            PrintNodes(leafs);

            // c) Find the middle nodes
            List<Node<int>> middleNodes = FindMiddleNodes(nodes);
            Console.Write("Middle nodes: ");
            PrintNodes(middleNodes);

            // d) Find the longest path(it might not be unique)
            int longestPathLength = FindLongestPathLength(root);

            List<Node<int>> longestPath = new List<Node<int>>();
            FindPath(root, ref longestPath, longestPathLength);

            Console.Write("Longest path: ");
            PrintNodes(longestPath);

            // *e) Find all paths with specified node's sum
            int sum = 9;
            var paths = FindAllPathsWithSpecifiedNodeSum(nodes, sum);

            Console.WriteLine("Paths with node's sum {0}:", sum);
            foreach (var path in paths)
            {
                PrintNodes(path);
            }

            // *f) Find all substrees with specified node's sum
            int nodesSum = 34;
            var subtreesRoots = FindAllSubtreesWithSpecifiedNodeSum(nodes, nodesSum);

            Console.WriteLine("Subtrees with node's sum {0}:", nodesSum);
            foreach (var subtreeRoot in subtreesRoots)
            {
                PrintTree(subtreeRoot);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
