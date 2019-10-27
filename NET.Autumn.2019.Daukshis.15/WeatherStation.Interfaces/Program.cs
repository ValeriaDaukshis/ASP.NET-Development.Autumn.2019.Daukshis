using System;

namespace WeatherStation.Interfaces
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
            WeatherInfo info = new WeatherInfo(25, 750, 65);
            WeatherData weatherData = new WeatherData(info);
            CurrentConditionsReport currentReport = new CurrentConditionsReport();
            StatisticReport report = new StatisticReport(info);
            
            weatherData.Register(currentReport);
            weatherData.Register(report);
            
            weatherData.EmulateWeatherChange();
            weatherData.EmulateWeatherChange();
            
            weatherData.Unregister(currentReport);
            weatherData.EmulateWeatherChange();
        }
    }
}