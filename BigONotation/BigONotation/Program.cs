using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace BigONotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //method that show Constant O(1) time complexity
            ConstantTimeComplexity();
            LinearTimeComplexity();
            bool quadraticTimeComplexity = HasDuplicates();
        }



        private static void ConstantTimeComplexity()
        {
            // Constant Time Complexity are simple operation like operation below
            // Printing a Message
            Console.WriteLine("Constant O(1) time complexity");
            Console.WriteLine("*****************************");

            // Accessing an element in an array by index
            Console.WriteLine("\nAcessing an element in array");
            int[] array = { 1, 2, 3, 4, 5 };
            int element = array[2]; // Accessing the third element
            Console.WriteLine(element);

            //Simple Arithmetic Operation
            Console.WriteLine("\nSimple Arithmetic Operation");
            int a = 5;
            int b = 10;
            int sum = a + b;
            Console.WriteLine(sum);

            //Accessing a dictionary element by key
            Console.WriteLine("\nAccessing a dictionary element by key");
            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                {"apple", 1},
                {"banana", 2},
                {"cherry", 3}
            };

            int value = dictionary["banana"]; // Accessing the value associated with the key "banana"
            Console.WriteLine(value); 

        }

        private static void LinearTimeComplexity()
        {
            //array of size 10
            int[] array = new int[5];
            Console.WriteLine("\nLinear O(n)");
            Console.WriteLine("**************");
            Console.WriteLine("Accessing every element in the array its linear time complexity");
            foreach (var t in array)
            {
                Console.WriteLine(t.ToString());
                
            }

            // array of size 5 with specific values
            var array1 = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine("Accessing every element in the array its linear time complexity");
            foreach (var t in array1)
            {
                Console.WriteLine(t.ToString());
                
            }
        }
        static bool HasDuplicates()
        {
            // Checking for duplicates in an array
            Console.WriteLine("\nQuadratic O(n2)");
            Console.WriteLine("******************");
            Console.WriteLine("Checking for duplicates with nested loop\n");
            int[] array = { 1, 2, 3, 4, 5, 1 };

            //nestood loops respresents quadratic time complexity
            //first for loop iterate through the array with i index
            for (int i = 0; i < array.Length; i++)
            {
                //second for loop iterate through the array with j index
                for (int j = i + 1; j < array.Length; j++)
                {   
                    //if the element at index i is equal to the element at index j
                    if (array[i] == array[j])
                    {
                        Console.WriteLine("The "+ array[i] + " is equal to " + array[j]);
                        Console.WriteLine("The array contains duplicates.");
                        return true;
                    }
                }
            }
            return false;

        }

    }
}
