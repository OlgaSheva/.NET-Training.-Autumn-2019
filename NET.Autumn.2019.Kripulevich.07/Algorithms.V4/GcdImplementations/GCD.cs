using Algorithms.V4.Interfaces;
using System;

namespace Algorithms.V4.GcdImplementations
{
    public class GCD : AlgorithmDecorator
    {
        private readonly IStopWatcher _stopWatcher;
        private readonly ILogger _logger;

        /// <summary>
        /// Gets the milliseconds.
        /// </summary>
        /// <value>
        /// The milliseconds.
        /// </value>
        public long Milliseconds { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GCD"/> class.
        /// </summary>
        /// <param name="algorithm">The algorithm.</param>
        /// <param name="stopWatcher">The stop watcher.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Throws if stopWatcher or logger is null.
        /// </exception>
        public GCD(IAlgorithm algorithm, IStopWatcher stopWatcher, ILogger logger) : base(algorithm)
        {
            _stopWatcher = stopWatcher ?? throw new ArgumentNullException($"{nameof(stopWatcher)} can't be null.");
            _logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} can't be null.");

            Milliseconds = 0;
        }

        /// <summary>
        /// Calculates GCD of two numbers.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>
        /// The GCD of two numbers.
        /// </returns>
        public override int Calculate(int first, int second)
        {
            _stopWatcher.Start();
            int result = Algorithm.Calculate(first, second);
            _stopWatcher.Stop();

            Milliseconds = _stopWatcher.TimeInMilliseconds;

            _logger.Info($"Runtime of a method with two variables: {Milliseconds}");
            _logger.Info($"Result solution: {result.ToString()}");

            return result;
        }

        /// <summary>
        /// Calculates GCD of three numbers.
        /// </summary>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <param name="third">The third number.</param>
        /// <returns>
        /// The GCD of three numbers.
        /// </returns>
        public override int Calculate(int first, int second, int third)
        {
            if (first == 0 && second == 0 && third == 0)
            {
                throw new ArgumentException("All parameters can't be zero.");
            }

            _stopWatcher.Start();
            int result = Algorithm.Calculate(Algorithm.Calculate(first, second), third);
            _stopWatcher.Stop();

            Milliseconds = _stopWatcher.TimeInMilliseconds;

            _logger.Info($"Runtime of a method with three variables: {Milliseconds}");
            _logger.Info($"Result solution: {result.ToString()}");

            return result;
        }

        /// <summary>
        /// Calculates GCD of several numbers.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns>
        /// The GCD of several numbers.
        /// </returns>
        /// <exception cref="System.ArgumentException">You need at least two numbers.</exception>
        public override int Calculate(params int[] numbers)
        {
            bool flag = true;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i]  != 0)
                {
                    flag = false;
                }
            }

            if (flag)
            {
                _logger.Error($"All parameters are zero.");
                throw new ArgumentException("All parameters can't be zero.");
            }

            if (numbers.Length < 2)
            {
                _logger.Error($"Not enough items to calculate GCD.");
                throw new ArgumentException("You need at least two numbers.");
            }

            _stopWatcher.Start();
            int result = Algorithm.Calculate(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                result = Algorithm.Calculate(result, numbers[i]);
            }

            _stopWatcher.Stop();

            Milliseconds = _stopWatcher.TimeInMilliseconds;

            _logger.Info($"Runtime of a method with {numbers.Length.ToString()} variables: {Milliseconds.ToString()}");
            _logger.Info($"Result solution: {result.ToString()}");

            return result;
        }
    }
}
