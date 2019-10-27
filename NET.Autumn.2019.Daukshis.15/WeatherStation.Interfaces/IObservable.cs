namespace WeatherStation.Interfaces
{
    /// <summary>
    /// IObservable
    /// </summary>
    public interface IObservable
    {
        /// <summary>
        /// Registers the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        void Register(IObserver observer);

        /// <summary>
        /// Unregisters the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        void Unregister(IObserver observer);

        /// <summary>
        /// Notifies this instance.
        /// </summary>
        void Notify();
    }
}