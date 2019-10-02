using System.Collections.Generic;

namespace TransformerLogicTests
{
    /// <summary>
    /// Spanish dictionary.
    /// </summary>
    class SpanishDictionary
    {
        /// <summary>
        /// Creates the spanish dictionary.
        /// </summary>
        /// <returns>
        /// The dictionary.
        /// </returns>
        public IDictionary<char, string> Create()
        {
            IDictionary<char, string> dictionary = new Dictionary<char, string>();

            dictionary.Add('0', "cero");
            dictionary.Add('1', "uno");
            dictionary.Add('2', "dos");
            dictionary.Add('3', "tres");
            dictionary.Add('4', "cuatro");
            dictionary.Add('5', "cinco");
            dictionary.Add('6', "seis");
            dictionary.Add('7', "siete");
            dictionary.Add('8', "ocho");
            dictionary.Add('9', "nueve");
            dictionary.Add('-', "menos");
            dictionary.Add('+', "más");
            dictionary.Add('.', "punto");
            dictionary.Add('E', "E");
            dictionary.Add('n', "Infinito negativo");
            dictionary.Add('p', "Infinito positivo");
            dictionary.Add('!', "No un número");

            return dictionary;
        }
    }
}
