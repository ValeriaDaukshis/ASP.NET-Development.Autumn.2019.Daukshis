using System;
using System.Diagnostics;
using Algorithms.V3.Interfaces;

namespace Algorithms.V3.GcdImplementations
{
    public class EuclideanAlgorithm : IAlgorithm
    {
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

    public class EuclideanAlgorithmDecorator : IAlgorithm
    {
        private readonly EuclideanAlgorithm _algorithm;
        public long Milliseconds { set; get; }
        
        public EuclideanAlgorithmDecorator(EuclideanAlgorithm algorithm)
        {
            _algorithm = algorithm;
            Milliseconds = 0;
        }
        public int Calculate(int first, int second)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int result = _algorithm.Calculate(first, second);
            timer.Stop();
            Milliseconds = timer.ElapsedMilliseconds;
            return result; 
        }
    }
    
}