using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicNETFramework;

namespace LogicNETFrameworkTests
{
    [TestClass]
    public class NumbersExtensionTests
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\TestData.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("..\\LogicMSTests\\TestData.xml")]
        [TestMethod]
        public void InsertNumberIntoAnotherTest_TestData_ExpectedNumber()
        {
            int numberSource = Convert.ToInt32(TestContext.DataRow["numberSource"]);
            int numberIn = Convert.ToInt32(TestContext.DataRow["numberIn"]);
            int i = Convert.ToInt32(TestContext.DataRow["i"]);
            int j = Convert.ToInt32(TestContext.DataRow["j"]);
            int expected = Convert.ToInt32(TestContext.DataRow["expectedNumber"]);

            var actual = NumbersExtension.InsertNumberIntoAnother(numberSource, numberIn, i, j);
            Assert.AreEqual(actual, expected);
        }
    }
}
