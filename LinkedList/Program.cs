using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> node = new Node<int>(1, null);
            Node<int> node3 = new Node<int>(1, null);
            Node<double> node2 = new Node<double>(1, null);
            Console.WriteLine(node.Equals((object)5));
            Console.WriteLine(node2);
            
        }
    }
}
