using System.Diagnostics;
using Algorithms.V4.GcdImplementations;
using Algorithms.V4.Interfaces;

namespace Algorithms.V4.StopWatcherImplementation
{
    public class StopWatcher : IStopWatcher
    {
        public long TimeInMilliseconds => _timer.ElapsedMilliseconds;
        private Stopwatch _timer;
        public StopWatcher()
        {
            _timer = new Stopwatch();
        }
        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}