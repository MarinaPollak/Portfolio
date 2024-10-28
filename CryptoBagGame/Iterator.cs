using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBagGame
{
    public class Iterator<T>
    {
        private List<T> elements;
        private Random random;

        public Iterator(LinkedList<T> linkedList)
        {
            elements = linkedList.ToList();
            random = new Random();
        }

        public bool IsEmpty()
        {
            return elements.Count == 0;
        }

        public T Next()
        {
            if (IsEmpty()) throw new InvalidOperationException("No more elements in the bag.");

            int randomIndex = random.Next(elements.Count);
            T item = elements[randomIndex];

            // Remove the item from the list to avoid repetition in this iteration session
            elements.RemoveAt(randomIndex);

            return item;
        }
    }

}
