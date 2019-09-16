using System;

namespace Task1
{
     public static class ArrayExtension 
     { 
         public static void SortNumbers(int[] array, ICriterion criterion, int convertTo)
         {
             string[] parsedArr = new string[array.Length];
             Converter(array, parsedArr, convertTo);
             BubbleSort(parsedArr, criterion);
             ConvertToInt(parsedArr, array); 
         }

         private static void BubbleSort(string[] array, ICriterion criterion)
         {
             criterion = new CompareBySmth();

             for (int i = 0; i < array.Length; i++) 
                for (int j = i + 1; j < array.Length; j++) 
                    if (criterion.CompareNumbers(array[i],array[j]))
                    {
                        string temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }  
         }

         private static void Converter(int[] array,string[] parsedArr, int toBase)
         {
            // перевод в какую-то с/с
            // от 2 до 9 с/с
            for (int i = 0; i < array.Length; i++)
            {
                int dec = array[i];
                string str = "";
                while (dec > 0)
                {
                    str = String.Concat(Convert.ToString(dec % toBase), str);
                    dec /= toBase;
                }
                parsedArr[i] = str;
            }

         }

         private static void ConvertToInt(string[] array, int[] convertedArr)
         {
              // код перевода в 10 с/с
         }

     }
}
