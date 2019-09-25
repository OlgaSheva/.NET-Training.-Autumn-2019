using NUnit.Framework;
using Logic;
using System;

namespace Tests
{
    public class MathExtensionTests
    {
        #region FindNthRoot
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRoot_AllParameteres_NthRoot(double number, int rootDegree, double accuracy, double expected)
        {
            var actual = MathExtension.FindNthRoot(number, rootDegree, accuracy);
            Assert.AreEqual(expected, actual, accuracy);
        }
        
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
            => MathExtension.FindGcd(new EuclideanAlgorithm(),val1, val2);

        [TestCase(0, 1, 5, 10, ExpectedResult = 1)]
        [TestCase(null, 0, -10, 5, 10, 15, 20, ExpectedResult = 5)]
        public static long FindGcdByEuclidean_Params_GCD(params long[] numbers)
            => MathExtension.FindGcd(new EuclideanAlgorithm(), numbers);

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
            => MathExtension.FindGcd(new SteinsAlgorithm(), val1, val2);

        [TestCase(0, 1, 5, 10, ExpectedResult = 1)]
        [TestCase(null, 0, -10, 5, 10, 15, 20, ExpectedResult = 5)]
        public static long FindGcdByStein_Params_GCD(params long[] numbers)
            => MathExtension.FindGcd(new SteinsAlgorithm(), numbers);
        #endregion
    }
}