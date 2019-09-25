using System.Collections.Generic;

namespace Number.Tests
{
    public class ReverseSorting : IComparer<int>
    {
        public int Compare(int number1, int number2)
        {
            return number2.CompareTo(number1);
        }
    }
}