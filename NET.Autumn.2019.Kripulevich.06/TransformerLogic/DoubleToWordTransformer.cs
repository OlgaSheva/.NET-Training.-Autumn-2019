using System.Collections.Generic;
using System.Text;

namespace TransformerLogic
{
    /// <summary>
    /// Transformer of double number to words.
    /// </summary>
    /// <seealso cref="Logic.Transformer" />
    public class DoubleToWordTransformer : Transformer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleToWordTransformer"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        public DoubleToWordTransformer(IDictionary<char, string> dictionary) : base(dictionary)
        {
        }

        /// <summary>
        /// Transforms double number to words.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        /// Words representation of a number.
        /// </returns>
        public override string TransformToWords(double number)
        {
            switch (number)
            {
                case double.NegativeInfinity:
                    return Dictionary['n'];
                case double.PositiveInfinity:
                    return Dictionary['p'];
                case double.NaN:
                    return Dictionary['!'];
            }

            var result = new StringBuilder();

            var stringNumber = number.ToString().ToCharArray();

            for (int i = 0; i < stringNumber.Length; i++)
            {
                result.Append(Dictionary[stringNumber[i]] + " ");
            }

            return result.ToString().TrimEnd();
        }
    }
}
