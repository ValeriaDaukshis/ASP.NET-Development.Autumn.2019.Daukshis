using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace NumbersList
{
    public class Filter
    {
        /// <summary>
        /// Filter array by key
        /// </summary>
        /// <param name="numbers">list of numbers</param>
        /// <param name="value">value which we need to find</param>
        /// <returns>
        /// List of numbers, which contains value
        /// </returns>
        public static ArrayList FilterArrayByKey(int[] numbers, int value)
        {
            if (numbers.Length == 0)
                throw new Exception("ArrayList is empty");
            if (numbers == null)
                throw new NullReferenceException("List is null");


            Regex regex = new Regex(@"[" + value + "]");
            ArrayList filtered = new ArrayList();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (regex.Matches(numbers[i].ToString()).Count > 0)
                    filtered.Add(numbers[i]);
            }

            return filtered;
        }
    }
}
