using System;
using System.Timers;

namespace Clocks
{
    /// <summary>
    /// Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            SecondHand secondHand = new SecondHand(2);
            MinuteHand minuteHand = new MinuteHand(3);
            secondHand.SecondEvent += minuteHand.UpdateMinuteHand;
            minuteHand.MinuteEvent += secondHand.FinalRingAndStopTimer;
            secondHand.TimerTicks();
        }
    }
}