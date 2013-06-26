using System;
using System.Collections.Generic;

namespace Tree
{
    public class Node<T> : ICloneable
    {
        public T Value { get; set; }
        public List<Node<T>> Children { get; private set; }
        public bool HasParent { get; set; }

        public Node(T value)
        {
            this.Value = value;
            this.Children = new List<Node<T>>();
            this.HasParent = false;
        }

        public void AddChild(Node<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Cannot add null child");
            }

            if (child.HasParent)
            {
                throw new ArgumentException("The child already has a parent");
            }

            child.HasParent = true;
            this.Children.Add(child);
        }

        public Node<T> GetChild(int index)
        {
            return this.Children[index];
        }

        public Node<T> Clone()
        {
            if (this == null)
            {
                throw new ArgumentNullException("Can't copy a null node");
            }

            Node<T> clone = new Node<T>(this.Value);
            foreach (var child in this.Children)
            {
                clone.Children.Add(child.Clone());
            }

            return clone;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
