
using System.Collections.Generic;

namespace Task1
{
    public class CompareByValue : IComparer<int>
    {
        public int Compare(int b1, int b2)
        {
            return b1.CompareTo(b2);
        }
    }
}
