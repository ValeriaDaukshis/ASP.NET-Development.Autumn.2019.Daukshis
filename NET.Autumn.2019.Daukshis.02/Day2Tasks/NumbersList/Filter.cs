using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace NumbersList
{
    public class Filter
    {
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
