using System;
using System.Collections.Generic;

namespace Filter.Comparators
{
    public class CompareByKey : IComparer<string>
    {
        private readonly char _key;
        public CompareByKey(char key)
        {
            _key = key;
        }

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
            return CountOfKeys(x).CompareTo(CountOfKeys(y));
        }

        private int CountOfKeys(string value)
        {
            if (value == null)
                return 0;
            
            int count = 0;
            for (int i = 0 ; i < value.Length; i++)
                if (value[i] == _key)
                    ++count;
            return count;
        }
    }
}