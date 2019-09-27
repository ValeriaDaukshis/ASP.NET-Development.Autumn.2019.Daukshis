using System;

namespace FindGcd
{
    public static class Gcd 
    {
        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="number1">The number1.</param>
        /// <param name="number2">The number2.</param>
        /// <returns>GCD of 2 numbers</returns>
        public static int FindGcdByEuclidean(int number1, int number2)
        {
            if (number1 == 0 & number2 != 0)
                return Math.Abs(number2);
            if (number2 == 0 & number1 != 0)
                return Math.Abs(number1);
            if (number1 == number2 & number1 == 0)
                return 0;

            number1 = Math.Abs(number1);
            number2 = Math.Abs(number2);
            while (number1 != number2)
            {
                if (number1 > number2)
                    number1 -= number2;
                else
                    number2 -= number1;
            }

            return number1 > number2 ? number1 : number2;
        }

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="number1">The number1.</param>
        /// <param name="number2">The number2.</param>
        /// <param name="number3">The number3.</param>
        /// <returns>GCD of 3 numbers</returns>
        public static int FindGcdByEuclidean(int number1, int number2, int number3)
        {
            int[] array = { Math.Abs(number1), Math.Abs(number2), Math.Abs(number3) };
            Array.Sort(array, new ReverseSorting());

            if (array[0] == 0)
                return 0;
            if (array[1] == 0)
                return array[0];
            if (array[2] == 0)
                return FindGcdByEuclidean(array[0], array[1]);

            int r0 = array[1];
            int r2 = 0;
            int r1 = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (r0 != 0)
                {
                    int q1 = array[i] / r0;
                    r1 = array[i] - q1 * r0;
                    r2 = r0;
                    r0 = r1; 
                }
                else
                    break;
            } 
            return r1 == 0 ? r2 : r1;
        }

        /// <summary>
        /// Finds the GCD by euclidean.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>GCD of numbers</returns>
        /// <exception cref="ArgumentException">Array has zero length</exception>
        public static int FindGcdByEuclidean(params int[] array)
        {
            if (array.Length == 0)
                throw new ArgumentException("Array has zero length");

            for (int i = 0; i < array.Length; i++)
                array[i] = Math.Abs(array[i]);

            Array.Sort(array, new ReverseSorting());
            int fixedLength = array.Length;

            if (array[0] != 0)
            {
                for (int i = 0; i < array.Length; i++)
                    if (array[i] == 0)
                    {
                        fixedLength = i;
                        break;
                    }
            }
            else
                return 0;

            int r0 = array[1];
            int r2 = 0;
            int r1 = 0;

            for (int i = 0; i < fixedLength; i++)
            {
                int q1;
                if (r0 == 0)
                {
                    q1 = array[i];
                    r1 = array[i] - q1;
                    r2 = q1;
                }
                else
                {
                    q1 = array[i] / r0;
                    r1 = array[i] - q1 * r0;
                    r2 = r0;
                }
                r0 = r1;

            }
            return r1 == 0 ? r2 : r1;
        }

        /// <summary>
        /// Finds the GCD by stein.
        /// </summary>
        /// <param name="number1">The number1.</param>
        /// <param name="number2">The number2.</param>
        /// <returns>GCD of 2 numbers</returns>
        public static int FindGcdByStein(int number1, int number2)
        {
            number1 = Math.Abs(number1);
            number2 = Math.Abs(number2);

            if (number1 == 0)
                return number2;
            if (number2 == 0)
                return number1;
            if (number1 == 1 & number2 != number1)
                return 1;
            if (number2 == 1 & number2 != number1)
                return 1;

            int k = 1;
            while (number1 != 0 & number2 != 0)
            {
                while (number1 % 2 == 0 & number2 % 2 == 0)
                {
                    number1 >>= 1; // num/2
                    number2 >>= 1;
                    k *= 2;
                }
                while (number1 % 2 == 0) number1 >>= 1;
                while (number2 % 2 == 0) number2 >>= 1;

                if (number1 >= number2)
                    number1 -= number2;
                else
                    number2 -= number1;
            }
            return number2 * k;
        }

        /// <summary>
        /// Finds the GCD by stein.
        /// </summary>
        /// <param name="number1">The number1.</param>
        /// <param name="number2">The number2.</param>
        /// <param name="number3">The number3.</param>
        /// <returns>GCD of 3 numbers</returns>
        public static int FindGcdByStein(int number1, int number2, int number3)
        {
            number1 = Math.Abs(number1);
            number2 = Math.Abs(number2);
            number3 = Math.Abs(number3);
            int[] array = { Math.Abs(number1), Math.Abs(number2), Math.Abs(number3) };

            int k = 1;
            while (array[0] != 0 & array[1] != 0 & array[2] != 0)
            {
                while (array[0] % 2 == 0 & array[1] % 2 == 0 & array[2] % 2 == 0)
                {
                    array[0] >>= 1; // num/2
                    array[1] >>= 1;
                    array[2] >>= 1;
                    k *= 2;
                }
                while (array[0] % 2 == 0) array[0] >>= 1;
                while (array[1] % 2 == 0) array[1] >>= 1;
                while (array[2] % 2 == 0) array[2] >>= 1;
                Array.Sort(array, new ReverseSorting()); 

                array[0] = array[0] - array[1];
            }
            return k * array[2];
        }

        /// <summary>
        /// FindGcdByStein
        /// </summary>
        /// <param name="array">array of numbers</param>
        /// <returns>
        /// GCD of numbers
        /// </returns>
        public static int FindGcdByStein(params int[] array)
        {
            if (array.Length == 0)
                throw new ArgumentException("Array has zero length");

            for (int i = 0; i < array.Length; i++)
                array[i] = Math.Abs(array[i]);

            int k = 1;
            while (!FindZeroNumbers(array))
            {
                while (!FindEvenNumbers(array))
                {
                    for (int i = 0; i < array.Length; i++)
                        array[i] >>= 1; // num/2 
                    k *= 2;
                }
                for (int i = 0; i < array.Length; i++)
                {
                    while (array[i] % 2 == 0 & array[i] != 0)
                        array[i] >>= 1;
                }

                Array.Sort(array, new ReverseSorting()); 

                array[0] = array[0] - array[1];
            }
            return k * array[array.Length - 1];
        }

        /// <summary>
        /// Finds the even numbers.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>returns true if 1 number is even</returns>
        private static bool FindEvenNumbers(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] % 2 != 0)
                    return true;
            return false;
        }

        /// <summary>
        /// Finds the even numbers.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>returns true if 1 number is zero</returns>
        private static bool FindZeroNumbers(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == 0)
                    return true;
            return false;
        }
    }
}