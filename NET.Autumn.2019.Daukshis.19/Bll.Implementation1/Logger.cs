using System;
using Bll.Contract;
using NLog;

namespace Bll.Implementation1
{
    public class Logger : IDocumentLogger
    {
        private static NLog.Logger _logger;
        
        public Logger()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }
        
        public void Error(Exception ex, string message)
        {
            _logger.Error(ex, message);
        }
    }
}