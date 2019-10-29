using System;
using System.Globalization;

namespace Task2_Book
{
    /// <summary>
    /// The book.
    /// </summary>
    public class Book : IFormattable
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the publishing hous.
        /// </summary>
        /// <value>
        /// The publishing hous.
        /// </value>
        public string PublishingHous { get; set; }

        /// <summary>
        /// Gets or sets the edition.
        /// </summary>
        /// <value>
        /// The edition.
        /// </value>
        public int Edition { get; set; }

        /// <summary>
        /// Gets or sets the pages.
        /// </summary>
        /// <value>
        /// The pages.
        /// </value>
        public int Pages { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="FormatException">The '{format}' format string is not supported.</exception>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format))
            {
                format = "G";
            }

            format = format.Trim().ToUpperInvariant();
            if (formatProvider == null)
            {
                formatProvider = NumberFormatInfo.CurrentInfo;
            }

            switch (format)
            {
                case "A":
                    return $"Author: {this.Author}, title: {this.Title}, year: {Year}, " +
                        $"publishing house: {PublishingHous}, edition: {Edition}, pages: {Pages}, price: {Price}.";
                case "B":
                    return $"{this.Author}, {this.Title}, {Year}, {PublishingHous}.";
                case "C":
                    return $"{this.Author}, {this.Title}, {Year}.";
                case "D":
                    return $"{this.Author}, {this.Title}.";
                case "E":
                    return $"{this.Title}, {this.Year}, {this.PublishingHous}.";
                case "F":
                    return $"{this.Title}, {this.Year}.";
                case "G":
                    return $"{this.Author}, {this.Title}, {Year}, {PublishingHous}, {Edition}, {Pages}, {Price}.";
                default:
                    throw new FormatException($"The '{format}' format string is not supported.");
            }
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.ToString("G", null);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString(string format)
        {
            return this.ToString(format, null);
        }
    }
}
