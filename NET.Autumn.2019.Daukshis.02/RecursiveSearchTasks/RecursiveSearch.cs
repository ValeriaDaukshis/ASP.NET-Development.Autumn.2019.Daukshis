﻿using System;

namespace RecursiveSearchTasks
{
    public static class RecursiveSearch
    {
        /// <summary>
        /// find biggest number
        /// </summary>
        /// <param name="array">init array</param>
        /// <returns>
        /// biggest number in array
        /// </returns>
        public static int FindBiggestNumber(int[] array)
        {
            CheckInput(array);
            return FindBiggestNumberRecursive(array, array[0], 0); 
        }

        /// <summary>
        /// Find Biggest Number Recursive
        /// </summary>
        /// <param name="array">init array</param>
        /// <param name="biggestNumber">current biggest number</param>
        /// <param name="nextIndex">next element index</param>
        /// <returns>
        /// biggest number
        /// </returns>
        private static int FindBiggestNumberRecursive(int[] array, int biggestNumber, int nextIndex)
        {
            if (array[nextIndex] > biggestNumber)
                biggestNumber = array[nextIndex];

            if (array[nextIndex] == array[array.Length - 1])
                return biggestNumber;
            
            return FindBiggestNumberRecursive(array, biggestNumber, nextIndex + 1);
            
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