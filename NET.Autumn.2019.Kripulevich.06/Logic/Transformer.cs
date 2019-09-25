using System;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Transformer of double number to string representation.
    /// </summary>
    public class Transformer
    {
        /// <summary>
        /// Transforms double number to words.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>The string representation of the number.</returns>
        public string TransformToWords(double number)
        {
            if (number == double.NegativeInfinity)
            {
                return "Negative infinity";
            }

            if (number == double.PositiveInfinity)
            {
                return "Positive infinity";
            }

            if (number == (int)number)
            {
                return Convert.ToString((Symbols)((int)number));
            }

            try
            {
                return this.DoubleToString(number);
            }
            catch
            {
                return "Not a number";
            }
        }

        /// <summary>
        /// Doubles to string.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>The string representation of the number.</returns>
        private string DoubleToString(double number)
        {
            var symbols = number.ToString().ToCharArray();
            var result = new StringBuilder();
            int charIndex;

            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i] == '-')
                {
                    charIndex = 10;
                }
                else if (symbols[i] == '+')
                {
                    charIndex = 11;
                }
                else if (symbols[i] == '.')
                {
                    charIndex = 12;
                }
                else if (symbols[i] == 'E')
                {
                    charIndex = 13;
                }                
                else
                {
                    charIndex = int.Parse(symbols[i].ToString());
                }

                result.Append(Convert.ToString((Symbols)charIndex) + " ");
            }

            return result.ToString().TrimEnd();
        }
    }
}
