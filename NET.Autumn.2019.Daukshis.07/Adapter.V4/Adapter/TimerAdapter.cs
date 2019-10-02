using System.Threading;
using Algorithms.V4.GcdImplementations;
using Algorithms.V4.LoggerImplementation;
using Algorithms.V4.StopWatcherImplementation;

namespace Algorithms.V4.Adapter
{
    public class TimerAdapter : EuclideanAlgorithm
    {
        private StopWatcher _timer;
        public TimerAdapter(StopWatcher timer)
        {
            _timer = timer;
        }

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