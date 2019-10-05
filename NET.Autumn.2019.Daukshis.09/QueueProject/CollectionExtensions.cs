using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QueueProject
{
    public class Queue<T> : IEnumerable<T>, ICollection, IEquatable<T>
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

        public void Clear()
        {
            tail = 0;
            head = 0;
            size = 0;
            ++version;
        }

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

        public void CopyTo(T[] array, int arrayIndex)
        {
        }

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

        public T Peek()
        {
            return array[head];
        }

        public T DeQueue()
        {
            T element = array[head];
            array[head] = default(T);
            ++head;
            ++version;
            --size;
            return element;
        }
        
        public void CopyTo(Array array, int index)
        {
            Array.Copy(this.array, 0, array, index, array.Length);
        }
        
        public bool Equals(T other) 
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return array.Equals(other);
        }

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

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Queue<T>) obj);
        }

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
}