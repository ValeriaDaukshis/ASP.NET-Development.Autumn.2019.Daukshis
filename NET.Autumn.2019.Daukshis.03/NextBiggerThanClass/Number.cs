using System;
using System.Collections.Generic; 

namespace NextBiggerThanClass
{
    public class Number
    {
        /// <summary>
        /// FindNextBiggerNumber
        /// </summary>
        /// <param name="number">initial number</param>
        /// <returns>
        /// Next bigger number from digits of initial number
        /// </returns>
        public static int FindNextBiggerNumber(int number)
        {
            CheckInput(number);
            List<int> digit = GetArrayFromNumber(number);
            int minDifference = number;
            int nextBiggerNum = number;
            while (GenerateNumber(digit, digit.Count))
                nextBiggerNum = CompareNumbers(number, digit, ref minDifference, nextBiggerNum);

            if (nextBiggerNum == number)
                return -1;

            return nextBiggerNum;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
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
        /// 
        /// </summary>
        /// <param name="initialNum"></param>
        /// <param name="digits"></param>
        /// <param name="minDifference"></param>
        /// <param name="nextBiggerNumber"></param>
        /// <returns></returns>
        private static int CompareNumbers(int initialNum, List<int> digits, ref int minDifference, int nextBiggerNumber)
        {
            int generatedNumber = 0;
            for (int i = 0; i < digits.Count; i++)
            {
                generatedNumber = generatedNumber * 10 + digits[i];
            }

            if (generatedNumber - initialNum > 0 && generatedNumber - initialNum < minDifference)
            {
                nextBiggerNumber = generatedNumber;
                minDifference = generatedNumber - initialNum;
            }

            return nextBiggerNumber;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        private static Boolean GenerateNumber(List<int> number, int N)
        {
            int i = N - 2;
            while (i != -1 && number[i] >= number[i + 1])
                i--;
            if (i == -1)
                return false;

            int k = N - 1;
            while (number[i] >= number[k])
                k--;

            Swap(number, i, k);
            int left = i + 1;
            int right = N - 1;
            while (left < right)
                Swap(number, left++, right--);
            return true;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private static void Swap(List<int> number, int i, int j)
        {
            int tmp = number[i];
            number[i] = number[j];
            number[j] = tmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static List<int> GetArrayFromNumber(int number)
        {
            List<int> digit = new List<int>();
            while (number > 0)
            {
                digit.Add(number % 10);
                number /= 10;
            }
            return digit;
        }
    }
}
