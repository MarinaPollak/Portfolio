
# C# Coding Solutions

This project contains multiple C# solutions to common coding problems. Each solution includes efficient methods with explanations and code examples.

## Table of Contents
1. [Overview](#overview)
2. [Sum of Two Integers in an Array](#sum-of-two-integers-in-an-array)
3. [Sum of Two Linked Lists](#sum-of-two-linked-lists)
4. [Palindrome Integer Checker](#palindrome-integer-checker)

## Overview

This project includes the following solutions:
- **Sum of Two Integers in an Array**: Finds two numbers in an array that add up to a specified target.
- **Sum of Two Linked Lists**: Adds two non-empty linked lists representing integers in reverse order and returns their sum as a linked list.
- **Palindrome Integer Checker**: Determines if a given integer is a palindrome.

## Sum of Two Integers in an Array

Given an array of integers, the task is to find two numbers that add up to a specific target.

### Code Explanation

The method uses a dictionary to store numbers as we iterate through the array, allowing us to find the complement (target - current number) in constant time.

### Code Example

```csharp
using System;
using System.Collections.Generic;

public static int[] TwoSum(int[] nums, int target)
{
    Dictionary<int, int> map = new Dictionary<int, int>();
    for (int i = 0; i < nums.Length; i++)
    {
        int complement = target - nums[i];
        if (map.ContainsKey(complement))
        {
            return new int[] { map[complement], i };
        }
        map[nums[i]] = i;
    }
    return new int[0]; // Return empty array if no solution is found
}
```

### Usage

1. Pass an integer array and a target integer to the `TwoSum` method.
2. The method returns an array with the indices of the two numbers that add up to the target.

### Example

- Input: `nums = [2, 7, 11, 15], target = 9` → Output: `[0, 1]`

---

## Sum of Two Linked Lists

This solution adds two numbers represented by two non-empty linked lists. The digits are stored in reverse order, and each node contains a single digit.

### Code Explanation

- The solution uses a loop to traverse both linked lists while keeping track of any "carry" from the previous addition.
- Each digit is summed and added to a new linked list.

### Code Example

```csharp
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode dummy = new ListNode();
        ListNode current = dummy;
        int carry = 0;

        while (l1 != null || l2 != null)
        {
            int x = (l1 != null) ? l1.val : 0;
            int y = (l2 != null) ? l2.val : 0;
            int sum = x + y + carry;
            carry = sum / 10;
            current.next = new ListNode(sum % 10);
            current = current.next;

            if (l1 != null) l1 = l1.next;
            if (l2 != null) l2 = l2.next;
        }

        if (carry > 0)
        {
            current.next = new ListNode(carry);
        }

        return dummy.next;
    }
}
```

### Usage

1. Create two linked lists representing numbers in reverse order.
2. Call the `AddTwoNumbers` method with the linked lists as arguments.
3. The method returns a linked list representing the sum.

### Example

- Input: `l1 = [2, 4, 3], l2 = [5, 6, 4]` → Output: `[7, 0, 8]` (represents 807)

---

## Palindrome Integer Checker

This solution checks if an integer is a palindrome (reads the same backward as forward).

### Code Explanation

The method reverses half of the integer and checks if it matches the other half, which allows the solution to avoid reversing the entire integer.

### Code Example

```csharp
public static bool IsPalindrome(int x)
{
    if (x < 0 || (x % 10 == 0 && x != 0))
    {
        return false;
    }

    int reversedHalf = 0;
    while (x > reversedHalf)
    {
        reversedHalf = reversedHalf * 10 + x % 10;
        x /= 10;
    }

    return x == reversedHalf || x == reversedHalf / 10;
}
```

### Usage

1. Pass an integer to the `IsPalindrome` method.
2. The method returns `true` if the integer is a palindrome, `false` otherwise.

### Example

- Input: `x = 121` → Output: `true`
- Input: `x = -121` → Output: `false`

---

## Error Handling

- **Sum of Two Integers in an Array**: Returns an empty array if no solution is found.
- **Sum of Two Linked Lists**: Handles numbers of different lengths and adds any remaining carry to the result.
- **Palindrome Integer Checker**: Returns `false` if the integer is negative or has a trailing zero (unless it’s `0`). For invalid input, `int.TryParse` is used to ensure safe conversion.

