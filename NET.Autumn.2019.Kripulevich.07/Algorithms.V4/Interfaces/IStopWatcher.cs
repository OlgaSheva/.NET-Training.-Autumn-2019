namespace Algorithms.V4.Interfaces
{
    public interface IStopWatcher
    {
        void Start();
        void Stop();
        long TimeInMilliseconds { get; }
    }
}