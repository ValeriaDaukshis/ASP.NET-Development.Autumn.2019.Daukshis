using System;
using System.Collections.Generic;

namespace Filter.Tests.Comparators
{
    public class CompareDoubleGenerics : IComparer<double>
    {
        private double Eps = 0.001;
        /// <summary>
        /// Compare
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns>Comparation result</returns>
        public int Compare(double x, double y)
        {
            if (Math.Abs(x - y) < Eps)
                return 0;
            return x.CompareTo(y);
        }
    }
}