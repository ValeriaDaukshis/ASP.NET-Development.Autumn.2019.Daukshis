using System;

namespace InsertNumberTask
{
    public class InsertIntoNumber
    {
        /// <summary>
        /// Insert number
        /// </summary>
        /// <param name="initialNum">changed number</param>
        /// <param name="insertedNum">inserted number</param>
        /// <param name="i">right position</param>
        /// <param name="j">left position</param>
        /// <returns>
        /// Number if put inserted into changed from i to j position 
        /// </returns>
        public static int InsertNumber(int initialNum, int insertedNum, int i, int j)
        {
            CheckInput(initialNum, insertedNum, i, j);
            insertedNum = insertedNum & (int)(Math.Pow(2, j - i + 1) - 1);
            insertedNum = insertedNum << i;

            if (i == j)
                initialNum = initialNum & (15 - (int)Math.Pow(2, i));
            else if (j <= 3 & i <= 3)
                initialNum = initialNum & (15 - (int)Math.Pow(2, i) - (int)Math.Pow(2, j));
            else if (j > 3 & i <= 3)
                initialNum = initialNum & (15 - (int)Math.Pow(2, i));
            else if (i > 3 & j > 3)
                initialNum = initialNum & 15;

            return initialNum | insertedNum;
        }

        /// <summary>
        /// Check input
        /// </summary>
        /// <param name="number1">first number</param>
        /// <param name="number2">second number</param>
        /// <param name="i">start position</param>
        /// <param name="j">final position</param>
        private static void CheckInput(int number1, int number2, int i, int j)
        {
            if (number1 > 16 & number1 < 0)
            {
                throw new Exception("Incorrect initialNum");
            }

            if (number2 > 16 & number2 < 0)
            {
                throw new Exception("Incorrect insertedNum");
            }

            if (i > j)
            {
                throw new Exception("Incorrect index i or j");
            }

        }
    }
}
