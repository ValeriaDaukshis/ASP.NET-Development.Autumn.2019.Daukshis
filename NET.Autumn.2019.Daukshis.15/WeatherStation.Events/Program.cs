

namespace WeatherStation.Events
{
    /// <summary>
    /// Program.
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
            StatisticReport statisticsReport = new StatisticReport(info);

            weatherData.WeatherChange += currentReport.Update;
            weatherData.WeatherChange += statisticsReport.Update;
            
            weatherData.EmulateWeatherChange();
            weatherData.EmulateWeatherChange();
        }
    }
}