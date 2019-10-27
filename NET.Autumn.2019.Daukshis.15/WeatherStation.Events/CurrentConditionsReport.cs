using System;

namespace WeatherStation.Events
{
    /// <summary>
    /// CurrentConditionsReport.
    /// </summary>
    public class CurrentConditionsReport
    {
        /// <summary>
        /// Updates the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="info">The <see cref="WeatherChangeEventArgs"/> instance containing the event data.</param>
        public void Update(object sender, WeatherChangeEventArgs info)
        {
            Console.WriteLine($"Temperature : {info.WeatherInfo.Temperature}");
            Console.WriteLine($"Pressure : {info.WeatherInfo.Pressure}");
            Console.WriteLine($"Humidity : {info.WeatherInfo.Humidity}");
        }
    }

    /// <summary>
    /// StatisticReport.
    /// </summary>
    public class StatisticReport
    {
        private WeatherInfo WeatherInfo { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticReport"/> class.
        /// </summary>
        /// <param name="weatherInfo">The weather information.</param>
        public StatisticReport(WeatherInfo weatherInfo)
        {
            CheckData(weatherInfo);
            this.WeatherInfo = weatherInfo;
        }

        /// <summary>
        /// Updates the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="info">The <see cref="WeatherChangeEventArgs"/> instance containing the event data.</param>
        public void Update(object sender, WeatherChangeEventArgs info)
        {
            Console.WriteLine($"Temperature changed: {this.WeatherInfo.Temperature - info.WeatherInfo.Temperature}");
            Console.WriteLine($"Pressure changed: {this.WeatherInfo.Pressure - info.WeatherInfo.Pressure}");
            Console.WriteLine($"Humidity changed: {this.WeatherInfo.Humidity - info.WeatherInfo.Humidity}");
        }
        
        private void CheckData(WeatherInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException($"{nameof(info)} is null reference.");
            }
        }
    }

    /// <summary>
    /// WeatherChangeEventArgs
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class WeatherChangeEventArgs : EventArgs
    {
        public WeatherInfo WeatherInfo { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherChangeEventArgs"/> class.
        /// </summary>
        /// <param name="weatherInfo">The weather information.</param>
        public WeatherChangeEventArgs(WeatherInfo weatherInfo)
        {
            CheckData(weatherInfo);
            this.WeatherInfo = weatherInfo;
        }
        
        private void CheckData(WeatherInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException($"{nameof(info)} is null reference.");
            }
        }
    }

    /// <summary>
    /// WeatherData
    /// </summary>
    public class WeatherData
    {
        private WeatherInfo _weatherInfo;
        public EventHandler<WeatherChangeEventArgs> WeatherChange;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherData"/> class.
        /// </summary>
        /// <param name="weatherInfo">The weather information.</param>
        public WeatherData(WeatherInfo weatherInfo)
        {
            CheckData(weatherInfo);
            this._weatherInfo = weatherInfo;
            WeatherChange = delegate { };
        }

        public WeatherInfo weatherInfo
        {
            get => _weatherInfo;
            private set
            {
                _weatherInfo = value;
                OnWeatherChanged(new WeatherChangeEventArgs(_weatherInfo));
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

        private void OnWeatherChanged(WeatherChangeEventArgs info)
        {
            var temp = WeatherChange;
            temp?.Invoke(this, info);
        }

        private void CheckData(WeatherInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException($"{nameof(info)} is null reference.");
            }
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