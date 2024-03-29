﻿using System;
using Filter.Interfaces;

namespace Filter.Filters
{
    public class FilterByPalindrome<TSource> : IPredicate<TSource>
    {
        /// <summary>
        /// Determines whether the specified value is match.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is match; otherwise, <c>false</c>.
        /// </returns>
        public bool IsMatch<TSource>(TSource value) 
        {
            return IsMatch(value.ToString());
        }

         private bool IsMatch(string number)
         {
             if (number[0] == '-')
                 number.Remove(1);
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