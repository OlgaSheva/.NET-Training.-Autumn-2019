using NUnit.Framework;
using FibonacciGenerator;
using System;
using System.Collections.Generic;

namespace FibonacciGeneratorTests
{
    public class FibonacciTests
    {
        [Test]
        public void Generate_Zero_ArgumentExeption()
        {
            Assert.Throws<ArgumentException>(() => Fibonacci.Generate(0));
        }

        [TestCase(1, new int[] { 0 })]
        [TestCase(2, new int[] { 0, 1 })]
        [TestCase(3, new int[] { 0, 1, 1 })]
        [TestCase(4, new int[] { 0, 1, 1, 2 })]
        [TestCase(5, new int[] { 0, 1, 1, 2, 3 })]
        [TestCase(6, new int[] { 0, 1, 1, 2, 3, 5 })]
        [TestCase(7, new int[] { 0, 1, 1, 2, 3, 5, 8 })]
        [TestCase(8, new int[] { 0, 1, 1, 2, 3, 5, 8, 13 })]
        [TestCase(9, new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21 })]
        [TestCase(10, new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 })]
        [TestCase(11, new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 })]
        [TestCase(12, new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 })]
        public void Generate_Number_IEnumerableFibonacci(int number, IEnumerable<int> expected)
        {
            Assert.AreEqual(Fibonacci.Generate(number), expected);
        }
    }
}