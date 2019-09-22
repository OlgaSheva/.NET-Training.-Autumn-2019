using NUnit.Framework;
using Logic;
using System;

namespace Tests
{
    public class MathExtensionTests
    {
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
    }
}