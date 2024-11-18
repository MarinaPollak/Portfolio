
# Sorting Numbers in C#

This project implements three common sorting algorithms—**Bubble Sort**, **Selection Sort**, and **Insertion Sort**—to sort a list of random numbers. The project demonstrates how to work with a custom class (`ComparableNumber`) implementing the `IComparable` interface to enable sorting based on user-defined comparison logic.

---

## **Table of Contents**
1. [Overview](#overview)
2. [Features](#features)
3. [Code Structure](#code-structure)
4. [Sorting Algorithms](#sorting-algorithms)
   - [Bubble Sort](#bubble-sort)
   - [Selection Sort](#selection-sort)
   - [Insertion Sort](#insertion-sort)
5. [How to Run](#how-to-run)
6. [Example Output](#example-output)
7. [License](#license)

---

## **Overview**

This application:
- Generates a list of random integers using the `Random` class.
- Wraps these integers in a `ComparableNumber` class, which implements the `IComparable` interface to allow sorting.
- Demonstrates the step-by-step execution of three sorting algorithms:
  - Bubble Sort
  - Selection Sort
  - Insertion Sort

Each step of the sorting process is printed to the console for better understanding.

---

## **Features**

1. **Randomized Input**:
   - Generates a list of random integers between 1 and 100.
2. **Custom Comparable Class**:
   - Demonstrates the use of `IComparable` for sorting.
3. **Sorting Algorithms**:
   - Each step of sorting is shown to understand the process.

---

## **Code Structure**

- `ComparableNumber`:
  - Implements the `IComparable` interface for custom sorting logic.
  - Contains a `Value` property and a `CompareTo` method.
- `Program`:
  - Generates random numbers and stores them in a `List<ComparableNumber>`.
  - Contains implementations of Bubble Sort, Selection Sort, and Insertion Sort algorithms.

---

## **Sorting Algorithms**

### **Bubble Sort**
- Repeatedly compares adjacent elements in the list and swaps them if they are in the wrong order.
- Moves the largest unsorted element to its correct position at the end in each pass.

### **Selection Sort**
- Finds the minimum element in the unsorted part of the list and swaps it with the first unsorted element.
- Repeats the process, growing the sorted portion of the list.

### **Insertion Sort**
- Takes one element at a time, compares it with elements in the sorted portion of the list, and inserts it into the correct position.
- Shifts elements in the sorted portion to make room for the new element.

---

## **How to Run**

1. Clone or download this project to your local machine.
2. Open the solution in your preferred C# IDE (e.g., Visual Studio).
3. Build and run the program.

---

## **Example Output**

```
Original List: 45, 12, 89, 67, 23, 34, 56, 78, 11, 90

Bubble Sort Steps:
Step 1: 12, 45, 67, 23, 34, 56, 78, 11, 89, 90
Step 2: 12, 23, 34, 45, 56, 11, 67, 78, 89, 90
...

Selection Sort Steps:
Step 1: 11, 45, 89, 67, 23, 34, 56, 78, 12, 90
Step 2: 11, 12, 89, 67, 23, 34, 56, 78, 45, 90
...

Insertion Sort Steps:
Step 1: 12, 45, 89, 67, 23, 34, 56, 78, 11, 90
Step 2: 12, 23, 34, 45, 56, 67, 89, 78, 11, 90
...
```

---

## **License**

This project is licensed under the MIT License. See `LICENSE` for more details.
