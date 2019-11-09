namespace Task_1_BasicXML.Interfaces
{
    /// <summary>
    /// Logger interface.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Info(string message);

        /// <summary>
        /// Warns the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Warn(string message);

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Error(string message);
    }
}
