using NUnit.Framework;
using Algorithms.Tests.Comparers;
using System;

namespace Algorithms.Tests
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        [Test]
        public void SortTheArray_NullArray_ArgumentNullExwption() =>
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.SortTheArray(null));
        
        [Test]
        public void SortTheArray_ArrayDefaultBubbleSort_SortedArray()
        {
            var array = new[] { 7, 5, 2, 3 };
            var expected = new[] { 2, 3, 5, 7 };

            ArrayExtension.SortTheArray(array);

            Assert.AreEqual(expected, array);
        }
                
        [Test]
        public void SortTheArray_ArrayBubbleSortWithDefaultComparerAndMultiplicityIndexer2()
        {
            var array = new[] { 7, 5, 2, 3 };
            var expected = new[] { 2, 5, 7, 3 };

            ArrayExtension.SortTheArray(array, new DefaultComparer(), new MultiplicityIndexer(array.Length, 2));

            Assert.AreEqual(expected, array);
        }

        [Test]
        public void SortTheArray_ArrayBubbleSortWithDefaultComparerAndhMultiplicityIndexer3()
        {
            var array = new[] { int.MaxValue, 5, 2, 3, -2, 0, 1027, int.MinValue };
            var expected = new[] { 3, 5, 2, 1027, -2, 0, int.MaxValue, int.MinValue };

            ArrayExtension.SortTheArray(array, new DefaultComparer(), new MultiplicityIndexer(array.Length, 3));

            Assert.AreEqual(expected, array);
        }

        [Test]
        public void SortTheArray_ArrayBubbleSortWithModuloComparerAndMultiplicityIndexer2()
        {
            var array = new[] { int.MaxValue, 5, 2, 3, -2, 0, 1027, int.MinValue, -256 };
            var expected = new[] { 2, 5, -2, 3, -256, 0, 1027, int.MinValue, int.MaxValue };

            ArrayExtension.SortTheArray(array, new ModuloComparer(), new MultiplicityIndexer(array.Length, 2));

            Assert.AreEqual(expected, array);
        }

        [TestCase(256, 16, ExpectedResult = "100")]
        [TestCase(256, 2, ExpectedResult = "100000000")]
        [TestCase(int.MaxValue, 3, ExpectedResult = "12112122212110202101")]
        [TestCase(-16, 16, ExpectedResult = "-10")]
        [TestCase(0, 16, ExpectedResult = "0")]
        public string Convertation_Int(int digit, int numberSystem) 
            => Convertation.ConvertationIntToAnother(digit, numberSystem);

        [TestCase("100", '1', ExpectedResult = 1)]
        [TestCase("7FFFFFFF", 'F', ExpectedResult = 7)]
        public int CountingTheNumberOfCharactersInTheStringTest(string number, char symbol)
            => CountingTheNumberOfCharactersInTheString.Counting(number, symbol);

        [Test]
        public void SortTheArray_ArrayBubbleSortWithConversionComparerAndDefaultIndexer()
        {
            var array = new[] { int.MaxValue, 7, 256, -10568952, int.MaxValue }; 
            var expected = new[] { 7, 256, -10568952, int.MaxValue, int.MaxValue };

            ArrayExtension.SortTheArray(
                array, new ConversionComparer(16, 'F'), new DefaultIndexer(array.Length));

            Assert.AreEqual(expected, array);
        }
    }
}
