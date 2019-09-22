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
            int count = 1;
            
            if (array.Length > 100_000) 
                count = 10_000; 

            int maxValue = -1;
            int nextElement = 0;
            for (int i = 0; i < count; i++)
            {
                int subArrayLength = array.Length / count;
                if (i == count - 1)
                    subArrayLength = array.Length - nextElement - 1 ;
                FindBiggestNumberRecursive(ref maxValue, nextElement+1, subArrayLength, 1);
                nextElement = array.Length / count * (i + 1) + 1;
            } 
            return maxValue;

            int FindBiggestNumberRecursive(ref int biggestNumber, int nextIndex, int subArrayLength, int currentIndex)
            {
                if (array[nextIndex] > biggestNumber)
                    biggestNumber = array[nextIndex];
                if (currentIndex == subArrayLength)
                    return biggestNumber;

                return FindBiggestNumberRecursive(ref biggestNumber, nextIndex + 1, subArrayLength, ++currentIndex);
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
