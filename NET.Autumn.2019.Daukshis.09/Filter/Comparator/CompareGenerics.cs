using System;
using System.Text;

namespace Filter.Comparator
{
    public class CompareGenerics 
    {
        /// <summary>
        /// Compare
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns>Comparation result</returns>
        public int Compare<TSource>(TSource x, TSource y)
        {
            return CompareValues(x.ToString(), y.ToString());
        }

        private int CompareValues(string x, string y)
        {
            int xLen = x.Length;
            int yLen = y.Length;
            
            StringBuilder builder = new StringBuilder(Math.Abs(xLen- yLen));
            for (int i = 0; i < builder.Capacity; i++)
                builder.Append("0");

            int len = yLen;
            if (xLen > yLen)
            {
                len = xLen;
                y = String.Concat(builder, y);
            }
            else if (xLen < yLen)
            {
                x = String.Concat(builder, x);
            }
            
            for (int i = 0 ; i < len; i++)
            {
                if (x[i] > y[i])
                    return 1;
                if (x[i] < y[i])
                    return -1;
            }
            return 0;
        }
    }
}