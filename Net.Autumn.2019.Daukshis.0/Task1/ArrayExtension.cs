using System;

namespace Task1
{
     public static class ArrayExtension 
     {
        public static void SortNumbers(int[] array, ICompare compareCriterion, IIndexCriterion indexCriterion)
        {
            BubbleSort(array, compareCriterion, indexCriterion); 
        }

        private static void BubbleSort(int[] array, ICompare compareCriterion, IIndexCriterion indexCriterion)
        {
            int start = indexCriterion.GetStart();
            int step = indexCriterion.GetStep();
            int finish = indexCriterion.GetFinish();

            for (int i = start; i < finish; i+=step)
                for (int j = i + step; j < finish; j+=step)
                    if (compareCriterion.CompareNumbers(array[i], array[j]) == 1)
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
        }

     }
}
