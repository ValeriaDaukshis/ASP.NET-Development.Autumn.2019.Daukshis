using System;
using Filter.Interfaces;

namespace Filter.Filters
{
    public class FilterByKey : IPredicate
    {
        private readonly int _key;
        public FilterByKey(int key )
        {
            _key = key;
        }

        /// <summary>
        /// Determines whether the specified value is match.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is match; otherwise, <c>false</c>.
        /// </returns>
        public bool IsMatch(int value)
        {
            value = Math.Abs(value);
            while (value > 0)
            {
                if (value % 10 == _key)
                    return true;
                value /= 10;
            }

            return false;
        }
    }
}