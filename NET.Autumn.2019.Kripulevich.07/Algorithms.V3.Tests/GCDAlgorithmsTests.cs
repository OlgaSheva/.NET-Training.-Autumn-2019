using NUnit.Framework;
using Algorithms.V3.GcdImplementations;
using System;
using Algorithms.V3.Interfaces;

namespace Algorithms.V3.Tests
{
    public class GCDAlgorithmsTests
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
            Decorator decorator = new Decorator(new EuclideanAlgorithm());
            return decorator.Calculate(val1, val2);
        }

        [TestCase(0, 1, 5, 10, ExpectedResult = 1)]
        [TestCase(null, 0, -10, 5, 10, 15, 20, ExpectedResult = 5)]
        public static int FindGcdByEuclidean_Params_GCD(params int[] numbers)
        {
            Decorator decorator = new Decorator(new EuclideanAlgorithm());
            return decorator.Calculate(numbers);
        }

        public static void FindGcdByStein_ZeroParams_ArgumentExeption(params long[] numbers)
        {
            Decorator decorator = new Decorator(new EuclideanAlgorithm());
            Assert.Throws<ArgumentException>(() => decorator.Calculate(0, 0, 0, 0, 0, 0, 0));
        }

        public static void FindGcdByEuclidian_IntMinValue_ArgumentExeption(params long[] numbers)
        {
            Decorator decorator = new Decorator(new EuclideanAlgorithm());
            Assert.Throws<ArgumentException>(() => decorator.Calculate(int.MaxValue, int.MinValue));
        }
    }
}