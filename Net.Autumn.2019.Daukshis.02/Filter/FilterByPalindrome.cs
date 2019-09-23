using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Filter
{
    class FilterByPalindrome : IFilter
    {
        public static Boolean IsMatch(int value)
        {
            //IsPalindrome(value, 0, numbers.Length / 2);
            //return countOfDigits > 0 ? true : false;
            return true;
        }

        public static Boolean IsPalindrome(int array, int i, int count)
        {
            if (count == 0)
                return true;
            if (array.ToString()[i] == array.ToString()[array.ToString().Length - 1 - i] & count > 0)
            {
                count--;
                return IsPalindrome(array, i + 1, count);
            }
            return false;
        }
    }
}
