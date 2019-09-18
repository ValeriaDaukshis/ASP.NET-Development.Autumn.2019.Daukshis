using System;
using System.Collections.Generic;

namespace Task1
{
    public class CompareByModulo : IComparer<int>
    {
        public int Compare(int b1, int b2)
        {
            return Math.Abs(b1).CompareTo(Math.Abs(b2));
        }
    }
}
