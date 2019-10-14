using NUnit.Framework;
using _3_UniqueWords;
using System.Linq;
using System;

namespace _3_UniqueWordsTests
{
    public class IdentifierOfUniqueWordsTests
    {
        string separators = " ,./;:'\"!?";

        [TestCase("Word word a A AAAAA aaa b WORD", 
            ExpectedResult = new[] { "Word", "a", "AAAAA", "aaa", "b" })]
        [TestCase("Cat, DOG! cat/dog/cat",
            ExpectedResult = new[] { "Cat", "DOG" })]
        [TestCase("Bla-bla-bla!",
            ExpectedResult = new[] { "Bla-bla-bla" })]
        public string[] FindTest(string @string)
        {
            return IdentifierOfUniqueWords.Find(@string, separators).ToArray();
        }

        [Test]
        public void FindTest_Null_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => IdentifierOfUniqueWords.Find(null, separators));
            Assert.Throws<ArgumentNullException>(() => IdentifierOfUniqueWords.Find(null, null));
            Assert.Throws<ArgumentNullException>(() => IdentifierOfUniqueWords.Find("bla", null));
        }
    }
}