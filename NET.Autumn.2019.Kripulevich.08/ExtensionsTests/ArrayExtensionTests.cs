using NUnit.Framework;
using Extensions;
using ExtensionsTests.Predicates;
using System;
using ExtensionsTests.Dictionaries;
using Extensions.Decorators;

namespace ExtensionsTests
{
    public class ArrayExtensionTests
    {
        #region Transform

        [TestCase(new double[] { double.NaN }, ExpectedResult = new string[] { "Not a number" })]
        [TestCase(new double[] { double.NegativeInfinity, double.PositiveInfinity }, ExpectedResult = new string[] { "Negative infinity", "Positive infinity" })]
        [TestCase(new double[] { 0.0d, -0.0d, 0.1d }, ExpectedResult = new string[] { "zero", "zero", "zero point one" })]
        [TestCase(new double[] { double.MaxValue, double.MinValue }, ExpectedResult = new string[] { "one point seven nine seven six nine three one three four eight six two three two E plus three zero eight", "minus one point seven nine seven six nine three one three four eight six two three two E plus three zero eight" })]
        public string[] Transform_EnglishDictionary_StringRepresentation(double[] numbers)
        {
            var dictionary = new EnglishDictionary().Create();
            var words = new Words(dictionary);
            return numbers.Transform(new WordsDecorator<double, string>(words, dictionary));
        }

        [TestCase(new double[] { -255.255 }, ExpectedResult = new string[] { "1100000001101111111010000010100011110101110000101000111101011100" })]
        [TestCase(new double[] { double.NegativeInfinity, double.PositiveInfinity }, ExpectedResult = new string[] { "1111111111110000000000000000000000000000000000000000000000000000", "0111111111110000000000000000000000000000000000000000000000000000" })]
        [TestCase(new double[] { 0.0d, -0.0d }, ExpectedResult = new string[] { "0000000000000000000000000000000000000000000000000000000000000000", "1000000000000000000000000000000000000000000000000000000000000000" })]
        public string[] Transform_IEEE754_StringRepresentation(double[] numbers)
        {
            return numbers.Transform(new IEEE754Decorator<double, string>());
        }

        #endregion

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