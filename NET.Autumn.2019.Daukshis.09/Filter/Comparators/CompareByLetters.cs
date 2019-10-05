using System;
using System.Collections.Generic;

namespace Filter.Comparators
{
    public class CompareByLetters : IComparer<string>
    {
        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// A signed integer that indicates the relative values of <paramref name="x">x</paramref> and <paramref name="y">y</paramref>, as shown in the following table.
        /// Value
        /// Meaning
        /// Less than zero
        /// <paramref name="x">x</paramref> is less than <paramref name="y">y</paramref>.
        /// Zero
        /// <paramref name="x">x</paramref> equals <paramref name="y">y</paramref>.
        /// Greater than zero
        /// <paramref name="x">x</paramref> is greater than <paramref name="y">y</paramref>.
        /// </returns>
        public int Compare(string x, string y)
        {
            if (x == null & y != null)
                return 1;
            if (x != null & y == null)
                return -1;
            if (x == null & y == null)
                return 0;
            
            return String.Compare(x, y, StringComparison.Ordinal);
        }
        
    }
}