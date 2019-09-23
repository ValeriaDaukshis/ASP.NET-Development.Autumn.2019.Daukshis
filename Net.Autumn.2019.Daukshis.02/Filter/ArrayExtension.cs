using System;
using System.Collections.Generic; 
using System.Text.RegularExpressions; 

namespace Filter
{
    public static class ArrayExtension
    { 
        public static int[] FilterArrayByKey(int[] numbers, int value = 0, Boolean palindrome = false, Boolean key = true )
        {
            CheckInput(numbers, value);

            var regex = new Regex(@"[" + value + "]");
            var filtered = new List<int>();
            int countOfDigits = 0;
            Boolean isPalindrome = false;
            if (!key)
                countOfDigits = 1;
            if (!palindrome)
                isPalindrome = true;
            for (int i = 0; i < numbers.Length; i++)
            { 
                if (key)
                    countOfDigits = regex.Matches(numbers[i].ToString()).Count;
                if (palindrome)
                    isPalindrome = numbers.IsPalindrome(numbers[i], 0, numbers.Length / 2);
                if (countOfDigits > 0 & isPalindrome)
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

    public static class Extension
    {
        public static Boolean IsPalindrome(this int[] numbers, int array, int i, int count)
        {
            if (count == 0)
                return true;
            if (array.ToString()[i] == array.ToString()[array.ToString().Length - 1 - i] & count > 0)
            {
                count--;
                return numbers.IsPalindrome( array, i + 1, count);
            }
            return false;
        }

    }
}
