using System;
using System.Collections.Generic;

namespace FriendsOfPesho
{
    public class FiendsOfPeshoMain
    {
        public static void Main(string[] args)
        {
            long minPathsSum = long.MaxValue;
            Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>();

            // Read the number of nodes, steets and hospitals
            string[] firstLine = Console.ReadLine().Split(' ');
            int numberOfNodes = int.Parse(firstLine[0]);
            int numberOfStreets = int.Parse(firstLine[1]);
            int numberOfHospitals = int.Parse(firstLine[2]);

            // Read the hospital's IDs
            string[] secondLine = Console.ReadLine().Split(' ');
            HashSet<int> hospitalIDs = new HashSet<int>();
            for (int i = 0; i < secondLine.Length; i++)
            {
                hospitalIDs.Add(int.Parse(secondLine[i]));
            }

            // Read the connections
            HashSet<Tuple<int, int, long>> connections = new HashSet<Tuple<int, int, long>>();
            Dictionary<int, Node> allNodes = new Dictionary<int, Node>();
            for (int i = 0; i < numberOfStreets; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                int startNodeID = int.Parse(line[0]);
                int endNodeID = int.Parse(line[1]);
                long connectionDistance = long.Parse(line[2]);

                if (!allNodes.ContainsKey(startNodeID))
                {
                    allNodes.Add(startNodeID, new Node(startNodeID, long.MaxValue));
                }

                if (!allNodes.ContainsKey(endNodeID))
                {
                    allNodes.Add(endNodeID, new Node(endNodeID, long.MaxValue));
                }

                connections.Add(new Tuple<int, int, long>(startNodeID, endNodeID, connectionDistance));
            }

            // Construct the graph
            foreach (var connection in connections)
            {
                if (!graph.ContainsKey(allNodes[connection.Item1]))
                {
                    graph.Add(allNodes[connection.Item1], new List<Connection>());
                }

                graph[allNodes[connection.Item1]].Add(
                    new Connection(allNodes[connection.Item2], connection.Item3));

                if (!graph.ContainsKey(allNodes[connection.Item2]))
                {
                    graph.Add(allNodes[connection.Item2], new List<Connection>());
                }

                graph[allNodes[connection.Item2]].Add(
                    new Connection(allNodes[connection.Item1], connection.Item3));
            }

            foreach (var hospitalID in hospitalIDs)
            {
                FindMinPath(allNodes[hospitalID], graph);
                long currentSum = SumPaths(graph, hospitalIDs);
                if (currentSum < minPathsSum)
                {
                    minPathsSum = currentSum;
                }
            }

            Console.WriteLine(minPathsSum);
        }

        public static long SumPaths(Dictionary<Node, List<Connection>> graph, HashSet<int> hospitalIDs)
        {
            long sum = 0;
            foreach (var node in graph)
            {
                if (!hospitalIDs.Contains(node.Key.ID))
                {
                    sum += node.Key.DijkstraDistance;
                }
            }

            return sum;
        }

        public static void FindMinPath(Node source, Dictionary<Node, List<Connection>> graph)
        {
            MinHeap<Node> minHeap = new MinHeap<Node>();

            foreach (var node in graph)
            {
                node.Key.DijkstraDistance = long.MaxValue;
            }

            source.DijkstraDistance = 0L;
            minHeap.Add(source);

            while (minHeap.Count > 0)
            {
                Node currentNode = minHeap.Remove();

                foreach (var connection in graph[currentNode])
                {
                    long distance = currentNode.DijkstraDistance + connection.Distance;
                    if (distance < connection.Node.DijkstraDistance)
                    {
                        connection.Node.DijkstraDistance = distance;
                        minHeap.Add(connection.Node);
                    }
                }
            }
        }

        public class Node : IComparable
        {
            public int ID { get; private set; }
            public long DijkstraDistance { get; set; }

            public Node(int id, long dijkstraDistance)
            {
                this.ID = id;
                this.DijkstraDistance = dijkstraDistance;
            }

            public int CompareTo(object obj)
            {
                return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
            }

            public override bool Equals(object obj)
            {
                return this.ID.Equals((obj as Node).ID);
            }

            public override int GetHashCode()
            {
                return this.ID.GetHashCode();
            }
        }

        public class Connection
        {
            public Node Node { get; private set; }
            public long Distance { get; private set; }

            public Connection(Node node, long weight)
            {
                this.Node = node;
                this.Distance = weight;
            }
        }

        public class MinHeap<T> where T : IComparable
        {
            private const int INITIAL_CAPACITY = 16;

            private T[] arr;
            private int lastItemIndex;

            public MinHeap()
                : this(INITIAL_CAPACITY)
            {
            }

            public MinHeap(int capacity)
            {
                this.arr = new T[capacity];
                this.lastItemIndex = -1;
            }

            public int Count
            {
                get
                {
                    return this.lastItemIndex + 1;
                }
            }

            public void Add(T item)
            {
                if (this.lastItemIndex == this.arr.Length - 1)
                {
                    this.Resize();
                }

                this.lastItemIndex++;
                this.arr[this.lastItemIndex] = item;

                this.MinHeapifyUp(this.lastItemIndex);
            }

            public T Remove()
            {
                if (this.lastItemIndex == -1)
                {
                    throw new InvalidOperationException("The heap is empty");
                }

                T removedItem = this.arr[0];
                this.arr[0] = this.arr[this.lastItemIndex];
                this.lastItemIndex--;

                this.MinHeapifyDown(0);

                return removedItem;
            }

            public T Peek()
            {
                if (this.lastItemIndex == -1)
                {
                    throw new InvalidOperationException("The heap is empty");
                }

                return this.arr[0];
            }

            public void Clear()
            {
                this.lastItemIndex = -1;
                this.arr = new T[INITIAL_CAPACITY];
            }

            private void MinHeapifyUp(int index)
            {
                if (index == 0)
                {
                    return;
                }

                int childIndex = index;
                int parentIndex = (index - 1) / 2;

                if (this.arr[childIndex].CompareTo(this.arr[parentIndex]) < 0)
                {
                    // swap the parent and the child
                    T temp = this.arr[childIndex];
                    this.arr[childIndex] = this.arr[parentIndex];
                    this.arr[parentIndex] = temp;

                    this.MinHeapifyUp(parentIndex);
                }
            }

            private void MinHeapifyDown(int index)
            {
                int leftChildIndex = index * 2 + 1;
                int rightChildIndex = index * 2 + 2;
                int smallestItemIndex = index; // The index of the parent

                if (leftChildIndex <= this.lastItemIndex &&
                    this.arr[leftChildIndex].CompareTo(this.arr[smallestItemIndex]) < 0)
                {
                    smallestItemIndex = leftChildIndex;
                }

                if (rightChildIndex <= this.lastItemIndex &&
                    this.arr[rightChildIndex].CompareTo(this.arr[smallestItemIndex]) < 0)
                {
                    smallestItemIndex = rightChildIndex;
                }

                if (smallestItemIndex != index)
                {
                    // swap the parent with the smallest of the child items
                    T temp = this.arr[index];
                    this.arr[index] = this.arr[smallestItemIndex];
                    this.arr[smallestItemIndex] = temp;

                    this.MinHeapifyDown(smallestItemIndex);
                }
            }

            private void Resize()
            {
                T[] newArr = new T[this.arr.Length * 2];
                for (int i = 0; i < this.arr.Length; i++)
                {
                    newArr[i] = this.arr[i];
                }

                this.arr = newArr;
            }
        }
    }
}