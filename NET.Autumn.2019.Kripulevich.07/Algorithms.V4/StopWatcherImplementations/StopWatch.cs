using Algorithms.V4.Interfaces;
using System.Diagnostics;

namespace Algorithms.V4.StopWatcherImplementations
{
    class StopWatcher : IStopWatcher
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
