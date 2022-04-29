using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LinkedList
{
    internal sealed class LinkedList<T> : IEnumerable<T>, IEquatable<LinkedList<T>>
    {
        private Node<T> head;
        private Node<T> tail;
        
        public Node<T> Head
        {
            get => head;
            private set => head = value;
        }
        public Node<T> Tail
        {
            get => tail;
            private set => tail = value;
        }
        public int Count
        {
            get
            {
                int count = default;
                Node<T> current = Head;

                while (current != null)
                {
                    current = current.Next;
                    count++;
                }

                return count;
            }
        }
        
        public LinkedList() { }
        public LinkedList(params T[] items)
        {
            for (int i = 0; i < items.Length; i++)
                Add(items[i]);
        }

        public void Clear() => Head = Tail = null;
        public bool Contains(T item)
        {
            Node<T> current = Head;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }
        public void Add(T item)
        {
            Node<T> temp = new Node<T>(item, null);

            if (Tail != null)
            {
                Tail.Next = temp;
                Tail = temp;
            }
            else
            {
                Head = Tail = temp;
            }
        }
        public void AddHead(T item)
        {
            Node<T> temp = new Node<T>(item, Head);
            Head = temp;
        }
        public bool Delete(T item)
        {
            bool result = false;
            if (Head != null)
            {
                Node<T> current = Head.Next;
                Node<T> previous = Head;
                

                if (Head.Data.Equals(item))
                {
                    Head = Head.Next;
                    result = true;
                }

                while (current != null) 
                {
                    if (current.Data.Equals(item))
                    {
                        previous.Next = current.Next;
                        result = true;
                    }
                    previous = previous.Next;
                    current = current.Next;
                }
            }
            return result;
        }
        public bool Equals([AllowNull] LinkedList<T> other)
        {
            if (other != null)
            {
                if (Count.Equals(other.Count))
                {
                    Node<T> current = Head;
                    Node<T> otherCurrent = other.Head;

                    while (current != null)
                    {
                        if (!current.Data.Equals(otherCurrent.Data))
                        {
                            return false;
                        }
                        otherCurrent = otherCurrent.Next;
                        current = current.Next;
                    }

                    return true;
                }

            }
            return false;
        }
        public sealed override string ToString()
        {
            Node<T> current = Head;
            StringBuilder stringBuilder = new StringBuilder("LinkedList: {\t");

            while (current != null)
            {
                stringBuilder.Append(current.Data);
                stringBuilder.Append("\t");
                current = current.Next;
            }

            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }
        public sealed override bool Equals(object obj)
        {
            if (obj is LinkedList<T> other)
            {
                return Equals(other);
            }

            return false;
        }
        public sealed override int GetHashCode()
        {
            Node<T> current = Head;
            int hashCode = default;

            while (current != null)
            {
                hashCode += current.Data.GetHashCode();
                current = current.Next;
            }

            return hashCode;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
