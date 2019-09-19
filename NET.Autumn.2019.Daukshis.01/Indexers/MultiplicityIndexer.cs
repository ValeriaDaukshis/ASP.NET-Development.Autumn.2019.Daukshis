
using System;

namespace Task1
{
    public class MultiplicityIndexer : IIndexer
    {
        public int First { get; private set; }
        public int Last { get; private set; }
        private readonly int _multiplicity;
        private readonly int[] array;

        public MultiplicityIndexer(int[] array, int last, int first = 0, int multiplicity = 1)
        {
            CheckInput(array, first, last, multiplicity);
            Last = last;
            First = first;
            _multiplicity = multiplicity;
            this.array = array;
        }
        /// <summary>
        /// Checks the input.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="first">The first.</param>
        /// <param name="last">The last.</param>
        /// <param name="multiplicity">The multiplicity.</param>
        /// <exception cref="Exception">Array is empty</exception>
        /// <exception cref="NullReferenceException">Array is null</exception>
        /// <exception cref="ArgumentException">
        /// Step is less than zero
        /// or
        /// Start index is less than zero
        /// or
        /// Start index is larger than array length
        /// or
        /// Finish index is less than first index
        /// or
        /// Finish index is larger than array length
        /// </exception>
        private void CheckInput(int[] array, int first, int last, int multiplicity)
        {
            if (array.Length == 0)
                throw new Exception("Array is empty");
            if (array == null)
                throw new NullReferenceException("Array is null");
            if (multiplicity <= 0)
                throw new ArgumentException("Step is less than zero");
            if (first < 0)
                throw new ArgumentException("Start index is less than zero");
            if (first > array.Length)
                throw new ArgumentException("Start index is larger than array length");
            if (last < first)
                throw new ArgumentException("Finish index is less than first index");
            if (last > array.Length)
                throw new ArgumentException("Finish index is larger than array length");
        }

        /// <summary>
        /// Gets the next.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Next index</returns>
        public int GetNext(int index)
        {
            for (int i = index + 1; i <= Last; i++)
                if (array[i] % _multiplicity == 0)
                    return i;
            return -1;
        }

        /// <summary>
        /// Gets the previous.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Prev index</returns>
        public int GetPrev(int index)
        {
            for (int i = index - 1; i >= First; i = GetPrev(i))
                if (array[i] % _multiplicity == 0)
                    return i;
            return -1;
        }

        /// <summary>
        /// GetHeigherElem
        /// </summary>
        /// <param name="last">The last.</param>
        /// <returns>Gets the heigher element</returns>
        public int GetHeigherElem(int last)
        {
            int maxElement = 0;
            for (int i = First; i <= last; i = GetNext(i))
                if (i == -1)
                    break;
                else
                    maxElement = i;
            return maxElement;
        }

        /// <summary>
        /// GetMedium
        /// </summary>
        /// <param name="high">The high.</param>
        /// <param name="low">The low.</param>
        /// <returns>Gets the medium index</returns>
        public int GetMedium(int high, int low)
        {
            int medium = (high + low) / 2;
            for (int i = low; i <= high; i = GetNext(i))
            {
                if (i < low)
                    return low;
                if (i == medium)
                    return medium;
                if (i > medium)
                    return GetPrev(i);
            }

            return -1;
        }

    }
}
