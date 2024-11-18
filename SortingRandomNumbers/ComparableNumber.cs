using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingRandomNumbers
{
    // ComparableNumber class implementing IComparable
    /// <summary>
    /// IComparable interface implementation needed for sorting
    /// ComparableNumber objects using CompareTo method
    /// </summary>
    public class ComparableNumber : IComparable<ComparableNumber>
    {
        //Implementing the value property for the list numbers in Program.cs
        public int Value { get; }

        //Constructor for the ComparableNumber class, 
        //which takes an integer value as a parameter
        //and initializes the Value property
        public ComparableNumber(int value)
        {
            Value = value; //Initialize the Value property
        }

        //CompareTo method implementation for the ComparableNumber class
        public int CompareTo(ComparableNumber other)
        {
            //Compare the Value property of the current object with the Value property of the other object
            return Value.CompareTo(other.Value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
