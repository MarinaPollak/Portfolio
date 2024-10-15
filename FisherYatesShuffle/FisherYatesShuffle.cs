using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherYatesShuffle
{
    public class FisherYatesShuffle
    {

        /// <summary>
        /// --It is common to make random number generators PRIVATE
        /// because you don't want external classes or objects directly modifying or accessing them.
        /// This ensures the integrity of the random number generation.
        /// --By using a STATIC Random,
        /// you ensure that the random number generator is properly reused,
        /// avoiding potential issues with multiple instances generating similar sequences of numbers.
        /// --The READONLY keyword ensures that the _random instance can only be assigned once,
        /// either at the time of declaration (like here) or in the constructor.
        /// Once initialized, the _random field cannot be reassigned to a different object.
        /// </summary>
        ///
        /// By using private static readonly, you're creating a single,
        /// immutable instance of Random that can be used throughout the class without the risk of it being altered or replaced.
        /// This helps avoid common pitfalls with random number generation, such as reusing the same seed or having
        /// multiple generators producing correlated sequences.

        private static readonly Random _random = new();

        //T function is a generic type, used as a placeholder for the actual type

        /// <summary>
        /// The Fisher-Yates shuffle algorithm is an efficient way to shuffle an array of items.
        /// This T function is a generic type, used as a placeholder for the actual type. That reperesents the type of the elements in the array. Which means that the array can be of any type like string or int.
        /// This Shuffle function takes an array of type T and shuffles it by randomly swapping each element with another element in the array. Representing simple Fisher-Yates shuffle algorithm.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void Shuffle<T>(T[] array)
        {   
            //any array of type T length
            int n = array.Length;
            //i is the index of the array
            for (int i = 0; i < n; i++)
            {
                //we need 2 indexes to swap the elements in the array
                //i is first integer index and r is an integer for the second index of the array
                // r equals to a random number i plus a random number between 0 and n minus i
                int r = i + _random.Next(n - i);
                //if the array is not null
                if (array != null)
                {   //
                    (array[i], array[r]) = (array[r], array[i]);
                }
            }
        }
    }
}
