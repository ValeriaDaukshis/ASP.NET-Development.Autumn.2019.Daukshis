using System;
using Algorithms.V4.Interfaces;
using Logger = Algorithms.V4.LoggerImplementation.Logger;

namespace Algorithms.V4.GcdImplementations
{
    public class EuclideanAlgorithm : IAlgorithm
    {
        /// <summary>
        /// Calculates the specified number1.
        /// </summary>
        /// <param name="number1">The number1.</param>
        /// <param name="number2">The number2.</param>
        /// <returns>Calculates GCD of 2 numbers by Euclidean</returns>
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
        private readonly IAlgorithm algorithm;
        private ILogger logger;
        private IStopWatcher stopWatcher;
        private long Milliseconds { set; get; }

        public EuclideanAlgorithmDecorator(IAlgorithm algorithm, ILogger logger, IStopWatcher stopWatcher)
        {
            this.algorithm = algorithm;
            this.logger = logger;
            this.stopWatcher = stopWatcher;
        }

        /// <summary>
        /// Calculates the specified number1.
        /// </summary>
        /// <param name="number1">The number1.</param>
        /// <param name="number2">The number2.</param>
        /// <returns>
        /// Calculates GCD of 2 numbers by Euclidean
        /// </returns>
        public int Calculate(int number1, int number2)
        {
            this.logger = new Logger();
            int result = 0;
            try
            {
                this.stopWatcher.Start();
                result = this.algorithm.Calculate(number1, number2);
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message);
            }
            finally
            {
                this.stopWatcher.Stop();
                this.Milliseconds = this.stopWatcher.TimeInMilliseconds;
            }

            return result;
        }
    }
}