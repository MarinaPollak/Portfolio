using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBagGame
{
    public class LinkedList<T>
    {
        private Node<T> head;
        public int Size { get; private set; }

        public LinkedList()
        {
            head = null;
            Size = 0;
        }

        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);
            newNode.Next = head;
            head = newNode;
            Size++;
        }

        // Method to return all elements in a list form for iterator access
        public List<T> ToList()
        {
            List<T> items = new List<T>();
            Node<T> current = head;
            while (current != null)
            {
                items.Add(current.Value);
                current = current.Next;
            }
            return items;
        }
    }

}
