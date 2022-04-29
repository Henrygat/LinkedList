using System;
using System.Diagnostics.CodeAnalysis;

namespace LinkedList
{
    internal sealed class Node<T> : IEquatable<Node<T>>
    {
        private Node<T> next;
        private T data;

        public Node<T> Next
        {
            get => next;
            set => next = value;
        }
        public T Data
        {
            get => data;
            set => data = value != null ? value : throw new ArgumentNullException(nameof(value));
        }

        public Node() : this(default(T), default(Node<T>)) { }
        public Node(T data, Node<T> next)
        {
            Next = next;
            Data = data;
        }
        public bool Equals([AllowNull] Node<T> other)
        {
            if (other != null)
                return Data.Equals(other.Data);
            else
                return false;
        }
        public sealed override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj is Node<T> other)
                {
                    return Equals(other);
                }
            }
            return false;
        }
        public sealed override int GetHashCode() => Data.GetHashCode();
        public sealed override string ToString() => string.Format("Data: {0}", Data.ToString());
    }
}
