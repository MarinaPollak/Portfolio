# Random Numbers Sorting Program

## Project Overview
This program demonstrates three basic sorting algorithms implemented in C#:
- Bubble Sort
- Selection Sort
- Insertion Sort

The program generates a random list of integers, sorts them using each algorithm, and displays the sorting steps in the console.

## Features
1. **Random Number Generation**:
   - Generates a list of 10 random integers between 1 and 100.
   - Each integer is represented as a `ComparableNumber` object implementing the `IComparable` interface.

2. **Sorting Algorithms**:
   - **Bubble Sort**: Compares adjacent elements and swaps them if they are in the wrong order.
   - **Selection Sort**: Finds the smallest element and places it at the beginning of the list.
   - **Insertion Sort**: Inserts each element into its correct position in the sorted portion of the list.

3. **Console Output**:
   - Displays the original list and step-by-step changes during sorting.


## How to Run
1. Clone the repository or copy the source code.
2. Open the project in Visual Studio or another C# IDE.
3. Build and run the program using .NET 6.0 or higher.

## Class Overview

### `ComparableNumber` Class
The `ComparableNumber` class implements the `IComparable<T>` interface to enable comparisons between integers:
```csharp
public class ComparableNumber : IComparable<ComparableNumber>
{
    public int Value { get; }

    public ComparableNumber(int value)
    {
        Value = value;
    }

    public int CompareTo(ComparableNumber other)
    {
        return Value.CompareTo(other.Value);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
```
### Algorithms
1. Bubble Sort
Description: Repeatedly compares adjacent elements and swaps them if needed.
Pseudocode:
```csharp
for i from 0 to n-1:
    for j from 0 to n-i-1:
        if arr[j] > arr[j+1]:
            swap(arr[j], arr[j+1])
```
2. Selection Sort
Description: Finds the smallest element and moves it to the front.
Pseudocode:
less
```csharp
for i from 0 to n-1:
    min_index = i
    for j from i+1 to n:
        if arr[j] < arr[min_index]:
            min_index = j
    swap(arr[min_index], arr[i])
```
3. Insertion Sort
Description: Inserts each element into its correct position in the sorted portion.
Pseudocode:
less
```csharp
for i from 1 to n:
    key = arr[i]
    j = i - 1
    while j >= 0 and arr[j] > key:
        arr[j+1] = arr[j]
        j = j - 1
    arr[j+1] = key
```
#### Example Output

```csharp
Original List: 72, 45, 89, 37, 56, 12, 81, 63, 94, 29

Bubble Sort Steps:
Step 1: 45, 72, 37, 56, 12, 81, 63, 89, 29, 94
Step 2: 45, 37, 56, 12, 72, 63, 81, 29, 89, 94
...

Selection Sort Steps:
Step 1: 12, 45, 89, 37, 56, 72, 81, 63, 94, 29
Step 2: 12, 29, 89, 37, 56, 72, 81, 63, 94, 45
...

Insertion Sort Steps:
Step 1: 45, 72, 89, 37, 56, 12, 81, 63, 94, 29
Step 2: 37, 45, 72, 89, 56, 12, 81, 63, 94, 29
...
```
#### Summary
This program provides a clear demonstration of basic sorting algorithms with step-by-step output, making it suitable for learning and understanding sorting techniques.

