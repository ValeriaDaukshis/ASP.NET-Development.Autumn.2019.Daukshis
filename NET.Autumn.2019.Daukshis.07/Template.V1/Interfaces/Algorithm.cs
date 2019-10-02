using System;
using System.Diagnostics;

namespace Algorithms.V1.Interfaces
{
    internal abstract class Algorithm
    {
        public int Calculate(int first, int second)
        {
            return Action(first, second);
        }

        public int Calculate(int first, int second, out long milliseconds)
        {
            Stopwatch t = new Stopwatch();
            t.Start();
            int result =  Action(first, second);
            t.Stop();
            milliseconds = t.ElapsedMilliseconds;
            return result;
        }
	
        protected abstract int Action(int first, int second);
    }
}