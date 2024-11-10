# Big O Notation Demo

This project demonstrates different types of time complexities (Big O notation) in C#. The examples include constant time, linear time, and quadratic time complexity.

## Overview

This project contains methods to demonstrate the following:
- **Constant Time Complexity O(1)**: Shows operations that always take the same amount of time, regardless of input size.
- **Linear Time Complexity O(n)**: Demonstrates operations that scale linearly with input size.
- **Quadratic Time Complexity O(n^2)**: Uses nested loops to show operations that scale quadratically with input size.

The code examples are provided to help understand the behavior and runtime of these different time complexities.

## Code Overview

The project consists of the following key methods:

1. **ConstantTimeComplexity()**
   - Prints messages, performs simple arithmetic operations, and accesses array or dictionary elements by index/key.
   - Time Complexity: **O(1)**, as the runtime remains constant regardless of the input size.

   ```csharp
   int[] array = { 1, 2, 3, 4, 5 };
   int element = array[2]; // Accessing the third element - O(1)
   
   Dictionary<string, int> dictionary = new Dictionary<string, int>{ {"apple", 1}, {"banana", 2}, {"cherry", 3} };
   int value = dictionary["banana"]; // O(1)
   ```

2. **LinearTimeComplexity()**
   - Iterates through each element in an array.
   - Time Complexity: **O(n)**, where **n** is the number of elements in the array. As **n** increases, the number of iterations also increases linearly.

   ```csharp
   int[] array = new int[] { 1, 2, 3, 4, 5 };
   foreach (var t in array)
   {
       Console.WriteLine(t.ToString()); // O(n)
   }
   ```

3. **HasDuplicates()** Quadratic Notation
   - Checks for duplicate values in an array using a nested loop.
   - Time Complexity: **O(n^2)**, as the nested loops iterate through the array in a pairwise manner, resulting in a quadratic number of operations.

   ```csharp
   int[] array = { 1, 2, 3, 4, 5, 1 };
   for (int i = 0; i < array.Length; i++)
   {
       for (int j = i + 1; j < array.Length; j++)
       {
           if (array[i] == array[j])
           {
               Console.WriteLine("The " + array[i] + " is equal to " + array[j]);
               return true; // O(n^2)
           }
       }
   }
   ```

## How to Run

1. Clone the repository or download the project files.
2. Open the project in Visual Studio or your favorite C# development environment.
3. Build and run the project to see the output of each method and understand the time complexities involved.

## Big O Notation Differences

- **Constant Time Complexity O(1)**:
  - The runtime is constant and does not depend on input size.
  - Example: Accessing an element in an array by index or performing a simple arithmetic operation.

- **Linear Time Complexity O(n)**:
  - The runtime grows linearly with the size of the input.
  - Example: Iterating through every element in an array.

- **Quadratic Time Complexity O(n^2)**:
  - The runtime is proportional to the square of the input size.
  - Example: Nested loops that iterate through all pairs of elements in an array to find duplicates.

## Key Takeaways

- Understanding Big O notation is crucial for evaluating the efficiency of algorithms.
- Different time complexities impact the scalability of your solution as input sizes increase.
- Constant time operations are the most efficient, while quadratic operations should be avoided for large inputs due to the significant performance costs.

Feel free to modify the code to explore other types of time complexities!

## License
This project is open source and available under the [MIT License](LICENSE).
