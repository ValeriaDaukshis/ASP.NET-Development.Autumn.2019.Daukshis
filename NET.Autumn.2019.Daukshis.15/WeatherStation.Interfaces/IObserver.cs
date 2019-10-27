namespace WeatherStation.Interfaces
{
    /// <summary>
    /// IObserver
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// Updates the specified observable.
        /// </summary>
        /// <param name="observable">The observable.</param>
        /// <param name="weatherInfo">The weather information.</param>
        void Update(IObservable observable, WeatherInfo weatherInfo);
    }
}