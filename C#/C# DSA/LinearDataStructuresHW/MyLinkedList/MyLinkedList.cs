using System;
using System.Collections;
using System.Collections.Generic;

namespace MyLinkedList
{
    public class CustomLinkedList<T> : IList<T>
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

        private Node first;
        private Node last;
        private int count;

        public CustomLinkedList()
        {
            this.first = null;
            this.last = null;
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the element at the current index of the CustomLinkedList
        /// </summary>
        /// <param name="index">The index of the element</param>
        /// <exception cref="IndexOutOfRangeException">
        /// Throws an IndexOutOFRangeException if the index is out of the boundaries
        /// of the CustomLinkedList
        /// </exception>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                {
                    throw new IndexOutOfRangeException("Invalid index " + index);
                }

                Node node = this.GetNode(index);
                return node.Value;
            }

            set
            {
                if (index < 0 || index >= this.count)
                {
                    throw new IndexOutOfRangeException("Invalid index " + index);
                }

                Node node = this.GetNode(index);
                node.Value = value;
            }
        }

        /// <summary>
        /// Returns the index of the element with a given value
        /// </summary>
        /// <param name="value">The value of the element</param>
        /// <returns>
        /// The index of the element if the element was found.
        /// Else it returns -1 if the elements wasn't found.
        /// </returns>
        public int IndexOf(T value)
        {
            int index = 0;
            Node currentNode = this.first;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return index;
                }

                currentNode = currentNode.Next;
                index++;
            }

            return -1;
        }

        /// <summary>
        /// Adds a new element at the end of the CustomLinkedList
        /// </summary>
        /// <param name="value">The value of the element</param>
        public void Add(T value)
        {
            if (this.first == null)
            {
                // We have empty list
                this.first = new Node(value);
                this.last = this.first;
            }
            else
            {
                Node newNode = new Node(value, this.last); // Connect the last node with the new node
                this.last = newNode; // The new node is made the last in the list
            }

            this.count++;
        }

        /// <summary>
        /// Adds a new element at the begining of the CustomLinkedList
        /// </summary>
        /// <param name="value">The value of the element</param>
        public void AddFirst(T value)
        {
            if (this.first == null)
            {
                // We have empty list
                this.first = new Node(value);
                this.last = this.first;
            }
            else
            {
                Node newNode = new Node(value);
                newNode.Next = this.first; // Connect the new node with the first
                this.first = newNode; // The new node is now the first in the list
            }

            this.count++;
        }

        /// <summary>
        /// Adds a new element at the begining of the CustomLinkedList
        /// </summary>
        /// <param name="value">The value of the element</param>
        public void AddLast(T value)
        {
            this.Add(value);
        }

        /// <summary>
        /// Adds a new element in the CustomeLinkedList at the given index
        /// </summary>
        /// <param name="index">The index on which the element will be added</param>
        /// <param name="value">The value of the element</param>
        public void Insert(int index, T value)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }

            if (this.count == 1 || index == 0)
            {
                this.AddFirst(value);
            }
            else
            {
                Node previousNode = this.GetNode(index - 1);
                Node nodeAtIndex = previousNode.Next;
                Node newNode = new Node(value, previousNode); // Connect the previous node with the new node
                newNode.Next = nodeAtIndex; // Connect the new node with the one at the given index

                this.count++;
            }
        }

        /// <summary>
        /// Removes the first occurence of the element with the
        /// given value from the CustomLinkedList
        /// </summary>
        /// <param name="value">The value of the element</param>
        /// <returns>
        /// true - if the element was removed, 
        /// else - if the element wasn't removed(found)</returns>
        public bool Remove(T value)
        {
            bool removed = false;
            int index = this.IndexOf(value);

            if (index != -1)
            {
                this.RemoveAt(index);
                removed = true;
            }

            return removed;
        }

        /// <summary>
        /// Removes the element of the CustomLinkedList at the specified index
        /// </summary>
        /// <param name="index">The index of the element</param>
        /// <exception cref="IndexOutOfRangeException">
        /// Throw an IndexOutOfRangeException if the specified index is
        /// out of the boundaries of the CustomLinkedList
        /// </exception>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }

            if (index == 0 || this.count == 1)
            {
                this.RemoveFirst();
            }
            else if (index == this.count - 1)
            {
                this.RemoveLast();
            }
            else
            {
                Node previousNode = this.GetNode(index - 1);
                Node nodeThatWillBeRemove = previousNode.Next;
                previousNode.Next = nodeThatWillBeRemove.Next; // Connect the previous node with the node after the one that will be removed
                nodeThatWillBeRemove = null; // This will force the garbage collector to delete the node

                this.count--;
            }
        }

        /// <summary>
        /// Removes the first element of the CustomLinkedList
        /// </summary>
        public void RemoveFirst()
        {
            if (this.count == 1 || this.count == 0)
            {
                this.Clear();
            }
            else
            {
                this.first = this.first.Next;
                this.count--;
            }
        }

        /// <summary>
        /// Removes the last element of the CustomLinkedList
        /// </summary>
        public void RemoveLast()
        {
            if (this.count == 1 || this.count == 0)
            {
                this.Clear();
            }
            else
            {
                Node beforeLast = this.GetNode(this.count - 2);
                beforeLast.Next = null;
                this.last = beforeLast;

                this.count--;
            }
        }

        /// <summary>
        /// Empties the list (makes it empty)
        /// </summary>
        public void Clear()
        {
            this.first = null;
            this.last = null;
            this.count = 0;
        }

        /// <summary>
        /// Checks if an element with a specified value is
        /// contained in the CustomLinkedList
        /// </summary>
        /// <param name="value">The value of the element</param>
        /// <returns>
        /// true - the list contains the specified element,
        /// else - otherwise
        /// </returns>
        public bool Contains(T value)
        {
            int index = this.IndexOf(value);
            bool found = (index != -1);

            return found;
        }

        /// <summary>
        /// Copies the list into an array from a specified index to the end of the list.
        /// </summary>
        /// <param name="array">The array</param>
        /// <param name="arrayIndex">The index from which the copying will start</param>
        /// <exception cref="ArgumenNullException">
        /// If the array is null
        /// </exception>
        /// <exception cref="IndexOutOfRangeException">
        /// if the specified index the out of the boundaries of the array, or
        /// if the index + the list.Count is bigged that the arrays.Length
        /// </exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array is null");
            }

            if (arrayIndex < 0 ||
                arrayIndex >= array.Length ||
                arrayIndex + this.Count - 1 >= array.Length)
            {
                throw new IndexOutOfRangeException("Invalid index: " + arrayIndex);
            }

            Node currentNode = this.first;
            while (currentNode != null)
            {
                array[arrayIndex] = currentNode.Value;
                currentNode = currentNode.Next;
                arrayIndex++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currentNode = this.first;

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

        private Node GetNode(int index)
        {
            Node currentNode = this.first;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            return currentNode;
        }
    }
}
