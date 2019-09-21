using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Logic;

namespace LogicMSTests
{
    class ArrayExtensionTests
    {
        [DataTestMethod]
        [DataRow(new[] { 2212332, 1405644, -1236674 }, 0, new[] { 1405644 })]
        [DataRow(new[] { 53, 71, -24, 1001, 32, 1005 }, 2, new[] { -24, 32 })]
        [DataRow(new[] { -27, 173, 371132, 7556, 7243, 10017 }, 7, new[] { -27, 173, 371132, 7556, 7243, 10017 })]
        [DataRow(new[] { 7, 2, 5, 5, -1, -1, 2 }, 9, new int[0])]
        public int[] FilterArrayByKey_ArrayAndDigit_NewArray(int[] array, int digit, int[] expected)
            => ArrayExtension.FilterArrayByKey(array, digit);

        [TestMethod]
        public void FilterArrayByKey_EmptyArray_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => ArrayExtension.FilterArrayByKey(new int[0], 0));
        }

        [TestMethod]
        public void FilterArrayByKey_NullArray_ArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => ArrayExtension.FilterArrayByKey(null, 0));
        }

        [TestMethod]
        public void FilterArrayByKey_NegativKey_ArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ArrayExtension.FilterArrayByKey(new int[] { 1, 2 }, -1));
        }
    }
}
