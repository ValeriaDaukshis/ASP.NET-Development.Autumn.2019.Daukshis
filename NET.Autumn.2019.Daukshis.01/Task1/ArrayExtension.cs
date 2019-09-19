using System;
using System.Collections.Generic;

namespace Task1
{
     public static class ArrayExtension 
     {
        /// <summary>
        /// Bubbles the sort.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="compareCriterion">The compare criterion.</param>
        /// <param name="indexer">The indexer.</param>
        public static void BubbleSort(int[] array, IComparer<int> compareCriterion, IIndexer indexer)
        {
            CheckInput(array, compareCriterion, indexer);
            Bubble(array, compareCriterion, indexer); 
        }

        /// <summary>
        /// Quick sort
        /// </summary>
        /// <param name="array">initial array</param>
        public static void QSort(int[] array, IComparer<int> compareCriterion, IIndexer indexer)
        {
            CheckInput(array, compareCriterion, indexer);
            int start = indexer.First;
            int finish = indexer.Last;
            QuickSort(array, start, finish, compareCriterion, indexer);
        }

        /// <summary>
        /// Merge Sort
        /// </summary>
        /// <param name="array">initial array</param>
        public static void MergeSort(int[] array, IComparer<int> compareCriterion, IIndexer indexer)
        {
            CheckInput(array, compareCriterion, indexer);
            int start = indexer.First;
            int finish = indexer.Last;
            MergeSortRecursive(array, start, finish, compareCriterion, indexer);
        }

        /// <summary>
        /// Bubbles the specified array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="compareCriterion">The compare criterion.</param>
        /// <param name="indexer">The indexer.</param>
        private static void Bubble(int[] array, IComparer<int> compareCriterion, IIndexer indexer)
        {
            int start = indexer.First; 
            int finish = indexer.Last;

            for (int i = start; i < finish; i = indexer.GetNext(i))
                for (int j = indexer.GetNext(i); j < finish; j = indexer.GetNext(j))
                {
                    if (j == -1 || i == -1)
                        return;
                    if (compareCriterion.Compare(array[i], array[j]) == 1)
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
        }

        /// <summary>
        /// Recursive Quick sort
        /// </summary>
        /// <param name="array">unsorted array</param>
        /// <param name="low">left- side index</param>
        /// <param name="high">right- side index</param>
        private static void QuickSort(int[] array, int low, int high, IComparer<int> compareCriterion, IIndexer indexer)
        { 
            int i = low;
            int j = indexer.GetHeigherElem(high);
            int medium = array[indexer.GetMedium(j, i)]; 
            do
            {
                while (compareCriterion.Compare( array[i], medium) == -1 )
                {
                    i = indexer.GetNext(i);
                    if (i == -1)
                    {
                        i = indexer.GetPrev(i);
                        break;
                    }

                }

                while (compareCriterion.Compare(array[j], medium) == 1)
                {
                    j = indexer.GetPrev(j);
                    if (j == -1)
                    {
                        j = indexer.GetNext(j);
                        break;
                    }
                }

                if (i <= j)
                {
                    int buffer = array[i];
                    array[i] = array[j];
                    array[j] = buffer;

                    i = indexer.GetNext(i);
                    j = indexer.GetPrev(j);
                }

            } while (i <= j && j != -1 && i != -1 );

            if (i < high & i != -1)
                QuickSort(array, i, high, compareCriterion, indexer);
            if (j > low & j != -1 )
                QuickSort(array, low, j, compareCriterion, indexer);
        }

        /// <summary>
        /// Recursive Merge Sort
        /// </summary>
        /// <param name="array">unsorted array</param>
        /// <param name="left">left- side index</param>
        /// <param name="right">right- side index</param>
        private static void MergeSortRecursive(int[] array, int left, int right, IComparer<int> compareCriterion, IIndexer indexer)
        {
            if (left < right)
            {
                int medium = array[indexer.GetMedium(left, right)]; 

                MergeSortRecursive(array, left, medium, compareCriterion, indexer);
                MergeSortRecursive(array, medium + 1, right, compareCriterion, indexer);
                Merge(array, left, medium, right, compareCriterion, indexer);
            }

        }

        /// <summary>
        /// Merge arrays with sort
        /// </summary>
        /// <param name="array">unsorted array</param>
        /// <param name="left">left- side index</param>
        /// <param name="middle">middle index</param>
        /// <param name="right">right- side index</param>
        private static void Merge(int[] array, int left, int middle, int right, IComparer<int> compareCriterion, IIndexer indexer)
        {
            int side1 = left;
            int side2 = middle + 1;
            int side3 = 0;
            int[] resultArray = new int[right - left + 1];

            while (side1 <= middle && side2 <= right)
            {
                if (compareCriterion.Compare(array[side1], array[side2]) == -1)
                {
                    resultArray[side3++] = array[side1++];
                }
                else
                {
                    resultArray[side3++] = array[side2++];
                }
            }

            while (side2 <= right)
            {
                resultArray[side3++] = array[side2++];
            }

            while (side1 <= middle)
            {
                resultArray[side3++] = array[side1++];
            }

            for (side3 = 0; side3 < right - left + 1; side3++)
                array[left + side3] = resultArray[side3];
        }

        /// <summary>
        /// Checks the input.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="compareCriterion">The compare criterion.</param>
        /// <param name="indexer">The indexer.</param>
        /// <exception cref="System.Exception">Array is empty</exception>
        /// <exception cref="System.NullReferenceException">Array is null</exception>
        /// <exception cref="System.ArgumentNullException">
        /// ICompare reference is empty
        /// or
        /// IIndexer reference is empty
        /// </exception>
        private static void CheckInput(int[] array, IComparer<int> compareCriterion, IIndexer indexer)
        {
            if(array.Length == 0)
                throw new Exception("Array is empty");
            if (array == null)
                throw new NullReferenceException("Array is null");
            if(compareCriterion == null)
                throw new ArgumentNullException("ICompare reference is empty");
            if (indexer == null)
                throw new ArgumentNullException("IIndexer reference is empty");
        }

     }
}
