using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QueueProject
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] array;
        private int head = 0;
        private int tail = 0;
        private int version = 0;
        private int capacity = 4;
        private int size = 0;
        public int Count => size;

        public Queue()
        {
            array = new T[capacity];
        }

        public Queue(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException("Value capasity is lower than zero");
            this.capacity = capacity;
            array = new T[capacity];
        }

        public Queue(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException("Collection is null");
            capacity = collection.Count() + 3;
            array = new T[capacity];
            foreach (var element in collection)
                Enqueue(element);
        }

        /// <summary>
        /// Clear current queue.
        /// </summary>
        public void Clear()
        {
            if (head < tail)
                Array.Clear(array, head, tail);
            else
            {
                Array.Clear(array, head, array.Length - head);
                Array.Clear(array, 0, tail);
            }
            tail = 0;
            head = 0;
            size = 0;
            ++version;
        }

        /// <summary>
        /// Check if collection contains element/
        /// </summary>
        /// <param name="item">Item to find.</param>
        /// <returns>True if contains, otherwise false.</returns>
        public bool Contains(T item)
        {
            int count = size;
            int headPointer = head;
            while (count-- > 0)
            {
                if (headPointer != null && array[count].Equals(array[headPointer]))
                    return true;
               
                headPointer = (headPointer + 1) % array.Length;
            }

            return false;
        }

        /// <summary>
        /// Insert element into collection.
        /// </summary>
        /// <param name="item">Item to add.</param>
        public void Enqueue(T item)
        {
            if (size == capacity)
            {
                SetCapacity();
            }
            
            array[tail] = item;
            tail = (tail + 1) % this.array.Length;
            ++size;
            ++version;
        }

        /// <summary>
        /// Extends capacity of collection
        /// </summary>
        private void SetCapacity()
        {
            capacity += 10;
            T[] newArray = new T[capacity];
            if(head < tail)
                Array.Copy(array, head, newArray, 0, size);
            else
            {
                Array.Copy(array, head, newArray, 0, array.Length - head);
                Array.Copy(array, 0, newArray, array.Length - head, tail);
            }
            array = newArray;
            head = 0;
            tail = size != capacity ? size : 0;
            version++;
        }

        /// <summary>
        /// Get first item of collection.
        /// </summary>
        /// <returns>Head item.</returns>
        public T Peek()
        {
            return array[head];
        }

        /// <summary>
        /// Pop the first element from collection.
        /// </summary>
        /// <returns>Head element.</returns>
        public T DeQueue()
        {
            if (size == 0)
                throw new InvalidOperationException("The queue size is zero");
            T element = array[head];
            array[head] = default(T);
            head = (head + 1) % array.Length;
            ++version;
            --size;
            return element;
        }

        /// <summary>
        /// Copy elements of collection into array.
        /// </summary>
        /// <param name="array">Source array.</param>
        /// <param name="index">Index in the array at which storing begins.</param>
        public void CopyTo(T[] array, int index)
        {
            if(array == null)
                throw new ArgumentNullException("Array is null");
            if(index < 0 || index > array.Length)
                throw new ArgumentOutOfRangeException("Invalid index");
            if(array.Length - index < size)
                throw new ArgumentException("Size of source array is bigger than destination");
            int numOfElements = (this.array.Length - head < size) ? this.array.Length - index : size;
            Array.Copy(this.array, head, array, index, numOfElements);
            if(size - numOfElements > 0)
                Array.Copy(this.array, 0, array, index + this.array.Length - head, size - numOfElements);
        }
        
        /// <summary>
        /// Get the enumerator of collection.
        /// </summary>
        /// <returns>Collection enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
           return new CustomIterator(this);
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        private struct CustomIterator : IEnumerator<T>
        {
            private Queue<T> collection;
            private int currentIndex;
            private int version2;

            public CustomIterator(Queue<T> list)
            {
                collection = list;
                currentIndex = -1;
                version2 = list.version;
            }

            public bool MoveNext()
            {
                return ++currentIndex < collection.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == collection.Count || version2 != collection.version)
                    {
                        throw new InvalidOperationException();
                    }
                    return collection.array[(collection.head + currentIndex) % collection.array.Length];
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            { }
        }
    }
}