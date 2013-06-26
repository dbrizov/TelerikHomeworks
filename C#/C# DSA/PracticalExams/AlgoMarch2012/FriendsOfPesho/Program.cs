using System;
using System.Collections.Generic;

namespace FriendsOfPesho
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>();

            // Read the first line
            string[] firstLine = Console.ReadLine().Split(' ');
            int nodesCount = int.Parse(firstLine[0]);
            int streetsCount = int.Parse(firstLine[1]);
            int hospitalsCount = int.Parse(firstLine[2]);

            Node[] nodes = new Node[nodesCount + 1];
            for (int i = 1; i < nodes.Length; i++)
            {
                nodes[i] = new Node(i, long.MaxValue);
            }

            // Read the second line
            string[] secondLine = Console.ReadLine().Split(' ');
            Node[] hospitals = new Node[hospitalsCount];
            for (int i = 0; i < hospitalsCount; i++)
            {
                int hospitalID = int.Parse(secondLine[i]);
                hospitals[i] = nodes[hospitalID];
            }

            // Read the streets and construct the graph
            for (int i = 0; i < streetsCount; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                int firstNodeID = int.Parse(line[0]);
                int secondNodeID = int.Parse(line[1]);
                long weight = long.Parse(line[2]);

                if (!graph.ContainsKey(nodes[firstNodeID]))
                {
                    graph[nodes[firstNodeID]] = new List<Connection>();
                }

                graph[nodes[firstNodeID]].Add(new Connection(nodes[secondNodeID], weight));

                if (!graph.ContainsKey(nodes[secondNodeID]))
                {
                    graph[nodes[secondNodeID]] = new List<Connection>();
                }

                graph[nodes[secondNodeID]].Add(new Connection(nodes[firstNodeID], weight));
            }

            // Solve the problem
            long minSum = long.MaxValue;
            for (int i = 0; i < hospitals.Length; i++)
            {
                FindMinPaths(graph, hospitals[i]);
                long currentSum = SumNodes(nodes, hospitals);
                if (currentSum < minSum)
                {
                    minSum = currentSum;
                }
            }

            Console.WriteLine(minSum);
        }

        static void FindMinPaths(Dictionary<Node, List<Connection>> graph, Node startNode)
        {
            MinHeap<Node> heap = new MinHeap<Node>();

            foreach (var node in graph)
            {
                node.Key.DijsktraDistance = long.MaxValue;
            }

            startNode.DijsktraDistance = 0L;
            heap.Add(startNode);

            while (heap.Count > 0)
            {
                var currentNode = heap.Remove();

                var connections = graph[currentNode];

                foreach (var connection in connections)
                {
                    long distance = currentNode.DijsktraDistance + connection.Weight;
                    if (distance < connection.Node.DijsktraDistance)
                    {
                        connection.Node.DijsktraDistance = distance;
                        heap.Add(connection.Node);
                    }
                }
            }
        }

        static long SumNodes(Node[] nodes, Node[] hospitals)
        {
            foreach (var hospital in hospitals)
            {
                hospital.DijsktraDistance = 0;
            }

            long sum = 0;
            for (int i = 1; i < nodes.Length; i++)
            {
                sum += nodes[i].DijsktraDistance;
            }

            return sum;
        }
    }

    class Node : IComparable
    {
        public int ID { get; set; }
        public long DijsktraDistance { get; set; }

        public Node(int id, long dijkstraDistance)
        {
            this.ID = id;
            this.DijsktraDistance = dijkstraDistance;
        }

        public int CompareTo(object obj)
        {
            return this.DijsktraDistance.CompareTo((obj as Node).DijsktraDistance);
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

    class Connection
    {
        public Node Node { get; set; }
        public long Weight { get; set; }

        public Connection(Node node, long weight)
        {
            this.Node = node;
            this.Weight = weight;
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
