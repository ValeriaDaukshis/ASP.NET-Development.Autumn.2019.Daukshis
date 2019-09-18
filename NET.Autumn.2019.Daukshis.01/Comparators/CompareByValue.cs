
using System.Collections.Generic;

namespace Task1
{
    public class CompareByValue : IComparer<int>
    {
        /// <summary>
        /// Compares the specified b1.
        /// </summary>
        /// <param name="b1">The b1.</param>
        /// <param name="b2">The b2.</param>
        /// <returns>comparison result</returns>
        public int Compare(int b1, int b2)
        {
            return b1.CompareTo(b2);
        }
    }
}
