using System.Security.Cryptography.X509Certificates;

namespace LeetCodeProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;

            int[] result = TwoSum(nums, target);

            // Check if a result was found and display it
            if (result.Length > 0)
            {
                Console.WriteLine($"Indices: [{result[0]}, {result[1]}]");
            }
            else
            {
                Console.WriteLine("No two sum solution");
            }


            // Initialize the AddTwoNumbers class
           Solution addTwoNumbers = new Solution();

            // Create two linked lists representing the numbers
            ListNode list1 = new ListNode(2, new ListNode(4, new ListNode(3))); // Represents 342
            ListNode list2 = new ListNode(5, new ListNode(6, new ListNode(4))); // Represents 465

            // Add the two numbers
            ListNode result1 = addTwoNumbers.AddTwoNumbers(list1, list2);
            // Print the result
            Console.Write("Result: ");
            PrintList(result1);


            Console.WriteLine("Enter a number to check if it's a palindrome:");
            string input = Console.ReadLine();  // Read user input as a string

            // Convert the input to an integer
            if (int.TryParse(input, out int x))
            {
                Solution isPolindrom = new Solution();
                isPolindrom.IsPalindrome(x);
                bool result2 = isPolindrom.IsPalindrome(x);
                Console.WriteLine($"Is {x} a palindrome? {result2}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

        }


        // Helper method to print the linked list
        static void PrintList(ListNode node)
        {
            while (node != null)
            {
                Console.Write(node.val);
                if (node.next != null)
                {
                    Console.Write(" -> ");
                }
                node = node.next;
            }
            Console.WriteLine();
        }



        static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                map[nums[i]] = i;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement) && map[complement] != i)
                {
                    return new int[] { i, map[complement] };
                }
            }

            // If no valid pair is found, return an empty array
            return new int[] { };
        }


       
    }


}
