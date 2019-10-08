using NUnit.Framework;
using FibonacciGenerator;
using System;
using System.Numerics;
using System.Collections;
using System.Linq;

namespace FibonacciGeneratorTests
{
    public class FibonacciTests
    {
        [Test]
        public void Generate_Zero_ArgumentExeption()
        {
            Assert.Throws<ArgumentException>(() => Fibonacci.Generate(-1));
        }

        [TestFixture]
        public class MyTests
        {
            [TestCaseSource(typeof(DataClass), "TestCases")]
            public BigInteger[] DivideTest(int count)
            {
                return Fibonacci.Generate(count).ToArray();
            }
        }

        public class DataClass
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(0).Returns(new BigInteger[] { });
                    yield return new TestCaseData(1).Returns(new BigInteger[] { 0 });
                    yield return new TestCaseData(2).Returns(new BigInteger[] { 0, 1 });
                    yield return new TestCaseData(3).Returns(new BigInteger[] { 0, 1, 1 });
                    yield return new TestCaseData(12).Returns(
                        new BigInteger[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 });
                    yield return new TestCaseData(30).Returns(
                        new BigInteger[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144,
                            233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657,
                            46368, 75025, 121393, 196418, 317811, 514229 });
                    yield return new TestCaseData(60).Returns(
                        new BigInteger[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233,
                            377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368,
                            75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309,
                            3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986,
                            102334155, 165580141, 267914296, 433494437, 701408733, 1134903170,
                            1836311903, 2971215073, 4807526976, 7778742049, 12586269025,
                            20365011074, 32951280099, 53316291173, 86267571272, 139583862445,
                            225851433717, 365435296162, 591286729879, 956722026041 });
                }
            }
        }
    }
}