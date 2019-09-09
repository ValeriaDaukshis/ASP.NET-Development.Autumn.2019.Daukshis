using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveSearchTasks
{
    public static class SearchClass
    {
        public static int FindBiggestNumber(int[] array)
        {
            CheckInput(array);
            return FindBiggestNumberRecursive(array, array[0], array[0]); 
        }

        private static int FindBiggestNumberRecursive(int[] array, int biggestNumber, int nextIndex)
        {
            if (array[nextIndex] > biggestNumber)
                biggestNumber = array[nextIndex];

            if (array[nextIndex] == array[array.Length - 1])
                return biggestNumber;
            
            return FindBiggestNumberRecursive(array, biggestNumber, array[nextIndex + 1]);
            
        }

        /// <summary>
        /// Check input data
        /// </summary>
        /// <param name="array">initial array</param>
        private static void CheckInput(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array has zero length");
            }
        }
    }
}
