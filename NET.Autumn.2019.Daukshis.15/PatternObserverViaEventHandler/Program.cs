using System;

namespace PatternObserverViaEventHandler
{
    /// <summary>
    /// Program.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Thermostat thermostat = new Thermostat();
            Heater heater = new Heater(30);
            Cooler cooler = new Cooler(40);
            
            thermostat.TemperatureChanged += heater.OnTemperatureChanged;
            thermostat.TemperatureChanged += cooler.Update;
            
            thermostat.EmulateTemperatureChange();
            thermostat.EmulateTemperatureChange();
            
            thermostat.TemperatureChanged -= cooler.Update;
            thermostat.EmulateTemperatureChange();
            
        }
    }

    /// <summary>
    /// TemperatureChangedEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class TemperatureChangedEventArgs : EventArgs
    {
        public int NewTemperature { get; private set; }
        public TemperatureChangedEventArgs(int newTemperature)
        {
            NewTemperature = newTemperature;
        }
    }

    /// <summary>
    /// Cooler.
    /// </summary>
    public class Cooler
    {
        public Cooler(int temperature) => Temperature = temperature;

        public int Temperature { get; private set; }

        /// <summary>
        /// Updates the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="info">The <see cref="TemperatureChangedEventArgs"/> instance containing the event data.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Update(object sender, TemperatureChangedEventArgs info)
        {
            if (info is null)
            {
                throw new ArgumentNullException();
            }
            
            Console.WriteLine(info.NewTemperature > Temperature
                ? $"Cooler: On. Changed:{Math.Abs(info.NewTemperature - Temperature)}"
                : $"Cooler: Off. Changed:{Math.Abs(info.NewTemperature - Temperature)}");
        }
    }

    /// <summary>
    /// Heater.
    /// </summary>
    public class Heater
    {
        public Heater(int temperature) => Temperature = temperature;

        public int Temperature { get; private set; }

        /// <summary>
        /// Called when [temperature changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="info">The <see cref="TemperatureChangedEventArgs"/> instance containing the event data.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void OnTemperatureChanged(Object sender, TemperatureChangedEventArgs info)
        {
            if (info is null)
            {
                throw new ArgumentNullException();
            }
            Console.WriteLine(info.NewTemperature < Temperature
                ? $"Heater: On. Changed:{Math.Abs(info.NewTemperature - Temperature)}"
                : $"Heater: Off. Changed:{Math.Abs(info.NewTemperature - Temperature)}");
        }
    }

    /// <summary>
    /// Thermostat.
    /// </summary>
    public sealed class Thermostat
    {
        private int currentTemperature;
        private Random random = new Random(Environment.TickCount);

        public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged = delegate { };

        /// <summary>
        /// Initializes a new instance of the <see cref="Thermostat"/> class.
        /// </summary>
        public Thermostat()
        {
            currentTemperature = 5;
        }

        /// <summary>
        /// Gets the current temperature.
        /// </summary>
        /// <value>
        /// The current temperature.
        /// </value>
        public int CurrentTemperature
        {
            get => currentTemperature;
            private set
            {
                if (value != currentTemperature)
                {
                    currentTemperature = value;
                    OnTemperatureChanged(new TemperatureChangedEventArgs(currentTemperature));
                }
            }
        }

        /// <summary>
        /// Emulates the temperature change.
        /// </summary>
        public void EmulateTemperatureChange()
        {
            this.CurrentTemperature = random.Next(0, 100);
        }

        private void OnTemperatureChanged(TemperatureChangedEventArgs info)
        {
            var temp = TemperatureChanged;
            temp?.Invoke(this, info);
        }
    }
}
