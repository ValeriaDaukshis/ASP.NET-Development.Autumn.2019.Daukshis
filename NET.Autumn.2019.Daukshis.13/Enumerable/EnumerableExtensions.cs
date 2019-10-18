using System;
using System.Collections;
using System.Collections.Generic;

namespace Enumerable
{
    /// <summary>
    /// EnumerableExtensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Filters the specified predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source is null)
                throw new ArgumentNullException();
            if (predicate is null)
                throw new ArgumentNullException();
            
            foreach(var item in source)
            {
                if (predicate.Invoke(item))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Ranges the specified start.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public static IEnumerable<int> Range(int start, int count)
        {
            if(count <= 0)
                throw new ArgumentException();
            
            if(start + count > Int32.MaxValue)
                throw new ArgumentException();
            
            for (int i = start; i < count + start; i++)
            {
                yield return i;
            }
        }

        /// <summary>
        /// Reverses the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException();

            BufferData<TSource> buffer = new BufferData<TSource>(source);
            buffer.ToArray();
            for (int i = buffer.count - 1; i >= 0; i--)
            {
                yield return buffer.items[i];
            }
        }

        /// <summary>
        /// Transforms the specified transformer.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="transformer">The transformer.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> transformer)
        {
            if (source is null)
                throw new ArgumentNullException();
            if (transformer is null)
                throw new ArgumentNullException();

            foreach (var numbers in source)
            {
                yield return transformer.Invoke(numbers);
            }
        }

        /// <summary>
        /// Counts the specified predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public static int Count<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source is null)
                throw new ArgumentNullException();
            if (predicate is null)
                throw new ArgumentNullException();

            int count = 0;
            foreach (var numbers in source)
            {
                if (predicate.Invoke(numbers))
                    count++;
            }

            return count;
        }

        /// <summary>
        /// Counts the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            if(source is null)
                throw new ArgumentNullException();
            
//            if (source is ICollection<TSource> collection)
//                return collection.Count();
            
            int count = 0;
            foreach (var element in source)
            {
                count++;
            }

            return count;
        }

        /// <summary>
        /// Casts to.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidCastException"></exception>
        public static IEnumerable<TResult> CastTo<TResult>(this IEnumerable source)
        {
            if (source is null)
            {
                throw new ArgumentNullException();
            }
            
            foreach (var value in source)
            {
                if (value is TResult res)
                    yield return (TResult)value;
                else
                    throw new InvalidCastException();
            }
        }

        /// <summary>
        /// Fors all.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public static bool ForAll<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source is null)
                throw new ArgumentNullException();
            if (predicate is null)
                throw new ArgumentNullException();
            
            foreach (var value in source)
            {
                if (!predicate.Invoke(value))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Sorts the by descending.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> SortByDescending<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> key)
        {
            if (source is null)
                throw new ArgumentNullException();
            if (key is null)
                throw new ArgumentNullException();
            
            int i = 0;
            TKey[] keys = new TKey[source.Count()];
            TSource[] items = new TSource[source.Count()];
            foreach (var element in source)
            {
                keys[i] = key.Invoke(element);
                items[i] = element;
                i++;
            }
            Array.Sort(keys, items);

            BufferData<TSource> buffer = new BufferData<TSource>(items);
            buffer.ToArray();
            for (int j = buffer.count - 1; j >= 0; j--)
            {
                yield return buffer.items[j];
            }
        }

        /// <summary>
        /// Sorts the by.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> SortBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> key)
        {
            if (source is null)
                throw new ArgumentNullException();
            if (key is null)
                throw new ArgumentNullException(); 
            
            int i = 0;
            int c = source.Count();
            TKey[] keys = new TKey[c];
            TSource[] items = new TSource[source.Count()];
            foreach (var element in source)
            {
                keys[i] = key.Invoke(element);
                items[i] = element;
                i++;
            }
            Array.Sort(keys, items);

            foreach (var element in items)
            {
                yield return element;
            }
        }

        /// <summary>
        /// Sorts the by.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="key">The key.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> SortBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> key, IComparer<TKey> comparer)
        {
            if (source is null)
                throw new ArgumentNullException();
            if (key is null)
                throw new ArgumentNullException(); 
            if(comparer is null)
                throw new ArgumentNullException();
            
            int i = 0;
            TKey[] keys = new TKey[source.Count()];
            TSource[] items = new TSource[source.Count()];
            foreach (var element in source)
            {
                keys[i] = key.Invoke(element);
                items[i] = element;
                i++;
            }
            Array.Sort(keys, items, comparer);

            foreach (var element in items)
            {
                yield return element;
            }
        }

        /// <summary>
        /// Sorts the by descending.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="key">The key.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> SortByDescending<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> key, IComparer<TKey> comparer)
        {
            if (source is null)
                throw new ArgumentNullException();
            if (key is null)
                throw new ArgumentNullException(); 
            if(comparer is null)
                throw new ArgumentNullException();
            
            int i = 0;
            TKey[] keys = new TKey[source.Count()];
            TSource[] items = new TSource[source.Count()];
            foreach (var element in source)
            {
                keys[i] = key.Invoke(element);
                items[i] = element;
                i++;
            }
            Array.Sort(keys, items, comparer);

            BufferData<TSource> buffer = new BufferData<TSource>(items);
            buffer.ToArray();
            for (int j = buffer.count - 1; j >= 0; j--)
            {
                yield return buffer.items[j];
            }
        }
    }
    
    internal struct BufferData<T>
    {
        internal T[] items;
        internal int count;

        internal BufferData(IEnumerable<T> source)
        {
            this.count = source.Count();
            items = new T[this.count];
            int i = 0;
            foreach (var element in source)
            {
                items[i] = element;
                i++;
            }
        }

        internal T[] ToArray()
        {
            return items;
        }
    }
}