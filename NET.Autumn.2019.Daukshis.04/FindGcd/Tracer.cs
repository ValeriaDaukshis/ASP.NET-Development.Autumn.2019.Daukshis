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
        public void StartTrace()
        {
            _timer.Start();
        }

        public void StopTrace()
        {
            _timer.Stop();
        }

        public long GetTraceResult()
        {
            return _timer.ElapsedMilliseconds;
        }
    }
}