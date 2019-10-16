using System;
using System.Collections;
using System.Collections.Generic;
using Filter.Interfaces;

namespace Filter.StaticArrayExtensions
{
    public static class MethodsExtensions
    {
        /// <summary>
        /// Filters the array.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <param name="criterion">The criterion.</param>
        /// <returns>Filtered array with predicate</returns>
        public static TSource[] Filter<TSource>(this TSource[] numbers, IPredicate<TSource> criterion)
        {
            CheckInput(numbers);
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
        public static TSource FindMaximumItem<TSource>(this TSource[] array)
        {
            CheckInput(array);
            Comparer<TSource> comparator = Comparer<TSource>.Default;
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
                if(comparator.Compare(array[nextIndex], biggestNumber) == 1)
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
        public static TResult[] Transform<TSource, TResult>(this TSource[] array, ITransformer<TSource,TResult> transformer) 
        {
            CheckInput(array);
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
        public static void OrderAccordingTo<TSource>(this TSource[] array)
        {
            CheckInput(array);
             Array.Sort(array, Comparer<TSource>.Default);
        }
        
        /// <summary>
        /// GetTypedArray
        /// </summary>
        /// <param name="array">init array</param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns>typed array</returns>
        public static TResult[] TypedArray<TSource, TResult>(this TSource[] array)
        {
            CheckInput(array);
            var list = Activator.CreateInstance(typeof(List<>).MakeGenericType(typeof(TResult)));
            for (int i = 0 ; i < array.Length; i++)
                if (array[i].GetType() == typeof(TResult))
                    ((IList)list).Add(array[i]);
            TResult[] a = new TResult[((IList)list).Count];
            ((IList)list).CopyTo(a, 0);
            return a;
        }
        
        private static void CheckInput<TSource>(TSource[] array)
        {
            if (array == null)
                throw new ArgumentNullException("Array is null ");
            if (array.Length == 0)
                throw new IndexOutOfRangeException("Array has zero length");
        }
    }
}