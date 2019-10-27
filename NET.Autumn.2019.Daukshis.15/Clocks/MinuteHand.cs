using System;
using System.Timers;

namespace Clocks
{
    /// <summary>
    /// SecondHandEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class SecondHandEventArgs : EventArgs
    {
        public int Seconds { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecondHandEventArgs"/> class.
        /// </summary>
        /// <param name="seconds">The seconds.</param>
        public SecondHandEventArgs(int seconds)
        {
            Seconds = seconds;
        }
    }

    /// <summary>
    /// MinuteHandEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class MinuteHandEventArgs : EventArgs
    {
        public int Minutes { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MinuteHandEventArgs"/> class.
        /// </summary>
        /// <param name="minutes">The minutes.</param>
        public MinuteHandEventArgs(int minutes)
        {
            Minutes = minutes;
        }
    }

    /// <summary>
    /// SecondHand.
    /// </summary>
    class SecondHand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecondHand"/> class.
        /// </summary>
        /// <param name="seconds">The seconds.</param>
        public SecondHand(int seconds)
        {
            this.seconds = seconds;
            fullSeconds = seconds * 1000;
        }

        private int seconds;
        private int fullSeconds;
        public event EventHandler<SecondHandEventArgs> SecondEvent = delegate { };

        private Timer _timer;

        /// <summary>
        /// Timers the ticks.
        /// </summary>
        public void TimerTicks()
        {
            _timer = new Timer();
            _timer.Interval = fullSeconds;
            _timer.Elapsed += SecondHandChanged;
            _timer.Start();
            Console.ReadLine();
        }

        /// <summary>
        /// Finals the ring and stop timer.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="info">The <see cref="MinuteHandEventArgs"/> instance containing the event data.</param>
        public void FinalRingAndStopTimer(object sender, MinuteHandEventArgs info)
        {
            _timer.Stop();
            _timer.Dispose();
            Console.WriteLine("Time is out!");
        }

        private void SecondHandChanged(object sender, EventArgs info)
        {
            var temp = SecondEvent;
            temp?.Invoke(this, new SecondHandEventArgs(seconds));
            seconds--;
        }
    }

    /// <summary>
    /// MinuteHand.
    /// </summary>
    class MinuteHand
    {
        public int minutes;
        public event EventHandler<MinuteHandEventArgs> MinuteEvent = delegate { };

        /// <summary>
        /// Initializes a new instance of the <see cref="MinuteHand"/> class.
        /// </summary>
        /// <param name="minutes">The minutes.</param>
        public MinuteHand(int minutes)
        {
            this.minutes = minutes;
        }

        /// <summary>
        /// Updates the minute hand.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="info">The <see cref="SecondHandEventArgs"/> instance containing the event data.</param>
        public void UpdateMinuteHand(object sender, SecondHandEventArgs info)
        {
            this.Minutes = --minutes;
            Console.WriteLine($"Minute Handler changed. Minutes: {minutes}");
        }

        private int Minutes
        {
            get => minutes;
            set
            {
                minutes = value;
                if (minutes == 0)
                {
                    var temp = MinuteEvent;
                    temp?.Invoke(this, new MinuteHandEventArgs(minutes));
                }
            }
        }
    }
}
