﻿using System;

namespace FindBalanceIndexTask
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Finds the index of the balance.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>
        /// Middle element, where the sum of elements in the left side equals to sum of the elements in the right side
        /// </returns>
        public static int? FindBalanceIndex(int[] array)
        {
            CheckInput(array);
            long leftSum = array[0];
            long rightSum = ElementsSum(array, 2, array.Length - 1);
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (leftSum == rightSum)
                    return i;
                leftSum = leftSum + array[i];
                rightSum = rightSum - array[i+1]; 
                if (leftSum  > rightSum )
                    return null;
            }
            return null;
        }

        /// <summary>
        /// Sum of elements
        /// </summary>
        /// <param name="array">init array</param>
        /// <param name="low">start position</param>
        /// <param name="high">final position</param>
        /// <returns>
        /// Sum of elements from low to high positions
        /// </returns>
        private static long ElementsSum(int[] array, int low, int high)
        {
            if (low < 0 || high > array.Length - 1)
                throw new ArgumentOutOfRangeException();
            if (low > high)
                throw new ArgumentException("Low index is more than high index");

            long sum = 0;
            for (int i = low; i <= high; i++)
                sum += array[i]; 

            return sum;
        }

        /// <summary>
        /// Check input
        /// </summary>
        /// <param name="array">init array</param>
        private static void CheckInput(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException(); 
            if (array.Length == 0) 
                throw new ArgumentException("Array has zero length"); 
        }
    }
}
