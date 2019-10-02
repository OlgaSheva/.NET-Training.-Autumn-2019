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
            var dl = new DoubleToLongExplorer();
            dl.D = number;

            long longNumber = dl.L;

            int bitsCount = sizeof(double) * 8;
            char[] result = new char[bitsCount];
            result[0] = (longNumber < 0) ? '1' : '0';

            for (int i = bitsCount - 2, j = 1; i >= 0; i--, j++)
            {
                result[j] = (longNumber & (1L << i)) != 0 ? '1' : '0'; 
            }

            return new string(result);
        }

        /// <summary>
        /// Number with floating point to long (System.Int64) converter.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongExplorer
        {
            [FieldOffset(0)] public double D;
            [FieldOffset(0)] public long L;
        }   
    }
}
