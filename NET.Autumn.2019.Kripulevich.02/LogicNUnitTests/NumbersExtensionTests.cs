using NUnit.Framework;
using Logic;
using System;

namespace LogicNUnitTests
{
    class NumbersExtensionTests
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(2728, 655, 3, 8, ExpectedResult = 2680)]
        [TestCase(554216104, 15, 0, 31, ExpectedResult = 15)]
        [TestCase(-55465467, 345346, 0, 31, ExpectedResult = 345346)]
        [TestCase(554216104, 4460559, 11, 18, ExpectedResult = 554203816)]
        [TestCase(-1, 0, 31, 31, ExpectedResult = 2147483647)]
        [TestCase(-2147483648, 2147483647, 0, 30, ExpectedResult = -1)]
        [TestCase(-2223, 5440, 18, 23, ExpectedResult = -16517295)]
        [TestCase(2147481425, 5440, 18, 23, ExpectedResult = 2130966353)]
        public int InsertNumberIntoAnotherTest(int numberSource, int numberIn, int i, int j)
        {
            return NumbersExtension.InsertNumberIntoAnother(numberSource, numberIn, i, j);
        }

        [Test]
        public void InsertNumberIntoAnother_ILargerThanJ_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => NumbersExtension.InsertNumberIntoAnother(8, 15, 8, 3));
        }

        [Test]
        public void InsertNumberIntoAnother_IOrJLessThan0_ArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => NumbersExtension.InsertNumberIntoAnother(8, 15, -1, 3));
            Assert.Throws<ArgumentOutOfRangeException>(() => NumbersExtension.InsertNumberIntoAnother(8, 15, 32, 32));
            Assert.Throws<ArgumentOutOfRangeException>(() => NumbersExtension.InsertNumberIntoAnother(8, 15, 0, 32));
        }
    }
}
