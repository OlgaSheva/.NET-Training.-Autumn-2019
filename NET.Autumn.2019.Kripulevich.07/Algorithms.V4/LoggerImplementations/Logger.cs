using ILogger = Algorithms.V4.Interfaces.ILogger;
using NLog;

namespace Algorithms.V4.LoggerImplementations
{
    /// <summary>
    /// NLog Logger.
    /// </summary>
    /// <seealso cref="Algorithms.V4.Interfaces.ILogger" />
    public class Logger : ILogger
    {
        private readonly NLog.Logger logger;

        public Logger()
        {
            logger = LogManager.GetCurrentClassLogger();
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }
    }
}
