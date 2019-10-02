using Algorithms.V4.Interfaces;

namespace Algorithms.V4.StopWatcherImplementations
{
    public class TimeDecorator : IAlgorithm
    {
        protected IAlgorithm algorithm;
        private IStopWatcher stopWatch;

        public long TimeInMilliseconds { get; private set; }

        public TimeDecorator(IAlgorithm algorithm, IStopWatcher stopWatch)
        {
            this.algorithm = algorithm;
            this.stopWatch = stopWatch;
        }
        
        public int Calculate(int first, int second)
        {
            stopWatch.Start();

            int gcd = algorithm.Calculate(first, second);

            stopWatch.Stop();
            TimeInMilliseconds = stopWatch.TimeInMilliseconds;

            return gcd;
        }
    }
}
