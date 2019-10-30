using NUnit.Framework;
using System.Globalization;
using Task2_Book;
using Task3_BookExtension;

namespace Tests
{
    public class Tests
    {
        private readonly Book book = new Book
        {
            Title = "C# in Depth",
            Author = "Jon Skeet",
            Year = 2019,
            PublishingHous = "Manning",
            Edition = 4,
            Pages = 900,
            Price = 40,
        };

        [Test]
        public void Book_ToString_ExtensionFormat_Ru_CorrectStringReturned() =>
           Assert.AreEqual(
               "Jon Skeet, C# in Depth, 40,00ð.",
               string.Format(new BookExtension(), "{0:I}", book));

        [Test]
        public void Book_ToString_ExtensionFormat_Us_CorrectStringReturned() =>
           Assert.AreEqual(
               "Jon Skeet, C# in Depth, $40.00",
               string.Format(new BookExtension(CultureInfo.GetCultureInfo("en-Us")), "{0:I}", book));
    }
}