using System;
using Algorithms.V1.Interfaces;

namespace Algorithms.V1.GcdImplementations
{
    internal class StainAlgorithm : Algorithm
    {
        /// <summary>
        /// Actions the specified number1.
        /// </summary>
        /// <param name="number1">The number1.</param>
        /// <param name="number2">The number2.</param>
        /// <returns>Calculates GCD of 2 numbers by Euclidean</returns>
        protected override int Action(int number1, int number2)
        {
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
    }
}