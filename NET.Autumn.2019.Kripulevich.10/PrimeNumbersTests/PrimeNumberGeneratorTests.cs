using NUnit.Framework;
using PrimeNumbers;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Collections;

namespace PrimeNumbersTests
{
    [TestFixture]
    public class PrimeNumberGeneratorTests
    {
        

        [TestFixture]
        public class MyTests
        {
            [TestCaseSource(typeof(DataClass), "TestCases")]
            public BigInteger[] DivideTest(int maxNumber)
            {
                return PrimeNumberGenerator.GetPrimeNumbers(maxNumber).ToArray();
            }
        }

        public class DataClass
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(0).Returns(new ArgumentException());
                    yield return new TestCaseData(2).Returns(new BigInteger[] { 2 });
                    yield return new TestCaseData(4).Returns(new BigInteger[] { 2, 3 });
                    yield return new TestCaseData(60).Returns(new BigInteger[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59 });
                }
            }
        }
    }
}