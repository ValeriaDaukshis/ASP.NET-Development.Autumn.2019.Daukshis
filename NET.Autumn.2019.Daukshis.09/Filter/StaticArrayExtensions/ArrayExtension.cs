using System;
using System.Collections.Generic;
using Filter.Comparator;
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
        public static TSource[] Filter<TSource>(TSource[] numbers, IPredicate<TSource> criterion) 
        {
            CheckInput(numbers);
            return numbers.FilterArray(criterion);
        }

        /// <summary>
        /// Finds the maximum item.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Max value in array</returns>
        public static TSource FindMaximumItem<TSource> (TSource[] numbers) 
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
        public static TResult[] Transform<TSource,TResult>(TSource[] array, ITransformer<TSource,TResult> transformer) 
        {
            CheckInput(array);
            return array.TransformToWords(transformer);
        }

        /// <summary>
        /// Orders the according to.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparator">The comparator.</param>
        public static void OrderAccordingTo<TSource>(TSource[] array, IComparer<TSource> comparator)
        {
            CheckInput(array);
            array.SortWithComparator(comparator);
        }
        
        
        private static void CheckInput<TSource>(TSource[] array)
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
        public static TSource[] FilterArray<TSource>(this TSource[] numbers, IPredicate<TSource> criterion) 
        {
            var filteredList = new List<TSource>(numbers.Length);
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
        public static TSource FindMax<TSource>(this TSource[] array) 
        {
            if (array.Length == 1)
                return array[0];
            int count = array.Length > 100_000 ? 10_000 : 1;

            TSource maxValue = array[0];
            int nextElement = 0;
            for (int i = 0; i < count; i++)
            {
                int subArrayLength = array.Length / count;
                if (i == count - 1 )
                    subArrayLength = array.Length - nextElement - 1 ;
                
                FindBiggestNumberRecursive(ref maxValue, nextElement+1, subArrayLength, 1);
                nextElement = array.Length / count * (i + 1) + 1;
            } 
            return maxValue;

            TSource FindBiggestNumberRecursive(ref TSource biggestNumber, int nextIndex, int subArrayLength, int currentIndex)
            {
                if(new CompareGenerics().Compare(array[nextIndex], biggestNumber) == 1)
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
        public static TResult[] TransformToWords<TSource, TResult>(this TSource[] array, ITransformer<TSource,TResult> transformer) 
        {
            TResult[] transformedArray = new TResult[array.Length];
            for (int i = 0; i < transformedArray.Length; i++)
                transformedArray[i] = transformer.TransformToWord(array[i]);
            return transformedArray;
        }

        /// <summary>
        /// Sorts the with comparator.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparator">The comparator.</param>
        public static void SortWithComparator<TSource>(this TSource[] array, IComparer<TSource> comparator)
        {
             Array.Sort(array, comparator);
        }
        
    }
}