using System;
using Filter.Interfaces;

namespace Filter.Filters
{
    public class FilterByPalindrome : IPredicate
    {
        public bool IsMatch(int value)
        {
            string number = Math.Abs(value).ToString();
            return IsPalindrome(number, 0, number.Length / 2); 
        }
        
        public bool IsPalindrome(string value, int i, int count)
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