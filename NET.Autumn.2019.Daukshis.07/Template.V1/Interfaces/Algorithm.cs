using System;
using System.Diagnostics;

namespace Algorithms.V1.Interfaces
{
    internal abstract class Algorithm
    {
        /// <summary>
        /// Calculates the specified number1.
        /// </summary>
        /// <param name="number1">The number1.</param>
        /// <param name="number2">The number2.</param>
        /// <returns>GCD of 2 numbers</returns>
        public int Calculate(int number1, int number2)
        {
            if (number1 == 0 & number2 != 0)
                return Math.Abs(number2);
            if (number2 == 0 & number1 != 0)
                return Math.Abs(number1);
            if (number1 == number2 & number1 == 0)
                return 0;

            return Action(number1, number2);
        }

        /// <summary>
        /// Calculates the specified number1.
        /// </summary>
        /// <param name="number1">The number1.</param>
        /// <param name="number2">The number2.</param>
        /// <param name="milliseconds">The milliseconds.</param>
        /// <returns>Calculates GCD of 2 numbers by Euclidean and returns algorithm execution time</returns>
        public int Calculate(int number1, int number2, out long milliseconds)
        {
            milliseconds = 0;

            if (number1 == 0 & number2 != 0)
                return Math.Abs(number2);
            if (number2 == 0 & number1 != 0)
                return Math.Abs(number1);
            if (number1 == number2 & number1 == 0)
                return 0;

            Stopwatch t = new Stopwatch();
            t.Start();
            int result =  Action( number1, number2);
            t.Stop();
            milliseconds = t.ElapsedMilliseconds;
            return result;
        }
	
        protected abstract int Action(int number1, int number2);
    }
}