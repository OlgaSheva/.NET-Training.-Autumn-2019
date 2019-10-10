using System;
using NUnit.Framework;
using CorrectParentheses;

namespace CorrectParenthesesTests
{
    public class ParenthesesTests
    {
        [TestCase("sdf(sdg{sdg}sdg)[]", ExpectedResult = true)]
        [TestCase("((({{)()}}}[][](({]", ExpectedResult = false)]
        [TestCase("{([])}{()[()]}", ExpectedResult = true)]
        public bool Correct(string @string)
        {
            return Parentheses.Correct(@string);
        }

        [Test]
        public void Correct_Null_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Parentheses.Correct(null));
        }
    }
}