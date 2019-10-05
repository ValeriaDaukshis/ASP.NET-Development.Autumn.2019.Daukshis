using System;
using Filter.Interfaces;

namespace Filter.Filters
{
    public class FilterByKey : IPredicate
    {
        private readonly char _key;
        public FilterByKey(char key)
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
        public bool IsMatch<T>(T value)  where T : struct
        {
            return IsMatch(value.ToString());
        }

        private bool IsMatch(string value)
        {
            if (value[0] == '-')
                value.Remove(1);
            
            for (int i = 0 ; i < value.Length; i++)
                if (value[i] == _key)
                    return true;

            return false;
        }
    }
}