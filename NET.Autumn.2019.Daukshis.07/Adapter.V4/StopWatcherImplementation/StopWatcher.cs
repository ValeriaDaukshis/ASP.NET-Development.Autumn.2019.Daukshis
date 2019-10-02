using System.Diagnostics;
using Algorithms.V4.Interfaces;

namespace Algorithms.V4.StopWatcherImplementation
{
    public class StopWatcher : IStopWatcher
    {
        public long TimeInMilliseconds => _timer.ElapsedMilliseconds;
        private Stopwatch _timer;
        /// <summary>
        /// Initializes a new instance of the <see cref="StopWatcher"/> class.
        /// </summary>
        public StopWatcher()
        {
            _timer = new Stopwatch();
        }
        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            _timer.Start();
        }
        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            _timer.Stop();
        }
    }
}