
using System;
using System.Diagnostics.Eventing.Reader;

namespace Task1
{
    public class StepIndexer : IIndexer
    {
        
        public int First { get; private set; }
        public int Last { get;  set; } 
        private readonly int _step;

        public StepIndexer(int[] array, int last, int first = 0, int step = 1)
        {
            CheckInput(array, first, last, step);
            Last = last;
            First = first;
            _step = step; 
        }

        private void CheckInput(int[] array, int first, int last, int step)
        {
            if (array.Length == 0)
                throw new Exception("Array is empty");
            if (array == null)
                throw new NullReferenceException("Array is null");
            if (step <= 0)
                throw new ArgumentException("Step is less than zero");
            if (step >= array.Length)
                throw new ArgumentException("Step is larger than array length");
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
            if(index + _step <= Last)
               return index + _step;
            return -1;
        }

        public int GetPrev(int index)
        {
            if (index - _step >= First)
                return index - _step;
            return -1;
        }

        public int GetHeigherElem(int high)
        {
            int maxElement = 0;
            for (int i = First; i <= high; i += _step)
                maxElement = i;
            return maxElement;
        }

        public int GetMedium(int high, int low)
        {
            int medium = (high + low)/2;
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
