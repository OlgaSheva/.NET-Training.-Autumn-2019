using NUnit.Framework;
using Extensions;
using ExtensionsTests.Predicates;
using System;

namespace ExtensionsTests
{
    public class ArrayExtensionTests
    {
        #region FilterByType

        [TestCase(new object[] { 7, '3', "cat", 5, 1.926396, -1, 2 }, ExpectedResult = new int[] { 7, 5, -1, 2 })]
        [TestCase(new object[] { '7', '3', "cat", 1.926396, -200000000000 }, ExpectedResult = new int[0])]
        public int[] FilterByType_EvenPredicate_NewArray(object[] array)
            => array.FilterByType<int>();

        public void FilterByType_Null_ArgumentNullException()
        {
            object[] array = null;
            Assert.Throws<ArgumentNullException>(() => array.FilterByType<int>());
        }

        public void FilterByType_EmptyArray_ArgumentException()
        {
            object[] array = new object[0];
            Assert.Throws<ArgumentException>(() => array.FilterByType<int>());
        }

        #endregion

        #region Filter

        [TestCase(new[] { 2212332, 1405644, -1236674 }, ExpectedResult = new[] { 2212332, 1405644, -1236674 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, ExpectedResult = new int[] { 2, 2 })]
        public int[] Filter_Array_EvenPredicate_NewArray(int[] array)
            => array.Filter<int>(new EvenPredicate<int>());

        [Test]
        public void Filter_EmptyArray_ArgumentException()
        {
            var array = new int[0];
            Assert.Throws<ArgumentException>(()
                => array.Filter(new EvenPredicate<int>()));
        }

        [Test]
        public void Filter_NullArray_ArgumentNullException()
        {
            string[] array = null;
            Assert.Throws<ArgumentNullException>(()
                => array.Filter(new EvenPredicate<string>()));
        }

        #endregion

        #region Max

        [TestCase(new[] { 0, 1, 4, 6, -3, 10, 256, 0 }, ExpectedResult = 256)]
        [TestCase(new[] { int.MaxValue, 1, 4, 6, int.MinValue, 10, 256, 0 }, ExpectedResult = int.MaxValue)]
        [TestCase(new[] { -18880, -17695841, -34, -6, -3, -10, -256, 0 }, ExpectedResult = 0)]
        public int Max_Array_MaxItem(int[] array) => array.Max<int>();

        [Test]
        public void Max_EmptyArray_ArgumentException()
        {
            var array = new int[] { };
            Assert.Throws<ArgumentException>(() => array.Max());
        }

        [Test]
        public void Max_Null_ArgumentNullException()
        {
            string[] array = null;
            Assert.Throws<ArgumentNullException>(() => array.Max<string>());
        }

        #endregion

    }
}