namespace Algorithms.V4.Interfaces
{
    public interface ILogger
    {
        void Error(string message);
        void Debug(string message);
        void Info(string message);
    }
}