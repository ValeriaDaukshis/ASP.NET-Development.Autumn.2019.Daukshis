using System;
using System.Collections.Generic;
using PseudoEnumerable.Interfaces;

namespace PseudoEnumerable
{
    /// <summary>
    /// EnumerableExtension
    /// </summary>
    public static class EnumerableExtension
    {
        #region Implementation through interfaces

        /// <summary>
        /// Filters the specified predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source,
            IPredicate<TSource> predicate)
        {
            foreach(var numbers in source)
            {
                if(predicate.IsMatching(numbers))
                {
                    yield return numbers;
                }
            }
            // Add implementation method Filter from class ArrayExtension (Homework Day 9. 03.10.2019 Tasks 1-2)
        }

        /// <summary>
        /// Transforms the specified transformer.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="transformer">The transformer.</param>
        /// <returns></returns>
        public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> source,
            ITransformer<TSource, TResult> transformer)
        {
            return source.Transform(transformer.Transform);
            // Call EnumerableExtension.Transform with delegate
        }

        /// <summary>
        /// Orders the according to.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> OrderAccordingTo<TSource>(this IEnumerable<TSource> source,
            IComparer<TSource> comparer)
        {
            List<TSource> list = new List<TSource>(source);
            list.Sort(comparer);
            return list;
        }

        #endregion

        #region Implementation vs delegates

        /// <summary>
        /// Filters the specified predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source,
            Predicate<TSource> predicate)
        {
            return source.Filter(new PredicateAdapter<TSource>(predicate));
            // Call EnumerableExtension.Filter with interface
        }

        /// <summary>
        /// Transforms the specified transformer.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="transformer">The transformer.</param>
        /// <returns></returns>
        public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> source,
            Converter<TSource, TResult> transformer)
        {
            foreach (var numbers in source)
            {
                yield return transformer.Invoke(numbers);
            }
            // Implementation logic vs delegate Converter here 
        }

        /// <summary>
        /// Orders the according to.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> OrderAccordingTo<TSource>(this IEnumerable<TSource> source,
            Comparison<TSource> comparer)
        {
            return source.OrderAccordingTo(Comparer<TSource>.Create(comparer));
            // Call EnumerableExtension.OrderAccordingTo with interface
        }

        #endregion
        
        private class PredicateAdapter<TSource> : IPredicate<TSource>
        {
            private readonly Predicate<TSource> _predicate;
            public PredicateAdapter(Predicate<TSource> predicate)
            {
                this._predicate = predicate;
            }
            public bool IsMatching(TSource item)
            {
                return _predicate.Invoke(item);
            }
        }
    }
}