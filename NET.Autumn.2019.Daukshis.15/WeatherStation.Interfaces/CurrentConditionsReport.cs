using System;

namespace WeatherStation.Interfaces
{
    /// <summary>
    /// CurrentConditionsReport
    /// </summary>
    /// <seealso cref="WeatherStation.Interfaces.IObserver" />
    public class CurrentConditionsReport : IObserver
    {
        /// <summary>
        /// Updates the specified observable.
        /// </summary>
        /// <param name="observable">The observable.</param>
        /// <param name="weatherInfo">The weather information.</param>
        public void Update(IObservable observable, WeatherInfo weatherInfo)
        {
            Console.WriteLine($"Temperature : {weatherInfo.Temperature}");
            Console.WriteLine($"Pressure : {weatherInfo.Pressure}");
            Console.WriteLine($"Humidity : {weatherInfo.Humidity}");
        }
    }
}