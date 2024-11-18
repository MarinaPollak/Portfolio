namespace Sorting_Numbers
{
    internal class Program
    {
        static void Main()
        {
            // Generate a list of random ComparableNumbers
            Random rand = new Random();
            List<ComparableNumber> numbers = new List<ComparableNumber>();
            for (int i = 0; i < 10; i++)
            {   // Generate random numbers between 1 and 100,using the ComparableNumber class
                numbers.Add(new ComparableNumber(rand.Next(1, 101)));
            }
            // Display the original list, using the string.Join method to concatenate the numbers
            Console.WriteLine("Original List: " + string.Join(", ", numbers));

            // Bubble Sort
            Console.WriteLine("\nBubble Sort Steps:");
            BubbleSort(new List<ComparableNumber>(numbers));

            // Selection Sort
            Console.WriteLine("\nSelection Sort Steps:");
            SelectionSort(new List<ComparableNumber>(numbers));

            // Insertion Sort
            Console.WriteLine("\nInsertion Sort Steps:");
            InsertionSort(new List<ComparableNumber>(numbers));
        }

        // ComparableNumber class implementing IComparable

        /// <summary>
        /// Bubble Sort algorithm
        /// </summary>
        /// <param name="arr"> New List with random numbers </param>
        static void BubbleSort(List<ComparableNumber> arr)
        {
            int n = arr.Count; // Get the number of elements in the list

            // Outer loop for passes
            for (int i = 0; i < n - 1; i++)
            {
                // Inner loop to compare adjacent elements
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        // Swap via deconstruction
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
                Console.WriteLine("Step " + (i + 1) + ": " + string.Join(", ", arr));
            }
        }

        /// <summary>
        /// Selection Sort algorithm that sorts a list of ComparableNumbers
        /// by finding the minimum element from the unsorted part of the list
        /// and swapping it with the first element of the unsorted part
        /// </summary>
        /// <param name="arr">arr is a list of ComparableNumbers</param>
        static void SelectionSort(List<ComparableNumber> arr)
        {
            int n = arr.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i;
                //Loop throught starting from the next element
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j].CompareTo(arr[minIdx]) < 0)
                    {
                        minIdx = j;
                    }
                }
                // Swap via deconstruction
                (arr[minIdx], arr[i]) = (arr[i], arr[minIdx]);

                Console.WriteLine("Step " + (i + 1) + ": " + string.Join(", ", arr));
            }
        }

        /// <summary>
        /// Insertion Sort algorithm that sorts a list of ComparableNumbers
        /// by taking one element at a time, comparing it with the elements to its left,
        /// and if it is smaller, shifting the elements to the right
        /// </summary>
        /// <param name="arr"> arr is a list of ComparableNumbers </param>
        static void InsertionSort(List<ComparableNumber> arr)
        {   // Get the number of elements in the list
            int n = arr.Count;
            //Go through the list starting from the second element
            for (int i = 1; i < n; i++)
            {  // Get the current element that needs to be inserted
                var key = arr[i];
                int j = i - 1;// Get the index of the element to the left of the current element
                // Compare the current element with the elements to its left
                //If CompareTo returns a value greater than 0, it means arr[j] > key.
                while (j >= 0 && arr[j].CompareTo(key) > 0)
                {   
                    arr[j + 1] = arr[j]; // Shift the elements to the right
                    j--; // moves the pointer to the previous element,
                         // so we can check the next element in the sorted portion.
                }
                arr[j + 1] = key;

                Console.WriteLine("Step " + i + ": " + string.Join(", ", arr));
            }
        }
    }
}
