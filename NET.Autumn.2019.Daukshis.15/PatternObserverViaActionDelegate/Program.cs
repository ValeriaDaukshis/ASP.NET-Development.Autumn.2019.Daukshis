using System;

namespace PatternObserverViaActionDelegate
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
            thermostat.observers += heater.OnTemperatureChanged; 
            thermostat.observers += cooler.Update; 

            thermostat.EmulateTemperatureChange();
            thermostat.EmulateTemperatureChange();

            //thermostat.observers = null; // !!!!!!!!!
            
            thermostat.EmulateTemperatureChange();
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
        /// Updates the specified new temperature.
        /// </summary>
        /// <param name="newTemperature">The new temperature.</param>
        public void Update(int newTemperature)
        {
            Console.WriteLine(newTemperature > Temperature
                ? $"Cooler: On. Changed:{Math.Abs(newTemperature - Temperature)}"
                : $"Cooler: Off. Changed:{Math.Abs(newTemperature - Temperature)}");
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
        /// <param name="newTemperature">The new temperature.</param>
        public void OnTemperatureChanged(int newTemperature)
        {
            Console.WriteLine(newTemperature < Temperature
                ? $"Heater: On. Changed:{Math.Abs(newTemperature - Temperature)}"
                : $"Heater: Off. Changed:{Math.Abs(newTemperature - Temperature)}");
        }
    }

    /// <summary>
    /// Thermostat.
    /// </summary>
    public sealed class Thermostat
    {
        public Action<int> observers;
        
        private int currentTemperature;

        private Random random = new Random(Environment.TickCount);

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
                    observers?.Invoke(currentTemperature);
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
    }
}