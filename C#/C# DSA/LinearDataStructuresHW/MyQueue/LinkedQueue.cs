using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyQueue
{
    public class LinkedQueue<T> : IEnumerable<T>, ICloneable
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }

            public Node(T value)
            {
                this.Value = value;
                this.Next = null;
            }

            public Node(T value, Node previous)
            {
                this.Value = value;
                this.Next = null;
                previous.Next = this;
            }
        }

        private Node front;
        private Node back;
        private int count;

        public LinkedQueue()
        {
            this.front = null;
            this.back = null;
            this.count = 0;
        }

        /// <summary>
        /// Gets the number of elements in the queue
        /// </summary>
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        /// <summary>
        /// Adds a new item at the end of the queue
        /// </summary>
        /// <param name="item">
        /// The item that will be added.
        /// The value can be null for reference types
        /// </param>
        public void Enqueue(T item)
        {
            if (this.front == null)
            {
                // We have empty queue
                this.front = new Node(item);
                this.back = this.front;
            }
            else
            {
                Node newNode = new Node(item, this.back);
                this.back = newNode;
            }

            this.count++;
        }

        /// <summary>
        /// Removes the first element of the queue
        /// </summary>
        /// <returns>The removed element</returns>
        /// <exception cref="InvalidOperationException">
        /// Throws an InvalidOperationException if the queue is empty
        /// </exception>
        public T Dequeue()
        {
            if (this.count == 0)
            {
                // We have empty queue
                throw new InvalidOperationException("The queue is empty");
            }

            T result = this.front.Value;
            this.front = this.front.Next;
            this.count--;

            return result;
        }

        /// <summary>
        /// Gets the first element of the queue without removing it
        /// </summary>
        /// <returns>The first element of the queue</returns>
        /// <exception cref="InvalidOperationException">
        /// Throws an InvalidOperationException if the queue is empty
        /// </exception>
        public T Peek()
        {
            if (this.count == 0)
            {
                // We have empty queue
                throw new InvalidOperationException("The queue is empty");
            }

            return this.front.Value;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            Node currentNode = this.front;
            while (currentNode != null)
            {
                result.Append(currentNode.Value);
                currentNode = currentNode.Next;
            }

            return result.ToString();
        }

        public T[] ToArray()
        {
            T[] result = new T[this.count];

            Node currentNode = this.front;
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = currentNode.Value;
                currentNode = currentNode.Next;
            }

            return result;
        }

        /// <summary>
        /// Makes the queue empty
        /// </summary>
        public void Clear()
        {
            this.front = null;
            this.back = null;
            this.count = 0;
        }

        /// <summary>
        /// Makes a deep copy of the queue
        /// </summary>
        /// <returns>A deep copy of the queue</returns>
        public object Clone()
        {
            LinkedQueue<T> clone = new LinkedQueue<T>();

            Node currentNode = this.front;
            while (currentNode != null)
            {
                // We have non-empty queue
                clone.Enqueue(currentNode.Value);
                currentNode = currentNode.Next;
            }

            return clone;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = this.front;
            while (currentNode != null)
            {
                T result = currentNode.Value;
                currentNode = currentNode.Next;

                yield return result;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
