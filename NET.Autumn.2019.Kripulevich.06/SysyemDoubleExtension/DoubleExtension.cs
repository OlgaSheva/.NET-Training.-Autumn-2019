using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SystemDoubleExtension
{
    /// <summary>
    /// Class for getting a string representation of a double number in IEEE 754 format.
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Binaries the representation.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public static string IEEE754Format(this double number)
        {
            var dl = new DoublingLongExplorer();
            dl.D = number;

            long bits = dl.L;

            bool negative = (bits < 0);
            int exponent = (int)((bits >> 52) & 0x7ffL);
            long mantissa = bits & 0xfffffffffffffL;

            string s = ((negative) ? 1 : 0).ToString();
            s += GetExponent(exponent);
            s += GetMantissa(mantissa);

            return s;
        }

        /// <summary>
        /// Number with floating point to long (System.Int64) converter.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct DoublingLongExplorer
        {
            [FieldOffset(0)] public Double D;
            [FieldOffset(0)] public long L;
        } 
        
        private static string GetExponent(long number)
        {
            LinkedList<long> list = GetBits(number);

            while (list.Count < 11)
            {
                list.AddFirst(0);
            }
            
            string s = null;
            foreach (var item in list)
            {
                s += item.ToString();
            }

            return s;
        }

        private static string GetMantissa(long number)
        {
            LinkedList<long> list = GetBits(number);

            while (list.Count < 52)
            {
                list.AddFirst(0);
            }

            string s = null;
            foreach (var item in list)
            {
                s += item.ToString();
            }

            return s;
        }

        private static LinkedList<long> GetBits(long number)
        {
            var list = new LinkedList<long>();
            number = Math.Abs(number);
            while (number > 1)
            {
                list.AddFirst(number % 2);
                number /= 2;
            }
            if (number == 1)
            {
                list.AddFirst(number);
            }

            return list;
        }
    }
}
