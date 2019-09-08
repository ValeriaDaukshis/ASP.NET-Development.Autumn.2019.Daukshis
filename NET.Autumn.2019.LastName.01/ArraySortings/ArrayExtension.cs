using System;

namespace ArraySortings
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Quick sort
        /// </summary>
        /// <param name="array">initial array</param>
        public static void QSort(int[] array)
        {
            CheckInput(array);
            QuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Merge Sort
        /// </summary>
        /// <param name="array">initial array</param>
        public static void MergeSort(int[] array)
        {
            CheckInput(array);
            MergeSortRecursive(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Recursive Merge Sort
        /// </summary>
        /// <param name="array">unsorted array</param>
        /// <param name="left">left- side index</param>
        /// <param name="right">right- side index</param>
        private static void MergeSortRecursive(int[] array, int left, int right)
        {
            if (left < right)
            {
                int medium = (left + right) / 2;

                MergeSortRecursive(array, left, medium);
                MergeSortRecursive(array, medium + 1, right);
                Merge(array, left, medium, right);
            }

        }

        /// <summary>
        /// Merge arrays with sort
        /// </summary>
        /// <param name="array">unsorted array</param>
        /// <param name="left">left- side index</param>
        /// <param name="middle">middle index</param>
        /// <param name="right">right- side index</param>
        private static void Merge(int[] array, int left, int middle, int right)
        {
            int side1 = left;
            int side2 = middle + 1;
            int side3 = 0;
            int[] resultArray = new int[right - left + 1];

            while (side1 <= middle && side2 <= right)
            {
                if (array[side1] < array[side2])
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
        /// Recursive Quick sort
        /// </summary>
        /// <param name="array">unsorted array</param>
        /// <param name="low">left- side index</param>
        /// <param name="high">right- side index</param>
        private static void QuickSort(int[] array, int low, int high)
        {
            int i = low;
            int j = high;
            int medium = array[(i + j) / 2];

            do
            {
                while (array[i] < medium) { i++; }
                while (array[j] > medium) { j--; }

                if (i <= j)
                {
                    int buffer = array[i];
                    array[i] = array[j];
                    array[j] = buffer;

                    ++i;
                    --j;
                }
            } while (i <= j);

            if (i < high)
                QuickSort(array, i, high);
            if (j > low)
                QuickSort(array, low, j);
        }

        /// <summary>
        /// Check input data
        /// </summary>
        /// <param name="array">initial array</param>
        private static void CheckInput(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array has zero length");
            }
        }
    }
}

