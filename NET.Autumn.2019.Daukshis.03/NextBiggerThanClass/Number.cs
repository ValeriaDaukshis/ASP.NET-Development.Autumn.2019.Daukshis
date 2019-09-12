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
            if (number == Int32.MaxValue)
                return -1;
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
            int minDifference = Int32.MaxValue;
            int iterations = Factorial(number.Length) - 1;
            Array.Sort(number);
            for (int i = 0; i < iterations; i++)
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

                int numCopy = ReserveArrayToInt(number);
                uniqueNumbersBool.Add(uniqueNumbers.Contains(numCopy));
                uniqueNumbers.Add(numCopy);

                CompareNumbers(numCopy, initial, ref minDifference);

                //ReverceArr(number, pointer); 
                Array.Reverse(number, pointer+1, number.Length-pointer-1);
                numCopy = ReserveArrayToInt(number);
                uniqueNumbersBool.Add(uniqueNumbers.Contains(numCopy));
                uniqueNumbers.Add(numCopy);

                CompareNumbers(numCopy, initial, ref minDifference);
            }

            int n = uniqueNumbers.Count();
            uniqueNumbers.Contains(1241233);
            return minDifference;

        }

        private static void ReverceArr(int[] arr, int start)
        {
            for (int i = start; i < (arr.Length - start) / 2; i++)
            {
                int tmp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = tmp;
            }
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

        private static int Pow(int number, int pow)
        {
            int result = 1;
            for (int i = 0; i < pow; i++)
                result *= number;
            return result;
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
