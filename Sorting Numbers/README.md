# Sorting Algorithms in C#

## Project Overview
This project demonstrates six common sorting algorithms implemented in C#. It uses a dataset of 474 scores from a text file (`scores.txt`) and sorts them using each algorithm. The project also measures the performance of each algorithm in terms of execution time.

## Algorithms Implemented
1. **Bubble Sort**
   - **Description**: Repeatedly compares adjacent elements and swaps them if they are in the wrong order.
   - **Best Case Complexity**: O(n) (already sorted)
   - **Worst Case Complexity**: O(n²)
   - **Pseudocode**:
     ```
     for i from 0 to n-1:
         for j from 0 to n-i-1:
             if arr[j] > arr[j+1]:
                 swap(arr[j], arr[j+1])
     ```

2. **Selection Sort**
   - **Description**: Finds the minimum element from the unsorted part of the list and places it at the beginning.
   - **Best and Worst Case Complexity**: O(n²)
   - **Pseudocode**:
     ```
     for i from 0 to n-1:
         min_index = i
         for j from i+1 to n:
             if arr[j] < arr[min_index]:
                 min_index = j
         swap(arr[min_index], arr[i])
     ```

3. **Insertion Sort**
   - **Description**: Builds the sorted array one item at a time by shifting elements.
   - **Best Case Complexity**: O(n) (already sorted)
   - **Worst Case Complexity**: O(n²)
   - **Pseudocode**:
     ```
     for i from 1 to n:
         key = arr[i]
         j = i - 1
         while j >= 0 and arr[j] > key:
             arr[j+1] = arr[j]
             j = j - 1
         arr[j+1] = key
     ```

4. **Heap Sort**
   - **Description**: Uses a binary heap to repeatedly extract the maximum element.
   - **Best and Worst Case Complexity**: O(n log n)
   - **Pseudocode**:
     ```
     buildHeap(arr)
     for i from n-1 to 0:
         swap(arr[0], arr[i])
         heapify(arr, i, 0)
     ```

5. **Quick Sort**
   - **Description**: Uses a pivot element to partition the array and recursively sorts each partition.
   - **Best Case Complexity**: O(n log n)
   - **Worst Case Complexity**: O(n²) (poor pivot selection)
   - **Pseudocode**:
     ```
     if low < high:
         pivot = partition(arr, low, high)
         quickSort(arr, low, pivot - 1)
         quickSort(arr, pivot + 1, high)
     ```

6. **Merge Sort**
   - **Description**: Divides the array into halves, recursively sorts them, and then merges the sorted halves.
   - **Best and Worst Case Complexity**: O(n log n)
   - **Pseudocode**:
     ```
     if left < right:
         mid = (left + right) / 2
         mergeSort(arr, left, mid)
         mergeSort(arr, mid+1, right)
         merge(arr, left, mid, right)
     ```

## Performance Measurement
The application uses the C# `Stopwatch` class to measure the execution time of each algorithm. Results are displayed in milliseconds for comparison.


## How to Run
1. Clone the repository.
2. Place the `scores.txt` file in the `files` directory.
3. Build and run the project using .NET 6.0 or higher.

## Example Output

<img width="1162" alt="Screenshot 2024-11-18 at 3 49 34 PM" src="https://github.com/user-attachments/assets/7bf063ef-9f1c-44a1-aa44-7b7022c2681e">
