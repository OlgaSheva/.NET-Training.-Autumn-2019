using NUnit.Framework;
using Task4_DoubleExtension;

namespace Task4_DoubleExtension_Tests
{
    public class Tests
    {
        [TestCase(double.NaN, ExpectedResult = "Not a number")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "Negative infinity")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "Positive infinity")]
        [TestCase(0.0d, ExpectedResult = "zero")]
        [TestCase(-0.0d, ExpectedResult = "zero")]
        [TestCase(0.1d, ExpectedResult = "zero point one")]
        [TestCase(-23.809d, ExpectedResult = "minus two three point eight zero nine")]
        [TestCase(-0.123456789d, ExpectedResult = "minus zero point one two three four five six seven eight nine")]
        [TestCase(1.23333e308d, ExpectedResult = "one point two three three three three E plus three zero eight")]
        [TestCase(double.Epsilon, ExpectedResult = "four point nine four zero six five six four five eight four one two four seven E minus three two four")]
        [TestCase(double.MaxValue, ExpectedResult = "one point seven nine seven six nine three one three four eight six two three two E plus three zero eight")]
        [TestCase(double.MinValue, ExpectedResult = "minus one point seven nine seven six nine three one three four eight six two three two E plus three zero eight")]
        public string TransformToWords_EnglishDictionary_StringRepresentation(double number)
        {
            var result = string.Format(new WordRepresentationFormatter(), "{0:B}", number);
            return result;
        }

        [Test]
        public void GetFormat_Null_NullReturned() =>
            Assert.IsNull(new WordRepresentationFormatter().GetFormat(null));
    }
}