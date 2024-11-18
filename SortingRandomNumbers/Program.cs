namespace SortingRandomNumbers
{
    internal class Program
    {
        
        static void Main()
        {
            // Generate a list of random ComparableNumbers
            Random rand = new Random();
            List<ComparableNumber> numbers = new List<ComparableNumber>(); // Create a list of ComparableNumbers
            for (int i = 0; i < 10; i++) // Loop 10 times
            {
                numbers.Add(new ComparableNumber(rand.Next(1, 101))); // Add a new ComparableNumber with a random value
            }

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

        /// <summary>
        /// Bubble sort algorithm, works by repeatedly swapping adjacent elements
        /// </summary>
        /// <param name="arr"></param>
        static void BubbleSort(List<ComparableNumber> arr)
        {
            int n = arr.Count; // Get the number of elements in the list
            for (int i = 0; i < n - 1; i++) // Loop through the list
            {
                for (int j = 0; j < n - i - 1; j++) // Loop through the unsorted portion of the list
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0) // Compare adjacent elements
                    {
                        // Swap the elements using tuple deconstruction
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
                Console.WriteLine("Step " + (i + 1) + ": " + string.Join(", ", arr));
            }
        }

        /// <summary>
        /// Selection sort algorithm,
        /// works by repeatedly selecting the minimum element
        /// from the unsorted portion of the array
        /// </summary>
        /// <param name="arr"></param>
        static void SelectionSort(List<ComparableNumber> arr)
        {
            int n = arr.Count; // Get the number of elements in the list
            for (int i = 0; i < n - 1; i++) // Loop through the list
            {
                int minIdx = i; // Assume the current index is the minimum
                for (int j = i + 1; j < n; j++) // Loop through the unsorted portion of the list
                {
                    if (arr[j].CompareTo(arr[minIdx]) < 0) // Compare the current element with the minimum
                    {
                        minIdx = j;
                    }
                }
                // Swap the elements using tuple deconstruction
                (arr[minIdx], arr[i]) = (arr[i], arr[minIdx]);

                Console.WriteLine("Step " + (i + 1) + ": " + string.Join(", ", arr));
            }
        }

        /// <summary>
        /// Insertion sort algorithm,
        /// works by building a sorted array one element at a time
        /// </summary>
        /// <param name="arr"></param>
        static void InsertionSort(List<ComparableNumber> arr)
        {
            int n = arr.Count; // Get the number of elements in the list
            for (int i = 1; i < n; i++) // Loop through the list starting from the second element
            {
                var key = arr[i]; // Get the current element
                int j = i - 1; // Get the index of the previous element
              
                while (j >= 0 && arr[j].CompareTo(key) > 0) // Compare the previous element with the current element
                {
                    arr[j + 1] = arr[j]; // Move the previous element to the next position
                    j--; // Move to the next previous element
                }
                arr[j + 1] = key; // Insert the current element in the correct position

                Console.WriteLine("Step " + i + ": " + string.Join(", ", arr)); // Print the current step
            }
        }
    }
}

