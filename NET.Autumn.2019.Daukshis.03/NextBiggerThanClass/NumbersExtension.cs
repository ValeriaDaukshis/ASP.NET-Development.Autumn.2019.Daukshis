using System;
using System.Collections.Generic; 

namespace NextBiggerThanClass
{
    //не смотреть) в процессе)
    public class NumbersExtension
    {
        /// <summary>
        /// FindNextBiggerNumber
        /// </summary>
        /// <param name="number">initialNumber number</param>
        /// <returns>
        /// Next bigger number from digits of initialNumber number
        /// </returns>
        public static int? FindNextBiggerNumber(int number)
        {
            CheckInput(number); 
            if (number == Int32.MaxValue)
                return null;
            int[] initialArray = GetArrayFromNumber(number); 
            int difference = GenerateNumbers(initialArray, number);
            if (difference != Int32.MaxValue & number != Int32.MaxValue)
                return difference + number;

            return null;
        }

        /// <summary>
        /// Check Input data
        /// </summary>
        /// <param name="number">initial number</param>
        private static void CheckInput(int number)
        {
            if (Math.Abs(number) / 10 < 1)
                throw new Exception("Write bigger number");

            if (number > Int32.MaxValue)
                throw new ArgumentOutOfRangeException("Write smaller number");

            if (number < Int32.MinValue)
                throw new ArgumentOutOfRangeException("Write bigger number");
        }

        /// <summary>
        /// Generate Numbers
        /// </summary>
        /// <param name="number"> initial array</param>
        /// <param name="initialNumber">initial number</param>
        /// <returns>min difference between initialNumber and all generated</returns>
        private static int GenerateNumbers(int[] number, int initialNumber)
        { 
            int minDifference = Int32.MaxValue; 
            Array.Sort(number);
            List<int> a = new List<int>();
            bool limit = false;
            while (!limit)
            {
                int pointer = -1;
                for (int j = number.Length - 1; j > 0; j--)
                    if (number[j] > number[j - 1])
                    {
                        pointer = j-1;
                        break;
                    }

                if (pointer == -1)
                    return minDifference;

                int difference = 10;
                int pos = -1;
                for (int j = pointer+1; j < number.Length; j++)
                    if (number[pointer] < number[j] & number[j] - number[pointer] < difference)
                    {
                        difference = number[j] - number[pointer];
                        pos = j; 
                    }
                Swap(number, pointer, pos);

                //int numCopy = ParseArrayToInt(number);  
                limit = CompareNumbers(number, initialNumber, ref minDifference); 
                 a.Add(ParseArrayToInt(number));
                Array.Reverse(number, pointer+1, number.Length-pointer-1);
                //numCopy = ParseArrayToInt(number);  
                limit = CompareNumbers(number, initialNumber, ref minDifference);
                a.Add(ParseArrayToInt(number));
            }

            return minDifference;
        }

        /// <summary>
        /// Compare Numbers
        /// </summary>
        /// <param name="currentNumber">first number</param>
        /// <param name="initial">second number</param>
        /// <param name="minDifference">difference between numbers</param>
        private static bool CompareNumbers(int[] number, int initial, ref int minDifference)
        {
            int currentNumber = ArrayToInt(number);
            if (initial > currentNumber)
                return false;
            if (initial - currentNumber < minDifference)
                minDifference = currentNumber - initial;
            return false;
        }

        private static int ArrayToInt(int[] array)
        {
            int parsedNumber = 0;
            for (int i = 0; i < array.Length; i++)
            {
                parsedNumber = parsedNumber * (i + 1) + array[i];
            }

            return parsedNumber;
        }

        /// <summary>
        /// Parse Array To Int
        /// </summary>
        /// <param name="number">init array</param>
        /// <returns>parsed integer number from array</returns>
        private static int ParseArrayToInt(int[] number)
        {
            int currentNumber = 0;
            for (int i = 0; i < number.Length; i++)
                currentNumber = currentNumber * 10 + number[i];

            return currentNumber;
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
            List<int> digit = new List<int>();
            while (number > 0)
            {
                digit.Insert(0,number % 10);
                number /= 10;
            }
            return digit.ToArray();
        }
    }
}
