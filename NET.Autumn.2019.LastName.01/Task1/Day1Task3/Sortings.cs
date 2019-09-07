using System; 

namespace Day1Task3
{
    public class Sortings
    {
        public static void QSort(int[] array)
        {
            CheckInput(array); 
            QuickSort(array, 0, array.Length - 1);
        }

        public static void MergeSort(int[] array)
        {
            CheckInput(array); 
            MergeSortRecursive(array, 0, array.Length - 1);
        }

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

        private static void Merge(int[] array, int left, int medium, int right)
        {
            int iteration1 = left;
            int iteration2 = medium + 1;
            int iteration3 = 0;
            int[] ResultArray = new int[right - left + 1];

            while (iteration1 <= medium && iteration2 <= right)
            {
                if (array[iteration1] < array[iteration2])
                {
                    ResultArray[iteration3++] = array[iteration1++];
                }
                else
                {
                    ResultArray[iteration3++] = array[iteration2++];
                }

            }

            while (iteration2 <= right)
            {
                ResultArray[iteration3++] = array[iteration2++];
            }

            while (iteration1 <= medium)
            {
                ResultArray[iteration3++] = array[iteration1++];
            }

            for (iteration3 = 0; iteration3 < right - left + 1; iteration3++)
                array[left + iteration3] = ResultArray[iteration3];
        }

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

        private static void CheckInput(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            else if (array.Length == 0)
            {
                throw new ArgumentException("Array has zero length");
            }
        }
    }
}
