using System;
using System.Collections.Generic;
using NUnit.Framework;
using PseudoEnumerable.Interfaces;
using PseudoEnumerable.Tests.Comparers;

namespace PseudoEnumerable.Tests
{
    public class EnumerableExtensionTests
    {
        #region Filter

        private IPredicate<int> evenPredicate =  new EvenPredicate<int>();
        private IPredicate<string> lengthPredicate = new LengthPredicate<string>();

        [TestCase(new[] { 2212332, 1405644, -1236674 }, ExpectedResult = new[] { 2212332, 1405644, -1236674 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, ExpectedResult = new int[] { 2, 2 })]
        public IEnumerable<int> Filter_EvenPredicate_NewArray(IEnumerable<int> array)
            => EnumerableExtension.Filter(array, evenPredicate);

        [TestCase(new[] { "as", "aaaaaaa", "qe23214wrtw" }, new[] { "aaaaaaa", "qe23214wrtw" })]
        [TestCase(new[] { "111111111111111", "", null }, new[] { "111111111111111" })]
        public void Filter_LengthPredicate_NewArray(IEnumerable<string> array, IEnumerable<string> expected)
            => Assert.AreEqual(EnumerableExtension.Filter(array, lengthPredicate), expected);

        [TestCase(new[] { 2212332, 1405644, -1236674 }, ExpectedResult = new[] { 2212332, 1405644, -1236674 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, ExpectedResult = new int[] { 2, 2 })]
        public IEnumerable<int> FilterDelegate_EvenPredicate_NewArray(IEnumerable<int> array)
            => EnumerableExtension.Filter(array, x => x % 2 == 0);

        [TestCase(new[] { "as", "aaaaaaa", "qe23214wrtw" }, new[] { "aaaaaaa", "qe23214wrtw" })]
        [TestCase(new[] { "111111111111111", "", "1111" }, new[] { "111111111111111" })]
        public void FilterDelegate_LengthPredicate_NewArray(IEnumerable<string> array, IEnumerable<string> expected)
            => Assert.AreEqual(EnumerableExtension.Filter(array, x => x.Length > 5), expected);

        #endregion

        #region Transform

        [TestCase(new[] { "1" }, new[] { 1 })]
        [TestCase(new[] { "1", "2", "3" }, new[] { 1, 2, 3 })]
        [TestCase(new[] { "11111", "0" }, new[] { 11111, 0 })]
        public void TransformDelegate_IntParse_NewArray(IEnumerable<string> array, IEnumerable<int> expected)
            => Assert.AreEqual(EnumerableExtension.Transform(array, x => int.Parse(x)), expected);

        [TestCase(new[] { 1.108304, 19.09795 }, new[] { 1, 19 })]
        [TestCase(new[] { -24564.08065, 0 }, new[] { -24564, 0 })]
        public void TransformDelegate_DoubleToInt_NewArray(IEnumerable<double> array, IEnumerable<int> expected)
            => Assert.AreEqual(EnumerableExtension.Transform(array, x => (int)x), expected);

        #endregion

        #region Order

        private IComparer<string> lengthComparer = new LengthComparer<string>();
        private Comparison<string> lengthComparerDelegate = new LengthComparer<string>().Compare;

        [TestCase(new[] { "as", "aaaaaaa", "qe23214wrtw" }, new[] { "as", "aaaaaaa", "qe23214wrtw" })]
        [TestCase(new[] { "111111111111111", "" }, new[] { "", "111111111111111" })]
        public void Order_LengthComparer_NewArray(IEnumerable<string> array, IEnumerable<string> expected)
            => Assert.AreEqual(EnumerableExtension.OrderAccordingTo(array, lengthComparer), expected);

        [TestCase(new[] { "as", "aaaaaaa", "qe23214wrtw" }, new[] { "as", "aaaaaaa", "qe23214wrtw" })]
        [TestCase(new[] { "111111111111111", "" }, new[] { "", "111111111111111" })]
        public void OrderDelegate_LengthComparer_NewArray(IEnumerable<string> array, IEnumerable<string> expected)
            => Assert.AreEqual(EnumerableExtension.OrderAccordingTo(array, lengthComparerDelegate), expected);

        #endregion
    }
}
