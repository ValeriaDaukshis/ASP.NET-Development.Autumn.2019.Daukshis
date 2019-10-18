using System.Diagnostics;
using Algorithms.V4.Interfaces;

namespace Algorithms.V4.StopWatcherImplementation
{
    public class StopWatcher : IStopWatcher
    {
        /// <inheritdoc/>
        public long TimeInMilliseconds => this.timer.ElapsedTicks;

        private readonly Stopwatch timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="StopWatcher"/> class.
        /// </summary>
        public StopWatcher()
        {
            this.timer = new Stopwatch();
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            this.timer.Start();
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            this.timer.Stop();
        }
    }
}