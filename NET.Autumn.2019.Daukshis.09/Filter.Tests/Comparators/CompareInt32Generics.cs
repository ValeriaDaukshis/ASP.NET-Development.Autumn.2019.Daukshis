using System;
using System.Collections.Generic;
using System.Text;

namespace Filter.Comparator
{
    public class CompareInt32Generics : IComparer<int>
    {
        /// <summary>
        /// Compare
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns>Comparation result</returns>
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }
}