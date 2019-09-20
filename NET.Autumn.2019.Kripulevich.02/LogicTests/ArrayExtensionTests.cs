using NUnit.Framework;
using Logic;
using System;

namespace LogicTests
{
    public class ArrayExtensionTests
    {
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
    }
}