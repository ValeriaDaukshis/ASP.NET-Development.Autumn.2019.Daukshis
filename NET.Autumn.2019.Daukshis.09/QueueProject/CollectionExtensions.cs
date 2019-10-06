using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QueueProject
{
    public class Queue<T> : IEnumerable<T>, ICollection, IEquatable<Queue<T>>
    {
        private T[] array = { };
        private int head = 0;
        private int tail = 0;
        private int version = 0;
        private int capacity = 10;
        private int size = 0;
        public int Count { get; }
        public bool IsSynchronized { get; }
        public object SyncRoot { get; }

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
            while (count-- > 0)
            {
                if (item != null && array[count].Equals(item))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Insert element into collection.
        /// </summary>
        /// <param name="item">Item to add.</param>
        public void Enqueue(T item)
        {
            if (size + 1 == capacity)
            {
                SetCapacity();
            }
            
            array[tail] = item;
            ++tail;
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
            Array.Copy(array, head, newArray, 0, array.Length - head);
            array = newArray;
            head = 0;
            tail = size;
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
            T element = array[head];
            array[head] = default(T);
            ++head;
            ++version;
            --size;
            return element;
        }

        /// <summary>
        /// Copy elements of collection into array.
        /// </summary>
        /// <param name="array">Source array.</param>
        /// <param name="index">Index in the array at which storing begins.</param>
        public void CopyTo(Array array, int index)
        {
            Array.Copy(this.array, 0, array, index, array.Length);
        }

        /// <summary>
        /// Check if collections are equal.
        /// </summary>
        /// <param name="other">Collection to compare.</param>
        /// <returns>True if collections are equal, otherwise false.</returns>
        public bool Equals(Queue<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return array.Equals(other);
        }

        /// <summary>
        /// Get the enumerator of collection.
        /// </summary>
        /// <returns>Collection enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            int version2 = version;
            for (int i = head; i < tail; i++)
            {
                if (version2 != version)
                {
                    throw new InvalidOperationException("Enqueue is not valid");
                    //yield break;
                }
                yield return array[i];
            }
        }

        /// <summary>
        /// Check if collection and the object are equal.
        /// </summary>
        /// <param name="obj">Object to compare.</param>
        /// <returns>True if collection and  the object are equal, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Queue<T>) obj);
        }

        /// <summary>
        /// Get hash code of collection.
        /// </summary>
        /// <returns>Hash code of collection.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (array != null ? array.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ head;
                hashCode = (hashCode * 397) ^ tail;
                hashCode = (hashCode * 397) ^ version;
                hashCode = (hashCode * 397) ^ capacity;
                hashCode = (hashCode * 397) ^ size;
                hashCode = (hashCode * 397) ^ Count;
                hashCode = (hashCode * 397) ^ IsSynchronized.GetHashCode();
                hashCode = (hashCode * 397) ^ SyncRoot.GetHashCode();
                return hashCode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class C<T> : IEnumerator
    {
        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public T Current { get; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}