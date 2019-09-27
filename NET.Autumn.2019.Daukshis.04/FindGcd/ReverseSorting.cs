using System.Collections.Generic;

namespace FindGcd
{
    public class ReverseSorting : IComparer<int>
    {
        /// <summary>
        /// Compares the specified number1.
        /// </summary>
        /// <param name="number1">The number1.</param>
        /// <param name="number2">The number2.</param>
        /// <returns>
        ///  comparison result
        /// </returns>
        public int Compare(int number1, int number2)
        {
            return number2.CompareTo(number1);
        }
    }
}