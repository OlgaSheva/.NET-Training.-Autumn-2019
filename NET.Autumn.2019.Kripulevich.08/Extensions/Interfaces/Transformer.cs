using System;
using System.Collections.Generic;

namespace Extensions
{
    /// <summary>
    /// Transformer of double number to string representation.
    /// </summary>
    public abstract class Transformer
    {
        /// <summary>
        /// The dictionary.
        /// </summary>
        protected readonly IDictionary<char, string> Dictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="Transformer"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        public Transformer(IDictionary<char, string> dictionary)
        {
            Dictionary = dictionary 
                ?? throw new ArgumentNullException($"{nameof(dictionary)} can't be null.");
        }

        /// <summary>
        /// Transforms to words.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>String representation of a number.</returns>
        public virtual string TransformToWords(double number)
        {
            return number.ToString();
        }
    }
}
