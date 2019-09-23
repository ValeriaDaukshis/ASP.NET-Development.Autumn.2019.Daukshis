using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    public class FilterEvenElements : IPredicate
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
            return value % 2 == 0;
        }
    }
}
