using System;
using System.Threading;
using Algorithms.V4.Interfaces;
using Algorithms.V4.StopWatcherImplementation;
using Logger = Algorithms.V4.LoggerImplementation.Logger;

namespace Algorithms.V4.GcdImplementations
{
    public class EuclideanAlgorithm : Logger, IAlgorithm
    {
        public virtual int Calculate(int number1, int number2)
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

    public class EuclideanAlgorithmDecorator : EuclideanAlgorithm
    {
        private IAlgorithm _algorithm;
        private ILogger _logger;
        public EuclideanAlgorithmDecorator(IAlgorithm algorithm,ILogger logger)
        {
            _algorithm = algorithm;
            _logger = logger;
        }

        public override int Calculate(int number1, int number2)
        {
            _logger = new Logger();
            int result = 0;
            try
            {
                result = _algorithm.Calculate(number1, number2);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

            return result;
        }
    }
}