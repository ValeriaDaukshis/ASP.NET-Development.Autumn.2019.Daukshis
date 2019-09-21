using System;
using System.Collections.Generic; 
using System.Text.RegularExpressions; 

namespace Filter
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Filter array by key
        /// </summary>
        /// <param name="numbers">list of numbers</param>
        /// <param name="value">value which we need to find</param>
        /// <returns>
        /// List of numbers, which contains value
        /// </returns>
        public static int[] FilterArrayByKey(int[] numbers, int value)
        {
            CheckInput(numbers, value);

            var regex = new Regex(@"[" + value + "]");
            var filtered = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (regex.Matches(numbers[i].ToString()).Count > 0)
                    filtered.Add(numbers[i]);
            }
            return filtered.ToArray();
        }

        /// <summary>
        /// Check input
        /// </summary>
        /// <param name="array">init array</param>
        private static void CheckInput(int[] array, int value)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                throw new ArgumentException("Array has zero length");
            if (value < 0)
                throw new ArgumentOutOfRangeException("value is less than zero");
        }
    }
}
