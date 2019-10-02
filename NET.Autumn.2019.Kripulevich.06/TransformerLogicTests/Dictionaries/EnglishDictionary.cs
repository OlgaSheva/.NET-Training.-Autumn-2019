using System.Collections.Generic;

namespace TransformerLogicTests
{
    /// <summary>
    /// English dictionary.
    /// </summary>
    public class EnglishDictionary
    {
        /// <summary>
        /// Creates the english dictionary.
        /// </summary>
        /// <returns>
        /// The dictionary.
        /// </returns>
        public IDictionary<char, string> Create()
        {
            IDictionary<char, string> dictionary = new Dictionary<char, string>();

            dictionary.Add('0', "zero");
            dictionary.Add('1', "one");
            dictionary.Add('2', "two");
            dictionary.Add('3', "three");
            dictionary.Add('4', "four");
            dictionary.Add('5', "five");
            dictionary.Add('6', "six");
            dictionary.Add('7', "seven");
            dictionary.Add('8', "eight");
            dictionary.Add('9', "nine");
            dictionary.Add('-', "minus");
            dictionary.Add('+', "plus");
            dictionary.Add('.', "point");
            dictionary.Add('E', "E");
            dictionary.Add('n', "Negative infinity");
            dictionary.Add('p', "Positive infinity");
            dictionary.Add('!', "Not a number");

            return dictionary;
        }        
    }
}
