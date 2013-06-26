using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyStack
{
    public class StaticStack<T> : IEnumerable<T>, ICloneable
    {
        private const int DefaultCapacity = 8;

        private T[] arr;
        private int top; // an index that points to the top of the stack
        private int count;

        public StaticStack()
            : this(DefaultCapacity)
        {
        }

        public StaticStack(int capacity)
        {
            this.arr = new T[capacity];
            this.top = -1;
            this.count = 0;
        }

        /// <summary>
        /// Gets the number of elements contained in the StaticStack
        /// </summary>
        /// <returns>
        /// The number of elements contained in the StaticStack
        /// </returns>
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        /// <summary>
        /// Inserts an object at the top of the StaticStack
        /// </summary>
        /// <param name="item">
        /// The object to push onto the StaticStack.
        /// The value can be null for reference types.
        /// </param>
        public void Push(T item)
        {
            if (this.count == this.arr.Length)
            {
                this.DoubleResize();
            }

            this.top++;
            this.count++;
            this.arr[top] = item;
        }

        /// <summary>
        /// Removes and returns the object at the top of the StaticStack.
        /// </summary>
        /// <returns>
        /// The object removed from the top of the System.Collections.Generic.Stack<T>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// The stack is empty
        /// </exception>
        public T Pop()
        {
            if (this.count == 0)
            {
                // The stack is empty
                throw new InvalidOperationException("The stack is empty");
            }

            T result = this.arr[top];
            this.top--;
            this.count--;

            return result;
        }

        /// <summary>
        /// Returns the object at the top of the StaticStack.
        /// </summary>
        /// <returns>
        /// The object at the top of the StaticStack.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// The stack is empty.
        /// </exception>
        public T Peek()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return this.arr[top];
        }

        /// <summary>
        /// Removes all objects from the StaticStack
        /// </summary>
        public void Clear()
        {
            this.arr = new T[DefaultCapacity];
            this.top = -1;
            this.count = 0;
        }

        /// <summary>
        /// Returns a deep copy of the StaticStack
        /// </summary>
        /// <returns>
        /// A deep copy of the StaticStack
        /// </returns>
        public object Clone()
        {
            StaticStack<T> clone = new StaticStack<T>(this.count);
            for (int i = 0; i < this.count; i++)
            {
                clone.Push(this.arr[i]);
            }

            return clone;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = this.count - 1; i >= 0; i--)
            {
                result.Append(this.arr[i]);
            }

            return result.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.count - 1; i >= 0; i--)
            {
                yield return this.arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void DoubleResize()
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
