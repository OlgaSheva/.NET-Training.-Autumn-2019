using System;
using System.Globalization;
using Task2_Book;

namespace Task3_BookExtension
{
    /// <summary>
    /// Book format extension class.
    /// </summary>
    /// <seealso cref="System.IFormatProvider" />
    /// <seealso cref="System.ICustomFormatter" />
    public class BookExtension : IFormatProvider, ICustomFormatter
    {
        private readonly IFormatProvider formatProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookExtension"/> class.
        /// </summary>
        public BookExtension() : this(CultureInfo.CurrentCulture)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookExtension"/> class.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        public BookExtension(IFormatProvider formatProvider)
        {
            this.formatProvider = formatProvider;
        }

        /// <summary>
        /// Converts the value of a specified object to an equivalent string representation using specified format and culture-specific formatting information.
        /// </summary>
        /// <param name="format">A format string containing formatting specifications.</param>
        /// <param name="arg">An object to format.</param>
        /// <param name="formatProvider">An object that supplies format information about the current instance.</param>
        /// <returns>
        /// The string representation of the value of <paramref name="arg">arg</paramref>, formatted as specified by <paramref name="format">format</paramref> and <paramref name="formatProvider">formatProvider</paramref>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// format
        /// or
        /// arg
        /// or
        /// formatProvider
        /// </exception>
        /// <exception cref="System.ArgumentException">arg</exception>
        /// <exception cref="System.FormatException">The '{format}' format string is not supported.</exception>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }
            if (arg == null)
            {
                throw new ArgumentNullException(nameof(arg));
            }
            if (!(arg is Book))
            {
                throw new ArgumentException(nameof(arg));
            }
            if (formatProvider == null)
            {
                throw new ArgumentNullException(nameof(formatProvider));
            }

            Book book = (Book)arg;
            switch (format)
            {
                case "J":
                    return $"{book.Author}, {book.Title}, {book.Year}, {book.PublishingHous}, {book.Edition}, " +
                        $"{book.Pages}, {book.Price.ToString("C", this.formatProvider)}";
                case "I":
                    return $"{book.Author}, {book.Title}, {book.Price.ToString("C", this.formatProvider)}";
                default:
                    throw new FormatException($"The '{format}' format string is not supported.");
            }
        }

        /// <summary>
        /// Returns an object that provides formatting services for the specified type.
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return.</param>
        /// <returns>
        /// An instance of the object specified by <paramref name="formatType">formatType</paramref>, if the <see cref="System.IFormatProvider"></see> implementation can supply that type of object; otherwise, null.
        /// </returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }
    }
}
