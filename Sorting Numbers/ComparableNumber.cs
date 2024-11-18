using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Numbers
{
    /// <summary>
    /// ComparableNumber class implementing IComparable, used for sorting numbers
    /// IComeparable is used to compare the current object with another object of the same type
    /// </summary>
    public class ComparableNumber : IComparable<ComparableNumber>
    {
        // get the value of the ComparableNumber
        public int Value { get; }

        // Constructor to initialize the value of the ComparableNumber
        public ComparableNumber(int value)
        {
            Value = value;
        }

        // Compare the current ComparableNumber with another ComparableNumber
        //pass the value of the other ComparableNumber to the CompareTo method of the Value property
        public int CompareTo(ComparableNumber other)
        {
            return Value.CompareTo(other.Value); //is a built-in comparison for integers.
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
