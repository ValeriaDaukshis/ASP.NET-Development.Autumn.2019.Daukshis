using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ICollection<int> array = new List<int>(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
            var iterator = array.Filter(x => x > 4)
                .Count();

//            foreach (var element in iterator)
//            {
//                Console.WriteLine(element);
//            }
            Console.WriteLine(iterator);
            
            // ссылка на объект итератора, где прописаны условия прохождения
            var iterator2 = Enumerable
                .Range(1, 20)
                .Filter(x => x % 2 == 0)
                .Transform(x => x * x)
                .Reverse();

            foreach (var element in iterator2)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine(iterator2.Count());
        }
    }
    public static class Enumerable
    {
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if(source is null)
                throw new ArgumentNullException();
            if(predicate is null)
                throw new ArgumentNullException();
            
            foreach(var item in source)
            {
                if (predicate.Invoke(item))
                {
                    yield return item;
                }
            }
        }

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

        public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source)
        {
            BufferData<TSource> buffer = new BufferData<TSource>(source);
            for (int i = buffer.count - 1; i >= 0; i--)
            {
                yield return buffer.items[i];
            }
        }

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

        public static int Count<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            if(source is null)
                throw new ArgumentNullException();
            
            if (source is ICollection<TSource> collection)
                return collection.Count();
            
            int i = 0;
            foreach (var element in source)
            {
                i++;
            }

            return i;
        }

        public static IEnumerable<TResult> CastTo<TResult>(IEnumerable source)
        {
            throw new NotImplementedException();
        }

        public static bool ForAll<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<TSource> SortBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> key)
        {
//            List<TKey> keys = new List<TKey>();
//            foreach (var element in source)
//            {
//                keys.Add(key.Invoke(element)) ; 
//            }

            //return source.SortBy(key);
            throw new NotImplementedException();
        }

        public static IEnumerable<TSource> SortBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> key, IComparer<TKey> comparer)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}