using NUnit.Framework;
using Algorithms.V3.StaticClasses;
using System;

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
            => GCDAlgorithms.FindGcdByEuclidean(val1, val2);
        
        [TestCase(0, 1, 5, 10, ExpectedResult = 1)]
        [TestCase(null, 0, -10, 5, 10, 15, 20, ExpectedResult = 5)]
        public static int FindGcdByEuclidean_Params_GCD(params int[] numbers)
            => GCDAlgorithms.FindGcdByEuclidean(numbers);

        public static void FindGcdByStein_ZeroParams_ArgumentExeption(params long[] numbers)
        {
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.FindGcdByEuclidean(0, 0, 0, 0, 0, 0, 0));
        }

        public static void FindGcdByEuclidian_IntMinValue_ArgumentExeption(params long[] numbers)
        {
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.FindGcdByEuclidean(int.MaxValue, int.MinValue));
        }
    }
}