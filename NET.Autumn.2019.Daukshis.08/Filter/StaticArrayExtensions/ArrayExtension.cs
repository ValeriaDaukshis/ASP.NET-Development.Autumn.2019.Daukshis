using System;
using System.Collections;
using System.Collections.Generic;
using Filter.Interfaces;

namespace Filter.StaticArrayExtensions
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Filters the specified numbers.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <param name="criterion">The criterion.</param>
        /// <returns>Filtered array</returns>
        public static int[] Filter(int[] numbers, IPredicate criterion)
        {
            CheckInput(numbers);
            return numbers.FilterArray(criterion);
        }

        /// <summary>
        /// Finds the maximum item.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Max value in array</returns>
        public static int FindMaximumItem (int[] numbers)
        {
            CheckInput(numbers);
            return numbers.FindMax();
        }

        /// <summary>
        /// Transforms the specified array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="transformer">The transformer.</param>
        /// <returns>Array of values in string representation</returns>
        /// <exception cref="ArgumentNullException">Array is null</exception>
        /// <exception cref="ArgumentException">Array has zero length</exception>
        public static string[] Transform(double[] array, ITransformer transformer)
        {
            if (array == null)
                throw new ArgumentNullException("Array is null ");
            if (array.Length == 0)
                throw new ArgumentException("Array has zero length");

            return array.TransformToWords(transformer);
        }

        /// <summary>
        /// Orders the according to.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparator">The comparator.</param>
        public static void OrderAccordingTo(string[] array, IComparer<string> comparator)
        {
            CheckStringInput(array);
            array.SortWithComparator(comparator);
        } 
        
        private static void CheckInput(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException("Array is null ");
            if (array.Length == 0)
                throw new ArgumentException("Array has zero length");
        }
        
        private static void CheckStringInput(string[] array)
        {
            if (array == null)
                throw new ArgumentNullException("Array is null ");
            if (array.Length == 0)
                throw new ArgumentException("Array has zero length");
        }
    }
    
    public static class MethodsExtensions
    {
        /// <summary>
        /// Filters the array.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <param name="criterion">The criterion.</param>
        /// <returns>Filtered array with predicate</returns>
        public static int[] FilterArray(this int[] numbers, IPredicate criterion)
        {
            var filteredList = new List<int>(numbers.Length);
            for (int i = 0; i < numbers.Length; i++)
            {
                if(criterion.IsMatch(numbers[i]))
                    filteredList.Add(numbers[i]);
            }
            return filteredList.ToArray();
        }

        /// <summary>
        /// Finds the maximum.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>Max value in array</returns>
        public static int FindMax(this int[] array)
        {
            if (array.Length == 1)
                return array[0];
            int count = array.Length > 100_000 ? 10_000 : 1;

            int maxValue = array[0];
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
        /// Transforms to words.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="transformer">The transformer.</param>
        /// <returns>Array of double in string representation</returns>
        public static string[] TransformToWords(this double[] array, ITransformer transformer)
        {
            string[] transformedArray = new string[array.Length];
            for (int i = 0; i < transformedArray.Length; i++)
                transformedArray[i] = transformer.TransformToWord(array[i]);
            return transformedArray;
        }

        /// <summary>
        /// Sorts the with comparator.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparator">The comparator.</param>
        public static void SortWithComparator(this string[] array, IComparer<string> comparator)
        {
             Array.Sort(array, comparator);
        }
    }
}