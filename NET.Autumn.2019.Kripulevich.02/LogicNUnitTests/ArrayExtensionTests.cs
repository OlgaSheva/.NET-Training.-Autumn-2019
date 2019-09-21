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
            var array = GenerateRandomSortedArray(1000000, int.MaxValue);
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

        #region FilterArrayByKeyTests
        [TestCase(new[] { 2212332, 1405644, -1236674 }, 0, ExpectedResult = new[] { 1405644 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, 2, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7243, 10017 }, 7, ExpectedResult = new[] { -27, 173, 371132, 7556, 7243, 10017 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, 9, ExpectedResult = new int[0])]
        public int[] FilterArrayByKey_ArrayAndDigit_NewArray(int[] array, int digit)
            => ArrayExtension.FilterArrayByKey(array, digit);

        [Test]
        public void FilterArrayByKey_EmptyArray_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ArrayExtension.FilterArrayByKey(new int[0], 0));
        }

        [Test]
        public void FilterArrayByKey_NullArray_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.FilterArrayByKey(null, 0));
        }

        [Test]
        public void FilterArrayByKey_NegativKey_ArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ArrayExtension.FilterArrayByKey(new int[] { 1, 2 }, -1));
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
            int[] randomArray = new int[random.Next(0, 3000)];

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