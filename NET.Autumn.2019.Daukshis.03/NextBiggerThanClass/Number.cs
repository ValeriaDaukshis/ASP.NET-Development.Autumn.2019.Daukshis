using System;
using System.Collections.Generic;
using System.Linq;

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
        public static int  FindNextBiggerNumber(int number)
        {
            CheckInput(number); // 1241233
            int[] initialArray = GetArrayFromNumber(number);
            // initialArray.Reverse();
            int difference = GenerateNumbers(initialArray, number);
            if (difference != Int32.MaxValue & number != Int32.MaxValue)
                return difference + number;

            return -1;
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

         
        private static int GenerateNumbers(int[] number, int initial)
        { 
            var uniqueNumbers = new List<int>();
            var uniqueNumbersBool = new List<Boolean>();
            //uniqueNumbers.Add(number);
            int pointer = number.Length-1; //digit pointer
            int minDifference = Int32.MaxValue;
            int iterations = Factorial(number.Length) - 1;
            for (int i = 0; i < iterations; i++)
            {
                //Swap(number, pointer, pointer - 1);
                //if (pointer == number.Length - 1)
                //    pointer = number.Length - 2;
                //else if (pointer == number.Length)
                //    pointer = number.Length - 2;

                if (pointer == 1)
                {
                    Swap(number, 0, number.Length - 1);
                    pointer = number.Length - 1;
                }
                else
                {
                    Swap(number, pointer, pointer - 1);
                    pointer -= 1;
                }
                int numCopy = ReserveArrayToInt(number);
                uniqueNumbersBool.Add(uniqueNumbers.Contains(numCopy));
                uniqueNumbers.Add(numCopy);

                CompareNumbers(numCopy, initial, ref minDifference);
            }

            int n = uniqueNumbers.Count();
            uniqueNumbers.Contains(1241233);
            return minDifference;

        }

        private static void CompareNumbers(int currentNumber, int initial, ref int minDifference)
        {
            if (currentNumber - initial < minDifference & currentNumber - initial > 0)
                minDifference = currentNumber - initial;
        }

        private static int ReserveArrayToInt(int[] current)
        {
            int currentNumber = 0;
            for (int i = 0; i < current.Length; i++)
                currentNumber = currentNumber * 10 + current[i];

            return currentNumber;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private static void Swap(int[] number, int i, int j)
        {
            int tmp = number[i];
            number[i] = number[j];
            number[j] = tmp;
        }

        private static int Factorial(int numberLength)
        {
            int numberFactorial = 1;
            for (int i = 1; i <= numberLength; i++)
            {
                numberFactorial *= i;
            }

            return numberFactorial;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
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
