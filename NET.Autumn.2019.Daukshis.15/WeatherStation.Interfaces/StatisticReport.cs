using System;

namespace WeatherStation.Interfaces
{
    /// <summary>
    /// StatisticReport
    /// </summary>
    /// <seealso cref="WeatherStation.Interfaces.IObserver" />
    public class StatisticReport : IObserver
    {
        public WeatherInfo WeatherInfo { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticReport"/> class.
        /// </summary>
        /// <param name="weatherInfo">The weather information.</param>
        public StatisticReport(WeatherInfo weatherInfo)
        {
            this.WeatherInfo = weatherInfo;
        }

        /// <summary>
        /// Updates the specified observable.
        /// </summary>
        /// <param name="observable">The observable.</param>
        /// <param name="weatherInfo">The weather information.</param>
        public void Update(IObservable observable, WeatherInfo weatherInfo)
        {
            Console.WriteLine($"Temperature changed: {this.WeatherInfo.Temperature - weatherInfo.Temperature}");
            Console.WriteLine($"Pressure changed: {this.WeatherInfo.Pressure - weatherInfo.Pressure}");
            Console.WriteLine($"Humidity changed: {this.WeatherInfo.Humidity - weatherInfo.Humidity}");
        }
    }
}