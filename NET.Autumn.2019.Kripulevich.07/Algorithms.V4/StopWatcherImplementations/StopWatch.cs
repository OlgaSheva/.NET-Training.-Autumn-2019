using Algorithms.V4.Interfaces;
using System.Diagnostics;

namespace Algorithms.V4.StopWatcherImplementations
{
    /// <summary>
    /// Stopwatch.
    /// </summary>
    /// <seealso cref="Algorithms.V4.Interfaces.IStopWatcher" />
    public class StopWatcher : IStopWatcher
    {
        private readonly Stopwatch stopWatch;
        public long TimeInMilliseconds => stopWatch.ElapsedMilliseconds;

        public StopWatcher()
        {
            stopWatch = new Stopwatch();
        }

        public void Start()
        {
            stopWatch.Start();
        }

        public void Stop()
        {
            stopWatch.Stop();
        }
    }
}
