using System;
using System.Collections.Generic; 

namespace NextBiggerThanClass
{
    // код максимально некрасивый
    // описание в методе GenerateNumbers
    public static class NumbersExtension
    {
        /// <summary>
        /// FindNextBiggerNumber
        /// </summary>
        /// <param name="number">initialNumber number</param>
        /// <param name="previous">The previous.</param>
        /// <param name="compare">The compare.</param>
        /// <returns>
        /// Next less number from digits of initial number
        /// </returns>
        public static int? FindPreviousLessThan(int number,IPrevious previous, IComparer<int> compare)
        {
            CheckInput(number);
            int[] initialArray = GetArrayFromNumber(number);
            if (!CheckNumber(initialArray))
                return null;
            
            int minDifference = GenerateNumbers(initialArray, number, previous, compare);
            
            if (minDifference != int.MaxValue)
                return  number - minDifference ;

            return null;
        }

        /// <summary>
        /// Checks the number.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>
        /// false if there is no less number from digits of initial number
        /// </returns>
        private static bool CheckNumber(int[] array)
        {
            for (int i = 0 ; i < array.Length-1; i++)
                if (array[i] > array[i + 1])
                    return true;
            return false;
        }

        /// <summary>
        /// Check Input data
        /// </summary>
        /// <param name="number">initial number</param>
        private static void CheckInput(int number)
        {
            if(number < 10)
                throw new ArgumentException("Number is less than 10"); 
        }

        /// <summary>
        /// Generate Numbers
        /// </summary>
        /// <param name="number">initial array</param>
        /// <param name="initialNumber">initial number</param>
        /// <param name="previous">The previous.</param>
        /// <param name="compare">The compare.</param>
        /// <returns>
        /// min difference between initialNumber and all generated
        /// </returns> 
        private static int GenerateNumbers(int[] number, int initialNumber,IPrevious previous, IComparer<int> compare)
        // этап 1
        // меняем 2 последние цифры числа
        // если получившееся число > исходного => откат
        // этап 2
        // переходим на след разряд (передвигаем pointer)
        // этап 3
        // просматриваем цифры, находящиеся правее pointer
        // среди цифр меньше, чем указатель ищем максимальное
        //   3.1
        //   если такого нет, передвигаем указатель, переходим к этапу 3
        //   3.2 
        //   такого нет + указатель на 0 элементе => сортируем подмассив начиная со 2 несовпадающего элемента с исходным числом, выход
        //   3.3
        //   есть + указатель на 0 элементе
        //   свап указатель и найденное число
        //   сортируем подмассив начиная со 2 несовпадающего элемента с исходным числом, выход
        //   3.4
        //   есть + указатель НЕ на 0 элементе
        //   свап, переходим к этапу 1
        {
            int minDifference = int.MaxValue;
            int numOfIterations = 0;
            while (true)
            {
                numOfIterations++;
                int[] copiedNumber = new int[number.Length]; 
                Array.Copy(number, copiedNumber, number.Length);
                
                int pointer = number.Length - 2;
                Swap(number, pointer + 1, pointer);

                bool isNumberLess = previous.CompareNumbers(number, initialNumber, ref minDifference);
                if (!isNumberLess)
                    number = copiedNumber; 
                else if (numOfIterations == 1)
                    return minDifference;
                pointer--;
                
                int nextLessDigitPosition = 0;
                while(nextLessDigitPosition != -1 || pointer >= 0)
                {
                    nextLessDigitPosition = FindNextLessDigit(number, -1, pointer);

                    if (nextLessDigitPosition == -1 & pointer == 0)
                    {
                        SortSubArray(number, initialNumber, compare);
                        previous.CompareNumbers(number, initialNumber, ref minDifference);
                        return minDifference;
                    }
                    
                    if (nextLessDigitPosition == -1 )
                        pointer--;

                    if (nextLessDigitPosition != -1 & pointer == 0)
                    {
                        Swap(number, nextLessDigitPosition, pointer);
                        SortSubArray(number, initialNumber, compare);
                        previous.CompareNumbers(number, initialNumber, ref minDifference);
                        return minDifference;
                    }

                    if (nextLessDigitPosition != -1)
                    {
                        Swap(number, nextLessDigitPosition, pointer);
                        previous.CompareNumbers(number, initialNumber, ref minDifference);
                        break;
                    }
                } 
            } 
        }

        /// <summary>
        /// Finds the next less digit.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="nextLessDigitPosition">The next less digit position.</param>
        /// <param name="pointer">The pointer.</param>
        /// <returns>
        ///  next Less Digit Position
        /// </returns>
        private static int FindNextLessDigit(int[] number, int nextLessDigitPosition, int pointer)
        {
            int difference = 10; 
            for (int j = pointer + 1; j < number.Length; j++)
                if (number[pointer] > number[j] & number[pointer] - number[j] < difference)
                {
                    difference = number[pointer] - number[j];
                    nextLessDigitPosition = j;
                }

            return nextLessDigitPosition;
        }

        /// <summary>
        /// Sorts the sub array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="initial">The initial.</param>
        /// <param name="compare">The compare.</param>
        private static void SortSubArray(int[] array, int initial, IComparer<int> compare)
        {
            //compare each digit
            int pointer = (int)Math.Pow(10, array.Length-1);
            int lowPosition = 0;
            for(int i = 0 ; i < array.Length; i++)
            {
                if (array[i] != initial / pointer % 10)
                {
                    lowPosition = i + 1;
                    break; 
                }

                pointer /= 10;
            }
            Array.Sort(array, lowPosition, array.Length - lowPosition, compare);
        } 
         
        /// <summary>
        /// Swap
        /// </summary>
        /// <param name="number">init array</param>
        /// <param name="i">first position</param>
        /// <param name="j">second position</param>
        private static void Swap(int[] number, int i, int j)
        {
            int tmp = number[i];
            number[i] = number[j];
            number[j] = tmp;
        }

        /// <summary>
        /// GetArrayFromNumber
        /// </summary>
        /// <param name="number">init number</param>
        /// <returns>Array of number's digits</returns>
        private static int[] GetArrayFromNumber(int number)
        {
            int numberLength = 0;
            int numberCopy = number;
            for (int i = 10; numberCopy > 0; numberLength++)
            {
                numberCopy /= i;
            }
            
            int[] array = new int[numberLength];
            int j = numberLength - 1;
            while (number > 0)
            {
                array[j] = number % 10;
                number /= 10;
                j--;
            }

            return array;
        }
    }
}
