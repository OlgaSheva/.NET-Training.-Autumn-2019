using NUnit.Framework;
using Logic;
using System;

namespace Tests
{
    public class MathExtensionTests
    {
        #region FindNthRoot
        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double FindNthRoot_AllParameteres_NthRoot(double number, int rootDegree, double accuracy)
                => MathExtension.FindNthRoot(number, rootDegree, accuracy);

        [Test]
        [TestCase(-0.01, 2, 0.0001)]
        [TestCase(0.01, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]
        public void FindNthRoot_NegativeParameters_ArgumentException(double number, int rootDegree, double accuracy)
        {
            Assert.Throws<ArgumentException>(() => MathExtension.FindNthRoot(number, rootDegree, accuracy));
        }
        #endregion

        #region FindGcd
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
        public static long FindGcdByEuclidean_TwoNumbers_GCD(long val1, long val2) 
            => MathExtension.FindGcdByEuclidean(val1, val2);

        [TestCase(0, 1, 5, 10, ExpectedResult = 1)]
        [TestCase(null, 0, -10, 5, 10, 15, 20, ExpectedResult = 5)]
        public static long FindGcdByEuclidean_Params_GCD(params long[] numbers)
            => MathExtension.FindGcdByEuclidean(numbers);

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
        public static long FindGcdByStein_TwoNumbers_GCD(long val1, long val2)
            => MathExtension.FindGcdByStein(val1, val2);

        [TestCase(0, 1, 5, 10, ExpectedResult = 1)]
        [TestCase(null, 0, -10, 5, 10, 15, 20, ExpectedResult = 5)]
        public static long FindGcdByStein_Params_GCD(params long[] numbers)
            => MathExtension.FindGcdByStein(numbers);
        #endregion
    }
}