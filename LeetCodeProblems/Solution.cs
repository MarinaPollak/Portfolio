using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LeetCodeProblems.Program;

namespace LeetCodeProblems
{
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(); // Dummy node to hold the result
            ListNode current = dummy; // Pointer to build the result list
            int carry = 0; // To store the carry value

            // Traverse both lists
            while (l1 != null || l2 != null)
            {
                //These expressions check whether l1 or l2 is not null. If l1 (or l2) is not null,
                //that means there is a node in the linked list at this position,
                //and we can safely access its value using l1.val (or l2.val).
                int x = (l1 != null) ? l1.val : 0; //
                int y = (l2 != null) ? l2.val : 0;

                int sum = x + y + carry; // Add the every values in the lists and carry
                carry = sum / 10; // Update the carry

                current.next = new ListNode(sum % 10); // Create a new node with sum % 10
                current = current.next; // Move to the next node

                // Move l1 and l2 pointers if they are not null
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }

            // If there's still a carry left, add a new node with carry
            if (carry > 0)
            {
                current.next = new ListNode(carry);
            }

            return dummy.next; // Return the result list starting from dummy.next
        }


        public bool IsPalindrome(int x)
        {
            // Negative numbers and numbers ending in zero (except zero itself) are not palindromes
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            int reversedHalf = 0;
            while (x > reversedHalf)
            {
                // Add the last digit of x to
                //When you do x % 10, it gives you the remainder when x is divided by 10, which is always the last digit of x.
                reversedHalf = reversedHalf * 10 + x % 10;
                // Remove the last digit from x
                x /= 10;
            }

            // Check if the number is a palindrome
            // For even-length numbers, x should equal reversedHalf
            // For odd-length numbers, we remove the middle digit by reversedHalf / 10
            return x == reversedHalf || x == reversedHalf / 10;
        }
    }
}
