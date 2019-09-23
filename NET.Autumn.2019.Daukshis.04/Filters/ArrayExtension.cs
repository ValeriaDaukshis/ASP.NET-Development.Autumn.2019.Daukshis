using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    public class ArrayExtension
    {
        /// <summary>
        /// Filters the array.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>filtered array</returns>
        public static int[] FilterArray(int[] numbers, IPredicate filter)
        {
            CheckInput(numbers);
            var filteredArray = new List<int>(capacity: numbers.Length);
            for (int i = 0; i < numbers.Length; i++)
                if (filter.IsMatch(numbers[i]))
                    filteredArray.Add(numbers[i]);

            return filteredArray.ToArray();
        }

        /// <summary>
        /// Check input
        /// </summary>
        /// <param name="array">init array</param>
        private static void CheckInput(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                throw new ArgumentException("Array has zero length");
        }
    }
}
