using System;

namespace IndexSearchTask
{
    public static class SearchElement
    {
        public static object FindIndex(int[] array)
        {
            CheckInput(array);
            FindMiddleElement(array);
            return 0;
        }

        private static object FindMiddleElement(int[] array)
        {
            for (int i = 1 ; i < array.Length; i++)
                if (ElementsSum(array, 0, i - 1) == ElementsSum(array, i + 1, array.Length - 1))
                    return array[i];
            return null;
        }

        private static int ElementsSum(int[] array, int low, int high)
        {
            if (low < 0 || high > array.Length - 1)
                throw new ArgumentOutOfRangeException();
            if (low > high)
                throw new ArgumentException("Low index is more than high index");

            int sum = 0;
            for (int i = low; i < high; i++)
                sum += array[i];
            
            return sum;
        }

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
