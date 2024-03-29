﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Filter
{
    public class FilterByKey : IFilterCriterion
    {
        private readonly int _key;
        public FilterByKey(int key )
        {
            _key = key;
        }

        public bool IsMatch(int value)
        {
            value = Math.Abs(value);
            while (value > 0)
            {
                if (value % 10 == _key)
                    return true;
                value /= 10;
            }

            return false;
        }
    }
}
