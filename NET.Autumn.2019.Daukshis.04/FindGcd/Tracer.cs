using System.Diagnostics;

namespace FindGcd
{
    public class Tracer : ITracer
    {
        private Stopwatch _timer; 
        public Tracer()
        {
            _timer = new Stopwatch();
        }

        /// <summary>
        /// Starts the trace.
        /// </summary>
        public void StartTrace()
        {
            _timer.Start();
        }

        /// <summary>
        /// Stops the trace.
        /// </summary>
        public void StopTrace()
        {
            _timer.Stop();
        }

        /// <summary>
        /// Gets the trace result.
        /// </summary>
        /// <returns>trace result</returns>
        public long GetTraceResult()
        {
            return _timer.ElapsedMilliseconds;
        }
    }
}