using System;

namespace Task1
{
    public class AbsNumberCompare : ICompare
    {
        public int CompareNumbers(int b1, int b2)
        {
            return Math.Abs(b1).CompareTo(Math.Abs(b2));
        }
    }
}
