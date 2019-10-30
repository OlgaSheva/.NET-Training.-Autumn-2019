using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TransformerLogicTests;

namespace Task4_DoubleExtension
{
    /// <summary>
    /// Transformer of double number to word representation.
    /// </summary>
    /// <seealso cref="System.ICustomFormatter" />
    /// <seealso cref="System.IFormatProvider" />
    public class WordRepresentationFormatter : ICustomFormatter, IFormatProvider
    {
        private readonly IFormatProvider formatProvider;
        protected readonly IDictionary<char, string> dictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordRepresentationFormatter"/> class.
        /// </summary>
        public WordRepresentationFormatter() : this(CultureInfo.CurrentCulture, new EnglishDictionary().Create())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordRepresentationFormatter"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        public WordRepresentationFormatter(IDictionary<char, string> dictionary) 
            : this(CultureInfo.CurrentCulture, dictionary)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordRepresentationFormatter"/> class.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="dictionary">The dictionary.</param>
        public WordRepresentationFormatter(IFormatProvider formatProvider, IDictionary<char, string> dictionary)
        {
            this.formatProvider = formatProvider;
            this.dictionary = dictionary;
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
            if (formatProvider == null)
            {
                throw new ArgumentNullException(nameof(formatProvider));
            }

            return DoubleToWordsRepresentation((double)arg);
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

            return null;
        }

        private string DoubleToWordsRepresentation(double number)
        {
            switch (number)
            {
                case double.NegativeInfinity:
                    return dictionary['n'];
                case double.PositiveInfinity:
                    return dictionary['p'];
                case double.NaN:
                    return dictionary['!'];
            }

            var result = new StringBuilder();
            var stringNumber = number.ToString().ToCharArray();
            for (int i = 0; i < stringNumber.Length; i++)
            {
                result.Append(dictionary[stringNumber[i]] + " ");
            }

            return result.ToString().TrimEnd();
        }
    }
}