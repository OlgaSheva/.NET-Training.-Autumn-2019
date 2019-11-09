using NLog;

namespace Bll.Implementation.ServiceImplementation
{
    /// <summary>
    /// NLog logger adapter.
    /// </summary>
    /// <seealso cref="Task_1_BasicXML.Interfaces.ILogger" />
    public class NLogLogger : Contract.Services.ILogger
    {
        private Logger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="NLogLogger"/> class.
        /// </summary>
        public NLogLogger()
        {
            this.logger = NLog.LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error(string message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Info(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// Warns the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Warn(string message)
        {
            logger.Warn(message);
        }
    }
}
