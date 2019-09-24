using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Logic;

namespace LogicMSTests
{
    class ArrayExtensionTests
    {
        [DataTestMethod]
        [DataRow(new[] { 2212332, 1405644, -1236674 }, new[] { 1405644 })]
        [DataRow(new[] { 53, 71, -24, 1001, 32, 1005 }, new[] { 1001, 1005 })]
        [DataRow(new[] { 7, 2, 5, 5, -1, -1, 2 }, new int[0])]
        public int[] FilterArrayByKey_ArrayAndDigit_NewArray(int[] array, int[] expected)
            => ArrayExtension.FilterArray(array, new TheDigitInTheNumberPredicate(0));

        [TestMethod]
        public void FilterArray_EmptyArray_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => ArrayExtension.FilterArray(new int[0], new PalindromePredicate()));
        }

        [TestMethod]
        public void FilterArray_NullArray_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => ArrayExtension.FilterArray(null, new EvenPredicate()));
        }

        [TestMethod]
        public void FilterArrayByKey_NegativKey_ArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayExtension.FilterArray(new int[] { 1, 2 }, new TheDigitInTheNumberPredicate(-1)));
        }
    }
}
