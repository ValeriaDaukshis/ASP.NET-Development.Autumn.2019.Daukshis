
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
            if (first >= array.Length)
                throw new ArgumentException("Start index is larger than array length");
            if (last < first)
                throw new ArgumentException("Finish index is less than first index");
            if (last > array.Length)
                throw new ArgumentException("Finish index is larger than array length");
        }

        public int GetNext(int index)
        {
            for (int i = index + 1; i <= Last; i++)
                if (array[i] % _multiplicity == 0)
                    return i;
            return -1;
        }

        public int GetPrev(int index)
        {
            for (int i = index - 1; i >= First; i--)
                if (array[i] % _multiplicity == 0)
                    return i;
            return -1;
        }

        public int GetHeigherElem(int last)
        {
            int maxElement = 0;
            for (int i = First; i < last; i += GetNext(i))
                maxElement = i;
            return maxElement;
        }

        public int GetMedium(int high, int low)
        {
            int medium = (high + low) / 2;
            for (int i = low; i <= high; i = GetNext(i))
            {
                if (i == medium)
                    return medium;
                else if (i > medium)
                    return GetPrev(i);
            }

            return -1;
        }

    }
}
