using System;
using System.Collections.Generic;
using Filter.Interfaces;

namespace Filter.StaticArrayExtensions
{
    public static class ArrayExtension
    {
        public static int[] Filter(int[] numbers, IPredicate criterion)
        {
            CheckInput(numbers);
            return numbers.FilterArray(criterion);
        }
        
        public static int FindMaximumItem (int[] numbers)
        {
            CheckInput(numbers);
            return numbers.FindMax();
        }

        public static string[] Transform(double[] array, ITransformer transformer)
        {
            if (array == null)
                throw new ArgumentNullException("Array is null ");
            if (array.Length == 0)
                throw new ArgumentException("Array has zero length");

            return array.TransformToWords(transformer);
        }
        
        private static void CheckInput(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException("Array is null ");
            if (array.Length == 0)
                throw new ArgumentException("Array has zero length");
        }
    }
    
    public static class MethodsExtensions
    {
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

        public static string[] TransformToWords(this double[] array, ITransformer transformer)
        {
            string[] transformedArray = new string[array.Length];
            for (int i = 0; i < transformedArray.Length; i++)
                transformedArray[i] = transformer.TransformToWord(array[i]);
            return transformedArray;
        }
    }
}