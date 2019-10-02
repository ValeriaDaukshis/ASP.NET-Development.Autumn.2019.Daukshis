using Algorithms.V4.Interfaces;

namespace Algorithms.V4.LoggerImplementation
{
    public class Logger : ILogger
    {
        private static NLog.Logger _logger;

        public Logger()
        {
            _logger = NLog.LogManager.GetCurrentClassLogger();
        }
        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }
    }
}