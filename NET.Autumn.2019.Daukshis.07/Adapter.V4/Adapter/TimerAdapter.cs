using System.Threading;
using Algorithms.V4.GcdImplementations;
using Algorithms.V4.Interfaces;
using Algorithms.V4.LoggerImplementation;
using Algorithms.V4.StopWatcherImplementation;

namespace Algorithms.V4.Adapter
{
    public class TimerAdapter : EuclideanAlgorithm
    {
        private IStopWatcher _timer;
        public TimerAdapter(IStopWatcher timer)
        {
            _timer = timer;
        }

        /// <summary>
        /// Calculates the specified first.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="timeInMilliseconds">The time in milliseconds.</param>
        /// <returns>Calculates GCD by Euclidean</returns>
        public int Calculate(int first, int second, out long timeInMilliseconds)
        {
            _timer = new StopWatcher();
            _timer.Start();
            Thread.Sleep(200);
            int result = new EuclideanAlgorithmDecorator(new EuclideanAlgorithm(), new Logger()).Calculate(first, second);
            _timer.Stop();
            timeInMilliseconds = _timer.TimeInMilliseconds;
            return result;
        }
    }
}