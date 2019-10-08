using Algorithms.V4.Interfaces;

namespace Algorithms.V4.LoggerImplementations
{
    /// <summary>
    /// Logger decorator.
    /// </summary>
    /// <seealso cref="Algorithms.V4.Interfaces.IAlgorithm" />
    public class LoggerDecorator : IAlgorithm
    {
        protected IAlgorithm algorithm;
        private readonly ILogger logger;

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
