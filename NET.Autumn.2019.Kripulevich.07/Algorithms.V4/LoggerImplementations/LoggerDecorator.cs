using Algorithms.V4.Interfaces;

namespace Algorithms.V4.LoggerImplementations
{
    class LoggerDecorator : IAlgorithm
    {
        protected IAlgorithm algorithm;
        private ILogger logger;

        public LoggerDecorator(IAlgorithm algorithm, ILogger logger)
        {
            this.algorithm = algorithm;
            this.logger = logger;
        }

        public int Calculate(int first, int second)
        {
            return algorithm.Calculate(first, second);
        }
    }
}
