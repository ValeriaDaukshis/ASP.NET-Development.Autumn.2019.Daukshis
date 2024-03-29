﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Filter
{
    public class FilterByPalindrome : IFilterCriterion
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
