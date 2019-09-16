using System;

namespace Task1
{
    public class SimpleNumberCompare : ICompare
    {
        public int CompareNumbers(int b1, int b2)
        {
            return b1.CompareTo(b2);
        }
    }
}
