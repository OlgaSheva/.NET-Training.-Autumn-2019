using System;

namespace BinarySearchTreeTests
{
    public class Book : IComparable, IComparable<Book>
    {
        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public int? Year { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="author">The author.</param>
        /// <param name="title">The title.</param>
        /// <param name="year">The year.</param>
        public Book(string author, string title, int year)
        {
            Author = author;
            Title = title;
            Year = year;
        }

        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public int CompareTo(Book other)
        {
            if (other is null)
            {
                return 1;
            }

            return Title != null ? Title.CompareTo(other.Title) : other.Title == null ? 0 : -1;
        }

        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Object type of {nameof(other)} is not a {nameof(Book)}.</exception>
        public int CompareTo(object other)
        {
            if (other is null)
            {
                return 1;
            }

            if (!(other is Book))
            {
                throw new ArgumentException($"Object type of {nameof(other)} is not a {nameof(Book)}.");
            }

            return CompareTo((Book)other);
        }
    }
}
