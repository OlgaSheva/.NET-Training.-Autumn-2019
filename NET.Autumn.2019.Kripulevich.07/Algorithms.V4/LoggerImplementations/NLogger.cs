using NLog;
using ILogger = Algorithms.V4.Interfaces.ILogger;

namespace Algorithms.V4.LoggerImplementations
{
    class NLogger : ILogger
    {
        private readonly Logger logger;

        public NLogger()
        {
            //logger = new Logger();
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
