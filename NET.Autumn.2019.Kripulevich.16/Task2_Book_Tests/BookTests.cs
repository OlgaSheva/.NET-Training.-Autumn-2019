using NUnit.Framework;
using System.Globalization;
using Task2_Book;

namespace Task2_Book_Tests
{
    public class BookTests
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
        public void Book_ToString_Format_A_CorrectStringReturned() =>
           Assert.AreEqual(
               "Author: Jon Skeet, title: C# in Depth, year: 2019, publishing house: Manning, edition: 4, pages: 900, price: 40.",
               book.ToString("A"));

        [Test]
        public void Book_ToString_Format_B_CorrectStringReturned() =>
            Assert.AreEqual(
                "Jon Skeet, C# in Depth, 2019, Manning.",
                book.ToString("B"));

        [Test]
        public void Book_ToString_Format_C_CorrectStringReturned() =>
            Assert.AreEqual(
                "Jon Skeet, C# in Depth, 2019.",
                book.ToString("C"));

        [Test]
        public void Book_ToString_Format_D_CorrectStringReturned() =>
            Assert.AreEqual(
                "Jon Skeet, C# in Depth.",
                book.ToString("D"));

        [Test]
        public void Book_ToString_Format_E_CorrectStringReturned() =>
            Assert.AreEqual(
                "C# in Depth, 2019, Manning.",
                book.ToString("E"));

        [Test]
        public void Book_ToString_Format_F_CorrectStringReturned() =>
            Assert.AreEqual(
                "C# in Depth, 2019.",
                book.ToString("F"));

        [Test]
        public void Book_ToString_Format_G_CorrectStringReturned() =>
            Assert.AreEqual(
                "Jon Skeet, C# in Depth, 2019, Manning, 4, 900, 40.",
                book.ToString("G"));

        [Test]
        public void Book_ToString_Null_Format_CorrectStringReturned() =>
            Assert.AreEqual(
                "Jon Skeet, C# in Depth, 2019, Manning, 4, 900, 40.",
                book.ToString());

        [Test]
        public void Book_ToString_G_Format_FormatProvider_CorrectStringReturned() =>
            Assert.AreEqual(
                "Jon Skeet, C# in Depth, 2019, Manning, 4, 900, 40.",
                book.ToString("G", new CultureInfo("ja-JP")));

        [Test]
        public void Book_ToString_Null_Format_DoesNotThrown() =>
            Assert.DoesNotThrow(() => book.ToString(null));
    }
}