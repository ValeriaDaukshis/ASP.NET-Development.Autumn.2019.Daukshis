using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    public class FilterByKey : IPredicate
    {
        private readonly int _key;
        public FilterByKey(int key)
        {
            _key = key;
        }

        /// <summary>
        /// Determines whether the specified number is match.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///   <c>true</c> if the specified number is match; otherwise, <c>false</c>.
        /// </returns>
        public bool IsMatch(int number)
        {
            while (number > 0)
            {
                if (number % 10 == number)
                    return true;
                number /= 10;
            }

            return false;
        }
    }
}
