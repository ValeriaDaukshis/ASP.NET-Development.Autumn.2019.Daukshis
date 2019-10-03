using System;
using System.Collections.Generic; 
using System.Text.RegularExpressions; 

namespace Filter
{
    public static class ArrayExtension
    { 
        public static int[] FilterArray(int[] numbers, IFilterCriterion criterion)
        {
            CheckInput(numbers);
            var filteredList = new List<int>(numbers.Length);
            for (int i = 0; i < numbers.Length; i++)
            {
                if(criterion.IsMatch(numbers[i]))
                    filteredList.Add(numbers[i]);
            }
            return filteredList.ToArray();
        }

        /// <summary>
        /// Check input
        /// </summary>
        /// <param name="array">init array</param>
        private static void CheckInput(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException("Array is null ");
            if (array.Length == 0)
                throw new ArgumentException("Array has zero length");
        }
    }
}
