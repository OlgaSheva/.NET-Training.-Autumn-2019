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
        [TestCase(double.PositiveInfinity, 2, -1)]
        [TestCase(double.NegativeInfinity, 2, -1)]
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
        [TestCase(int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]        
        [TestCase(int.MaxValue, int.MinValue, ExpectedResult = 1)]
        [TestCase(long.MaxValue, long.MaxValue, ExpectedResult = long.MaxValue)]
        [TestCase(long.MaxValue, long.MinValue + 1, ExpectedResult = long.MaxValue)]
        public static long FindGcdByEuclidean_TwoNumbers_GCD(long val1, long val2) 
            => MathExtension.FindGcdByEuclid(val1, val2);

        
        [TestCase(-5, -10, ExpectedResult = 5)]
        public static long FindGcdByEuclideanWithTimer_TwoNumbers_GCD(long val1, long val2)
            => MathExtension.FindGcdByEuclid(out double time, val1, val2);

        [TestCase(-5, -10, ExpectedResult = 5)]
        public static long FindGcdBySteinsWithTimer_TwoNumbers_GCD(long val1, long val2)
            => MathExtension.FindGcdByStein(out double time, val1, val2);

        [TestCase(0, 1, 5, 10, ExpectedResult = 1)]
        [TestCase(null, 0, -10, 5, 10, 15, 20, ExpectedResult = 5)]
        public static long FindGcdByEuclidean_Params_GCD(params long[] numbers)
            => MathExtension.FindGcdByEuclid(numbers);

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

        public static void FindGcdByStein_ZeroParams_ArgumentExeption(params long[] numbers)
        {
            Assert.Throws<ArgumentException>(() => MathExtension.FindGcdByStein(0, 0, 0, 0, 0, 0, 0));
        }

        public static void FindGcdByStein_LongMinValue_ArgumentExeption(params long[] numbers)
        {
            Assert.Throws<ArgumentException>(() 
                => MathExtension.FindGcdByStein(long.MinValue, long.MaxValue));
        }

        #endregion
    }
}