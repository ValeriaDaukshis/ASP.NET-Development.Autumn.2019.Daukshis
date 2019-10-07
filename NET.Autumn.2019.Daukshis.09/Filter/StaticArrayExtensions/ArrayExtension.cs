using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Filter.Comparators;
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
        public static T[] Filter<T>(T[] numbers, IPredicate criterion) where T : struct
        {
            CheckInput(numbers);
            return numbers.FilterArray(criterion);
        }

        /// <summary>
        /// Finds the maximum item.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns>Max value in array</returns>
        public static T FindMaximumItem<T> (T[] numbers) 
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
        public static string[] Transform<T>(T[] array, ITransformer transformer) where T : struct
        {
            CheckInput(array);
            return array.TransformToWords(transformer);
        }

        /// <summary>
        /// Orders the according to.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="comparator">The comparator.</param>
        public static void OrderAccordingTo<T>(T[] array, IComparer<T> comparator)
        {
            CheckInput(array);
            array.SortWithComparator(comparator);
        }

        public static T[] TypedArray<T>(T[] array, Type type) 
        {
            CheckInput(array);
            return array.GetTypedArray(type);
        }
        
        private static void CheckInput<T>(T[] array)
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
        public static T[] FilterArray<T>(this T[] numbers, IPredicate criterion) where T : struct
        {
            var filteredList = new List<T>(numbers.Length);
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
        public static T FindMax<T>(this T[] array) 
        {
            if (array.Length == 1)
                return array[0];
            int count = array.Length > 100_000 ? 10_000 : 1;

            T maxValue = array[0];
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

            T FindBiggestNumberRecursive(ref T biggestNumber, int nextIndex, int subArrayLength, int currentIndex)
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
        public static string[] TransformToWords<T>(this T[] array, ITransformer<TraceSource,TResult> transformer) where T : struct
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
        public static void SortWithComparator<T>(this T[] array, IComparer<T> comparator)
        {
             Array.Sort(array, comparator);
        }

        public static T[] GetTypedArray<T>(this T[] array, Type type)
        {
            var list = Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
            for (int i = 0 ; i < array.Length; i++)
                if (array[i].GetType() == type)
                    ((IList)list).Add(array[i]);
            T[] a = new T[((IList)list).Count];
            ((IList)list).CopyTo(a, 0);
            return a;

        }
    }
}