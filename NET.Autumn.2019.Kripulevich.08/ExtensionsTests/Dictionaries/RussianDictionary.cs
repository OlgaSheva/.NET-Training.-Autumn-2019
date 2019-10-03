using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionsTests.Dictionaries
{
    /// <summary>
    /// Russian dictionary.
    /// </summary>
    public class RussianDictionary
    {
        /// <summary>
        /// Creates the russian dictionary.
        /// </summary>
        /// <returns>
        /// The dictionary.
        /// </returns>
        public IDictionary<char, string> Create()
        {
            IDictionary<char, string> dictionary = new Dictionary<char, string>();

            dictionary.Add('0', "ноль");
            dictionary.Add('1', "один");
            dictionary.Add('2', "два");
            dictionary.Add('3', "три");
            dictionary.Add('4', "четыре");
            dictionary.Add('5', "пять");
            dictionary.Add('6', "шесть");
            dictionary.Add('7', "семь");
            dictionary.Add('8', "восемь");
            dictionary.Add('9', "девять");
            dictionary.Add('-', "минус");
            dictionary.Add('+', "плюс");
            dictionary.Add('.', "точка");
            dictionary.Add('E', "E");
            dictionary.Add('n', "Минус бесконечность");
            dictionary.Add('p', "Плюс бесконечность");
            dictionary.Add('!', "Не число");

            return dictionary;
        }
    }
}
