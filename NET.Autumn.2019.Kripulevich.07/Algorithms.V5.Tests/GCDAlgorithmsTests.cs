using NUnit.Framework;
using Algorithms.V5;
using System;

namespace GCDAlgorithmsTests
{
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
            return GCDAlgorithms.GreatestCommonDivisor(val1, val2);
        }

        [TestCase(0, 1, 5, 10, ExpectedResult = 1)]
        [TestCase(null, 0, -10, 5, 10, 15, 20, ExpectedResult = 5)]
        public static int FindGcdByEuclidean_Params_GCD(params int[] numbers)
        {
            return GCDAlgorithms.GreatestCommonDivisor(numbers);
        }

        [Test]
        public static void FindGcdByEuclidian_ZeroParams_ArgumentExeption()
        {
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.GreatestCommonDivisor(0, 0, 0, 0, 0, 0, 0));
        }

        [Test]
        public static void FindGcdByEuclidian_IntMinValue_ArgumentExeption()
        {
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.GreatestCommonDivisor(int.MaxValue, int.MinValue));
        }
    }

    public class SteinTests
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
        public static int FindGcdByStein_TwoNumbers_GCD(int val1, int val2)
        {
            return GCDAlgorithms.BinaryGreatestCommonDivisor(val1, val2);
        }

        [TestCase(0, 1, 5, 10, ExpectedResult = 1)]
        [TestCase(null, 0, -10, 5, 10, 15, 20, ExpectedResult = 5)]
        public static int FindGcdByStein_Params_GCD(params int[] numbers)
        {
            return GCDAlgorithms.BinaryGreatestCommonDivisor(numbers);
        }

        [Test]
        public static void FindGcdByStein_ZeroParams_ArgumentExeption()
        {
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.BinaryGreatestCommonDivisor(0, 0, 0, 0, 0, 0, 0));
        }

        [Test]
        public static void FindGcdByStein_IntMinValue_ArgumentExeption()
        {
            Assert.Throws<ArgumentException>(() => GCDAlgorithms.BinaryGreatestCommonDivisor(int.MaxValue, int.MinValue));
        }
    }
}