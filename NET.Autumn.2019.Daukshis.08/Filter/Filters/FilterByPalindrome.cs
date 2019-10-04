using System;
using Filter.Interfaces;

namespace Filter.Filters
{
    public class FilterByPalindrome : IPredicate
    {
        /// <summary>
        /// Determines whether the specified value is match.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is match; otherwise, <c>false</c>.
        /// </returns>
        public bool IsMatch(int value)
        {
            string number = Math.Abs(value).ToString();
            return IsPalindrome(number, 0, number.Length / 2); 
        }
        
        private bool IsPalindrome(string value, int i, int count)
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