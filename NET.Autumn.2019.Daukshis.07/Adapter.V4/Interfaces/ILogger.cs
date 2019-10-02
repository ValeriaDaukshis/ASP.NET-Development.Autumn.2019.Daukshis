namespace Algorithms.V4.Interfaces
{
    /// <summary>
    /// Log the code
    /// </summary>
    public interface ILogger
    {
        void Error(string message);
        void Debug(string message);
        void Info(string message);
    }
}