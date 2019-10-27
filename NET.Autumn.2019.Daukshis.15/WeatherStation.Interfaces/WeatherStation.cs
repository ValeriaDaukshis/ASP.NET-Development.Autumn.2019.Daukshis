using System;
using System.Collections.Generic;

namespace WeatherStation.Interfaces
{
    /// <summary>
    /// WeatherData
    /// </summary>
    /// <seealso cref="WeatherStation.Interfaces.IObservable" />
    public class WeatherData : IObservable
    {
        private WeatherInfo _weatherInfo;
        private List<IObserver> _observers;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherData"/> class.
        /// </summary>
        /// <param name="weatherInfo">The weather information.</param>
        public WeatherData(WeatherInfo weatherInfo)
        {
            this._weatherInfo = weatherInfo;
            _observers = new List<IObserver>();
        }

        /// <summary>
        /// Registers the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void Register(IObserver observer)
        {
            _observers.Add(observer);
        }

        /// <summary>
        /// Unregisters the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void Unregister(IObserver observer)
        {
            _observers.Remove(observer);
        }

        /// <summary>
        /// Notifies this instance.
        /// </summary>
        public void Notify()
        {
            foreach (var obj in _observers)
            {
                obj.Update(this, _weatherInfo);
            }
        }

        public WeatherInfo weatherInfo
        {
            get => _weatherInfo;
            private set
            {
                if (_weatherInfo != value)
                {
                    _weatherInfo = value;
                    Notify();
                }
            }
        }
        
        private Random random = new Random(Environment.TickCount);

        /// <summary>
        /// Emulates the weather change.
        /// </summary>
        public void EmulateWeatherChange()
        {
            int temperature = random.Next(-20, 50);
            int pressure = random.Next(500, 800);
            int humidity = random.Next(0, 110);
            this.weatherInfo = new WeatherInfo(temperature, pressure, humidity);
        }
    }

    /// <summary>
    /// WeatherInfo
    /// </summary>
    public class WeatherInfo
    {
        public int Temperature { get; private set; }

        public int Pressure { get; private set; }

        public int Humidity { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherInfo"/> class.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <param name="pressure">The pressure.</param>
        /// <param name="humidity">The humidity.</param>
        public WeatherInfo(int temperature, int pressure, int humidity)
        {
            Temperature = temperature;
            Pressure = pressure;
            Humidity = humidity;
        }
    }
}