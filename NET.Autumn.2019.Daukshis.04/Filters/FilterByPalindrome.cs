using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    public class FilterByPalindrome : IPredicate
    {
        /// <summary>
        /// Determines whether the specified number is match.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///   <c>true</c> if the specified number is match; otherwise, <c>false</c>.
        /// </returns>
        public bool IsMatch(int number)
        {
            string value = number.ToString();
            return IsPalindrome(value, 0, value.Length / 2);
        }
        /// <summary>
        /// Determines whether the specified value is palindrome.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="i">The i.</param>
        /// <param name="count">The count.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is palindrome; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPalindrome(string value, int i, int count)
        {
            if (count == 0)
                return true;
            if (value[i] == value[value.Length - 1 - i] & count > 0)
            {
                count--;
                return IsPalindrome(value, i + 1, count);
            }
            return false;
        }
    }
}
