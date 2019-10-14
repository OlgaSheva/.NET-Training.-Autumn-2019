using System;
using NUnit.Framework;
using _4_CountJosephFlavius;

namespace _4_CountJosephFlaviusTests
{
    public class CountJosephFlaviusTests
    {
        [TestCase(1, 1, ExpectedResult = 0)]
        [TestCase(2, 1, ExpectedResult = 0)]
        [TestCase(3, 1, ExpectedResult = 0)]
        [TestCase(3, 2, ExpectedResult = 2)]
        [TestCase(5, 3, ExpectedResult = 3)]
        public int WhoWillSurviveTest(int count, int step)
            => CountJosephFlavius.WhoWillSurvive(count, step);

        [Test]
        public void WhoWillSurvive_ArgumentExeption()
        {
            Assert.Throws<ArgumentException>(() => CountJosephFlavius.WhoWillSurvive(10, 0));
            Assert.Throws<ArgumentException>(() => CountJosephFlavius.WhoWillSurvive(-18, 4));
        }
    }
}