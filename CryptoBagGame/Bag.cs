using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBagGame
{
    public class Bag<T>
    {
        private LinkedList<T> items;

        public Bag()
        {
            items = new LinkedList<T>();
        }

        public void Add(T element)
        {
            items.Add(element);
        }

        public int Size()
        {
            return items.Size;
        }

        // Method to return a new iterator instance
        public Iterator<T> GetIterator()
        {
            return new Iterator<T>(items);
        }
    }

}
