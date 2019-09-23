using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Filter
{
    class FilterByKey : IFilter
    {
        private int key;
        public FilterByKey(int key )
        {
            this.key = key;
        }

        public static Boolean IsMatch(int value)
        {
            var regex = new Regex(@"[" + value + "]");
            var filtered = new List<int>();
            int countOfDigits = regex.Matches(value.ToString()).Count;
            return countOfDigits > 0 ? true : false;
        }
    }
}
