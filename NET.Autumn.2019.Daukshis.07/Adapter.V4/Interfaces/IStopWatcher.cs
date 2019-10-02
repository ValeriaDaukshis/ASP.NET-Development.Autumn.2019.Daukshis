namespace Algorithms.V4.Interfaces
{
    /// <summary>
    /// Introduce timeCounter methods
    /// </summary>
    public interface IStopWatcher
    {
        void Start();
        void Stop();
        long TimeInMilliseconds { get; }
    }
}