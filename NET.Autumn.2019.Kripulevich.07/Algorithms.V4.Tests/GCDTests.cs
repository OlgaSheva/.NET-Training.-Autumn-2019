using NUnit.Framework;
using Moq;
using Algorithms.V4.Interfaces;
using Algorithms.V4.GcdImplementations;
using System;
using Algorithms.V4.LoggerImplementations;
using Algorithms.V4.StopWatcherImplementations;

namespace Algorithms.V4.Tests
{
    public class GCDMoqTests
    {
        private ILogger _logger;
        private IStopWatcher _stopWatcher;
        private IAlgorithm _algorithm;

        [SetUp]
        public void Setup()
        {
            _logger = Mock.Of<ILogger>();
            _stopWatcher = Mock.Of<IStopWatcher>();
            _algorithm = Mock.Of<IAlgorithm>();
        }

        [Test]
        public void CalculateDecorator_With_Two_Parameters_And_StopWatcher_And_Logger()
        {
            var gcd = new GCD(_algorithm, _stopWatcher, _logger);

            gcd.Calculate(1, 3);

            Mock<IAlgorithm> mockAlgorithm = Mock.Get(_algorithm);
            mockAlgorithm.Verify(a => a.Calculate(It.IsAny<int>(), It.IsAny<int>()), Times.Once);

            Mock<ILogger> mockLogger = Mock.Get(_logger);
            mockLogger.Verify(l => l.Info(It.IsAny<string>()), Times.AtLeastOnce);

            Mock<IStopWatcher> mockStopWatcher = Mock.Get(_stopWatcher);
            mockStopWatcher.Verify(sw => sw.Start());
            mockStopWatcher.Verify(sw => sw.Stop());
        }

        [Test]
        public void CalculateDecorator_With_Three_Parameters()
        {
            var gcd = new GCD(_algorithm, _stopWatcher, _logger);

            gcd.Calculate(20, 15, 125);
            Mock<IAlgorithm> mockAlgorithm = Mock.Get(_algorithm);
            mockAlgorithm.Verify(a => a.Calculate(It.IsAny<int>(), It.IsAny<int>()), Times.AtLeastOnce);
        }

        [Test]
        public void CalculateDecorator_With_Params()
        {
            var gcd = new GCD(_algorithm, _stopWatcher, _logger);

            gcd.Calculate(20, 15, 125, 400, -10);
            Mock<IAlgorithm> mockAlgorithm = Mock.Get(_algorithm);
            mockAlgorithm.Verify(a => a.Calculate(It.IsAny<int>(), It.IsAny<int>()), Times.AtLeastOnce);
        }   
    }

    public class EuclideanTests
    {
        [TestCase(322328, 122120, ExpectedResult = 344)]
        [TestCase(1, 10, ExpectedResult = 1)]
        [TestCase(5, 10, ExpectedResult = 5)]
        [TestCase(24, 24, ExpectedResult = 24)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(5, 10, ExpectedResult = 5)]
        [TestCase(0, 10, ExpectedResult = 10)]
        [TestCase(5, 0, ExpectedResult = 5)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        [TestCase(-5, -10, ExpectedResult = 5)]
        [TestCase(int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        public static int FindGcdByEuclidean_TwoNumbers_GCD(int val1, int val2)
        {
            IAlgorithm algorithm = new EuclideanAlgorithm();
            return algorithm.Calculate(val1, val2);
        }

        [TestCase(0, 1, 5, 10, ExpectedResult = 1)]
        [TestCase(null, 0, -10, 5, 10, 15, 20, ExpectedResult = 5)]
        public static int FindGcdByEuclidean_Params_GCD(params int[] numbers)
        {
            var gcd = new GCD(new EuclideanAlgorithm(), new StopWatcher(), new Logger());
            return gcd.Calculate(numbers);
        }

        [Test]
        public static void FindGcdByStein_ZeroParams_ArgumentExeption()
        {
            var gcd = new GCD(new EuclideanAlgorithm(), new StopWatcher(), new Logger());
            Assert.Throws<ArgumentException>(() => gcd.Calculate(0, 0, 0, 0, 0, 0, 0));
        }

        [Test]
        public static void FindGcdByEuclidian_IntMinValue_ArgumentExeption()
        {
            var gcd = new GCD(new EuclideanAlgorithm(), new StopWatcher(), new Logger());
            Assert.Throws<ArgumentException>(() => gcd.Calculate(int.MaxValue, int.MinValue));
        }
    }
}