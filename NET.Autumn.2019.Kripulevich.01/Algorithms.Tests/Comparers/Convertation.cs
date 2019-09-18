using System.Collections.Generic;

namespace Algorithms.Tests.Comparers
{
    /// <summary>
    /// Universal conversion of a decimal number to another number system.
    /// </summary>
    public static class Convertation
    {
        /// <summary>
        /// The alfaphet of different number system.
        /// </summary>
        static char[] model = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        /// <summary>
        /// Convertations the int to another number system.
        /// </summary>
        /// <param name="digit">The digit.</param>
        /// <param name="numberSystem">The number system.</param>
        /// <returns>String format of the number.</returns>
        public static string ConvertationIntToAnother(int digit, int numberSystem)
        {
            var number = new List<char>();
            int div;
            int modDigit = digit;

            if (digit < 0)
            {
                modDigit = -digit;
            }

            while (modDigit >= numberSystem)
            {
                div = modDigit % numberSystem;
                number.Add(model[div]);
                modDigit /= numberSystem;
            }
            number.Add(model[modDigit]);
            if (digit < 0) number.Add('-');
            number.Reverse();
            
            return new string(number.ToArray());
        }
    }
}
