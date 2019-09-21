using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Logic;
using System.Data;

namespace LogicMSTests
{
    [TestClass]
    public class NumbersExtensionTests
    {
        [DataTestMethod]
        [DataRow(15, 15, 0, 0, 15)]
        [DataRow(8, 15, 0, 0, 9)]
        [DataRow(8, 15, 3, 8, 120)]
        [DataRow(2728, 655, 3, 8, 2680)]
        [DataRow(554216104, 15, 0, 31, 15)]
        [DataRow(-55465467, 345346, 0, 31, 345346)]
        [DataRow(554216104, 4460559, 11, 18, 554203816)]
        [DataRow(-1, 0, 31, 31, 2147483647)]
        [DataRow(-2147483648, 2147483647, 0, 30, -1)]
        [DataRow(-2223, 5440, 18, 23, -16517295)]
        [DataRow(2147481425, 5440, 18, 23, 2130966353)]
        public int InsertNumberIntoAnotherTest(int numberSource, int numberIn, int i, int j, int expected)
        {
            return NumbersExtension.InsertNumberIntoAnother(numberSource, numberIn, i, j);
        }

        [TestMethod]
        public void InsertNumberIntoAnother_ILargerThanJ_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => NumbersExtension.InsertNumberIntoAnother(8, 15, 8, 3));
        }

        [TestMethod]
        public void InsertNumberIntoAnother_IOrJLessThan0_ArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => NumbersExtension.InsertNumberIntoAnother(8, 15, -1, 3));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => NumbersExtension.InsertNumberIntoAnother(8, 15, 32, 32));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => NumbersExtension.InsertNumberIntoAnother(8, 15, 0, 32));
        }
    }
}
