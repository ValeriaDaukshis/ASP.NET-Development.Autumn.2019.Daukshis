namespace NextBiggerThanClass
{
    public class FindPreviousLess : IPrevious
    {
        /// <summary>
        /// Compares the numbers.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="initialNumber">The initial number.</param>
        /// <param name="minDifference">The minimum difference.</param>
        /// <returns>
        /// true, if number is less than initial one
        /// </returns>
        public bool CompareNumbers(int[] number, int initialNumber, ref int minDifference)
        {
            int currentNumber = ArrayToInt(number);
            if (currentNumber < 0)
                return false;
            if (initialNumber <= currentNumber)
                return false;
            if (initialNumber - currentNumber < minDifference)
                minDifference = initialNumber - currentNumber;
            return true;
        }

        /// <summary>
        /// Arrays to int.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>
        /// parsed array to int
        /// </returns>
        private static int ArrayToInt(int[] array)
        {
            int parsedNumber = 0;
            for (int i = 0; i < array.Length; i++)
            {
                parsedNumber = parsedNumber * 10 + array[i];
            }

            return parsedNumber;
        }
    }
}