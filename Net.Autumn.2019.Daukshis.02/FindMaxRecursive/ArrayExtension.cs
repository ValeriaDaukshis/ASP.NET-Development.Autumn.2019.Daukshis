using System;

namespace FindMaxRecursive
{
    public static class ArrayExtension
    {
        /// <summary>
        /// find biggest number
        /// </summary>
        /// <param name="array">init array</param>
        /// <returns>
        /// biggest number in array
        /// </returns>
        public static int FindMaximumItem(int[] array)
        {
            CheckInput(array);
            if (array.Length == 1)
                return array[0]; 
            return FindBiggestNumberRecursive(array[0], 1);

            int FindBiggestNumberRecursive(int biggestNumber, int nextIndex)
            {
                if (array[nextIndex] > biggestNumber)
                    biggestNumber = array[nextIndex];

                if (array[nextIndex] == array[array.Length - 1])
                    return biggestNumber;

                return FindBiggestNumberRecursive(biggestNumber, nextIndex + 1);
            }
        }

        /// <summary>
        /// Check input data
        /// </summary>
        /// <param name="array">initial array</param>
        private static void CheckInput(int[] array)
        {
            if (array == null) 
                throw new ArgumentNullException(); 

            if (array.Length == 0) 
                throw new ArgumentException("Array has zero length"); 
        }
    }
}
