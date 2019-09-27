using NUnit.Framework;
using Logic;
using System;

namespace LogicNUnitTests
{
    public class ArrayExtensionTests
    {
        #region FindMaximumItemTests
        [TestCase(new[] { 0, 1, 4, 6, -3, 10, 256, 0 }, ExpectedResult = 256)]
        [TestCase(new[] { int.MaxValue, 1, 4, 6, int.MinValue, 10, 256, 0 }, ExpectedResult = int.MaxValue)]
        [TestCase(new[] { -18880, -17695841, -34, -6, -3, -10, -256, 0 }, ExpectedResult = 0)]
        public int FindMaximumItem_Array_MaxItem(int[] array) =>
            ArrayExtension.FindMaximumItem(array);

        [Test]
        public void FindMaximumItem_EmptyArray_ArgumentException()
        {
            var array = new int[] { };
            Assert.Throws<System.ArgumentException>(() => ArrayExtension.FindMaximumItem(array));
        }

        [Test]
        public void FindMaximumItem_Null_ArgumentNullException()
        {
            Assert.Throws<System.ArgumentNullException>(() => ArrayExtension.FindMaximumItem(null));
        }

        [Test]
        public void FindMaximumItem_RandomArray_MaxItem()
        {
            var array = GenerateRandomSortedArray(100000, int.MaxValue);
            int expected = array[array.Length - 1];

            var shuffleArray = (int[])array.Clone();
            Shuffle(shuffleArray);

            var actual = ArrayExtension.FindMaximumItem(shuffleArray);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region FindBalanceIndexTests
        [TestCase(new int[] { 0, 1, 0, 1, 0, 1, 0 }, ExpectedResult = 3)]
        [TestCase(new int[] { 10, 1, 0, 1, 8, 1, 0 }, ExpectedResult = 1)]
        [TestCase(new int[] { -10, -1, 0, -1, -8, -1, 0 }, ExpectedResult = 1)]
        [TestCase(new int[] { 100, 1, 0, 1, 0, 1, 0 }, ExpectedResult = null)]
        [TestCase(new int[] { 100, int.MaxValue, 0, 1, 0, int.MinValue, 0 }, ExpectedResult = null)]
        [TestCase(new int[] { int.MaxValue, int.MinValue, int.MaxValue, 0, 1, 0, int.MaxValue, int.MinValue, int.MaxValue }, ExpectedResult = 4)]
        public int? FindBalanceIndex_Array_IndexInArrayForWhichTheSumOfLeftAndRightElementsIsEqual(int[] array)
            => ArrayExtension.FindBalanceIndex(array);

        [Test]
        public void FindBalanceIndex_NullArray_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.FindBalanceIndex(null));
        }

        [Test]
        public void FindBalanceIndex_EmptyArray_ArgumentNullException()
        {
            Assert.Throws<ArgumentException>(() => ArrayExtension.FindBalanceIndex(new int[] { }));
        }
        #endregion

        #region FilterArray
        [TestCase(new[] { 2212332, 1405644, -1236674 }, ExpectedResult = new[] { 1405644 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, ExpectedResult = new[] { 1001, 1005 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, ExpectedResult = new int[0])]
        public int[] FilterArray_Array_TheDigitInTheNumberPredicate_NewArray(int[] array)
            => ArrayExtension.FilterArray(array, new TheDigitInTheNumberPredicate(0));

        [TestCase(new[] { 2212332, 1405644, -1236674 }, ExpectedResult = new[] { 2212332, 1405644, -1236674 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, ExpectedResult = new int[] { 2, 2 })]
        public int[] FilterArray_Array_EvenPredicate_NewArray(int[] array)
            => ArrayExtension.FilterArray(array, new EvenPredicate());

        [TestCase(new[] { int.MinValue, 123321, -1236674 }, ExpectedResult = new[] { 123321 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, ExpectedResult = new int[] { 1001 })]
        [TestCase(new[] { 4321234, 2, 5, int.MaxValue, -1, 11, 2 }, ExpectedResult = new int[] { 4321234, 11 })]
        public int[] FilterArray_Array_PalindromePredicate_NewArray(int[] array)
            => ArrayExtension.FilterArray(array, new PalindromePredicate());

        [Test]
        public void FilterArray_EmptyArray_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() 
                => ArrayExtension.FilterArray(new int[0], new TheDigitInTheNumberPredicate(0)));
        }

        [Test]
        public void FilterArray_NullArray_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() 
                => ArrayExtension.FilterArray(null, new EvenPredicate()));
        }

        [Test]
        public void FilterArray_NegativKey_ArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() 
                => ArrayExtension.FilterArray(new int[] { 1, 2 }, new TheDigitInTheNumberPredicate(-1)));
        }
        #endregion

        #region Private metods
        /// <summary>
        /// Generate random sorted array.
        /// </summary>
        /// <param name="min">Lower end of range.</param>
        /// <param name="max">Upper range limit.</param>
        /// <returns>Random array.</returns>
        private static int[] GenerateRandomSortedArray(int min, int max)
        {
            Random random = new Random();
            int[] randomArray = new int[random.Next(0, 100000000)];

            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = random.Next(min, max);
            }

            Array.Sort(randomArray);
            return randomArray;
        }

        /// <summary>
        /// Array mixer.
        /// </summary>
        /// <param name="array">Array.</param>
        private static void Shuffle(int[] array)
        {
            Random random = new Random();

            for (int i = array.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                int tmp = array[j];
                array[j] = array[i];
                array[i] = tmp;
            }
        }
        #endregion
    }
}