using System;
using Algorithms.V1.Interfaces;

namespace Algorithms.V1.GcdImplementations
{
    internal class EuclideanAlgorithm : Algorithm
    {
        protected override int Action(int number1, int number2)
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