# Palindrome Integer Checker

This project contains a C# program that checks if an integer is a palindrome. It uses integer manipulation to achieve an efficient solution, and this README will guide you through the code, setup, and explanations for each component.

## Table of Contents
1. [Overview](#overview)
2. [Solution Explanation](#solution-explanation)
3. [Code Breakdown](#code-breakdown)
4. [Usage](#usage)
5. [Examples](#examples)
6. [Error Handling](#error-handling)

## Overview

A **palindromic integer** is one that reads the same forward and backward (e.g., `121` is a palindrome, but `123` is not). This project solves the problem by reversing half of the integer and checking if the original half matches the reversed half, which is efficient in both time and space complexity.

## Solution Explanation

The main idea is to reverse half of the number and then compare the reversed half with the original half. This avoids reversing the entire number, saving memory and making the solution more efficient.

### Steps of the Solution
1. **Handle Edge Cases**:
   - If the number is negative, it is not a palindrome.
   - If the number ends with `0` but is not `0`, it cannot be a palindrome.

2. **Reverse Half of the Number**:
   - Use the modulo operator (`%`) to extract the last digit of the number.
   - Add this last digit to `reversedHalf` while progressively dividing `x` by `10` to remove the last digit.
   - Continue until `x` is less than or equal to `reversedHalf`.

3. **Check for Palindromic Condition**:
   - If `x` equals `reversedHalf` (for even-length numbers) or `x` equals `reversedHalf / 10` (for odd-length numbers), the number is a palindrome.

## Code Breakdown

### Program.cs

```csharp
using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a number to check if it's a palindrome:");
        string input = Console.ReadLine();  // Read user input as a string

        // Convert the input to an integer
        if (int.TryParse(input, out int x))
        {
            bool isPalindrome = IsPalindrome(x);
            Console.WriteLine($"Is {x} a palindrome? {isPalindrome}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    // Define the IsPalindrome method
    public static bool IsPalindrome(int x)
    {
        // Negative numbers and numbers ending in zero (except zero itself) are not palindromes
        if (x < 0 || (x % 10 == 0 && x != 0))
        {
            return false;
        }

        int reversedHalf = 0;
        while (x > reversedHalf)
        {
            // Add the last digit of x to reversedHalf
            reversedHalf = reversedHalf * 10 + x % 10;
            // Remove the last digit from x
            x /= 10;
        }

        // Check if the number is a palindrome
        return x == reversedHalf || x == reversedHalf / 10;
    }
}
```

## Usage

1. Compile and run the program.
2. Input an integer when prompted to check if it’s a palindrome.
3. The program will output `true` if the integer is a palindrome and `false` otherwise.

## Examples

- Input: `121` → Output: `true`
- Input: `-121` → Output: `false`
- Input: `10` → Output: `false`

## Error Handling

If the user enters a non-integer input, the program will display an error message prompting for a valid integer.
