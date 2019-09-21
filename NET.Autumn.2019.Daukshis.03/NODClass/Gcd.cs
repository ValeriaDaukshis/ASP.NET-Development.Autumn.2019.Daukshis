using System;
using System.Diagnostics;
using System.Reflection;
using NODClass;

namespace GcdClass
{
    public class Gcd : IGcd
    {
        /// <summary>
        /// Evklid Method
        /// </summary>
        /// <param name="num1">number 1</param>
        /// <param name="num2">number 2</param>
        /// <returns>
        /// GCD of 2 numbers
        /// </returns>
        public int EvklidMethod(int num1, int num2)
        {
            if (num1 == 0 & num2 != 0)
                return Math.Abs(num2);
            if (num2 == 0 & num1 != 0)
                return Math.Abs(num1);
            if (num1 == num2 & num1 == 0)
                return 0;

            num1 = Math.Abs(num1);
            num2 = Math.Abs(num2);
            while (num1 != num2)
            {
                if (num1 > num2)
                    num1 -= num2;
                else
                    num2 -= num1;
            }
            return num1 > num2 ? num1 : num2;
        }

        /// <summary>
        /// Evklid Method
        /// </summary>
        /// <param name="num1">number 1</param>
        /// <param name="num2">number 2</param>
        /// <param name="num3">number 3</param>
        /// <returns>GCD of 3 numbers</returns>
        public int EvklidMethod(int num1, int num2, int num3)
        {
            int[] array = { Math.Abs(num1), Math.Abs(num2), Math.Abs(num3) };
            Array.Sort(array);
            Array.Reverse(array);

            if (array[0] == 0)
                return 0;
            if (array[1] == 0)
                return array[0];
            if (array[2] == 0)
                return EvklidMethod(array[0], array[1]);

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
        /// Evklid Method
        /// </summary>
        /// <param name="array">array of numbers</param>
        /// <returns>v</returns>  
        public int EvklidMethod(params int[] array)
        {
            if (array.Length == 0)
                throw new ArgumentException("Array has zero length");

            for (int i = 0; i < array.Length; i++)
                array[i] = Math.Abs(array[i]);

            Array.Sort(array);
            Array.Reverse(array);
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
        /// BinaryGcdMethod
        /// </summary>
        /// <param name="number1">number 1</param>
        /// <param name="number2">number 2</param>
        /// <returns>
        /// GCD of 2 numbers
        /// </returns>
        public int BinaryMethod(int number1, int number2)
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
        /// BinaryGcdMethod
        /// </summary>
        /// <param name="number1">number 1</param>
        /// <param name="number2">number 2</param>
        /// <param name="number3">number 3</param>
        /// <returns>GCD of 3 numbers</returns>
        public int BinaryMethod(int number1, int number2, int number3)
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
                Array.Sort(array);
                Array.Reverse(array);

                array[0] = array[0] - array[1];
            }
            return k * array[2];
        }

        /// <summary>
        /// BinaryGcdMethod
        /// </summary>
        /// <param name="array">array of numbers</param>
        /// <returns>
        /// GCD of numbers
        /// </returns>
        public int BinaryMethod(params int[] array)
        {
            if (array.Length == 0)
                throw new ArgumentException("Array has zero length");

            for (int i = 0; i < array.Length; i++)
                array[i] = Math.Abs(array[i]);

            int k = 1;
            while (Gcd.ZeroNumbers(array))
            {
                while (EvenNumbers(array))
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

                Array.Sort(array);
                Array.Reverse(array);

                array[0] = array[0] - array[1];
            }
            return k * array[array.Length - 1];
        }

        /// <summary>
        /// ZeroNumbers
        /// </summary>
        /// <param name="array">init array</param>
        /// <returns>
        /// returns true if all numbers are zero
        /// </returns>
        private static Boolean ZeroNumbers(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == 0)
                    return false;
            return true;
        }

        /// <summary>
        /// EvenNumbers
        /// </summary>
        /// <param name="array">init array</param>
        /// <returns>
        /// returns true if all numbers are even 
        /// </returns>
        private static Boolean EvenNumbers(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] % 2 != 0)
                    return false;
            return true;
        }

        public static long Timer(string methodName, params object[] countOfParams)
        {
            Type[] type = new Type[countOfParams.Length];
            for (int i = 0; i < countOfParams.Length; i++)
                type[i] = typeof(int);
            MethodInfo info;
            
            info = typeof(IGcd).GetMethod(methodName,
                    BindingFlags.Public | BindingFlags.Instance,
                    null,
                    CallingConventions.Any,
                    type,
                    null); 

            var time = new Stopwatch();
            time.Start();
            info.Invoke(new Gcd(), countOfParams);
            time.Stop();
            return time.ElapsedMilliseconds;
        }

    }
}
