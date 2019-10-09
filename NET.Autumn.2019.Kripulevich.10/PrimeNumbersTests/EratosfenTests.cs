using NUnit.Framework;
using PrimeNumbers;
using System;

namespace PrimeNumbersTests
{
    public class EratosfenTests
    {
        [TestCase(2, new[] { 2 })]
        [TestCase(4, new[] { 2, 3 })]
        [TestCase(60, new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59 })]
        public void GetPrimeNumbers_MaxNumber(int maxNumber, params int[] numbers)
        {
            Assert.AreEqual(Eratosfen.GetPrimeNumbers(maxNumber).ToArray(), numbers);
        }

        [Test]
        public void GetPrimeNumbers_Zero_ArgumentExeption()
        {
            Assert.Throws<ArgumentException>(() => Eratosfen.GetPrimeNumbers(0));
        }
    }
}