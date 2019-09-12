using System;

namespace NODClass
{
    public static class Nod
    {
        /// <summary>
        /// Evklid Method
        /// </summary>
        /// <param name="num1">number 1</param>
        /// <param name="num2">number 2</param>
        /// <returns>
        /// Numbers NOD
        /// </returns>
        public static int EvklidMethod(int num1, int num2)
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
        /// <returns>Numbers NOD</returns>
        public static int EvklidMethod(int num1, int num2, int num3)
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
        /// <returns>Numbers NOD</returns>
        public static int EvklidMethod(params int[] array)
        {
            if(array.Length == 0)
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
    }
}
