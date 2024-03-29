using System;
using Algorithms.V2.Interfaces;

namespace Algorithms.V2.GcdImplementations
{
    public class EuclideanAlgorithm : IAlgorithm
    {
        /// <summary>
        /// Calculates the specified number1.
        /// </summary>
        /// <param name="number1">The number1.</param>
        /// <param name="number2">The number2.</param>
        /// <returns>Calculates GCD of 2 numbers</returns>
        public int Calculate(int number1, int number2)
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
    }
}