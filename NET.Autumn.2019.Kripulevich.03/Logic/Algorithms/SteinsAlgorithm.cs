using System;

namespace Logic
{
    /// <summary>
    /// Stein's algorithm of calculation of the GCD of several numbers.
    /// </summary>
    /// <seealso cref="Logic.Algorithm" />
    public class SteinsAlgorithm : Algorithm
    {
        /// <summary>
        /// Calculate the GCD of several numbers.
        /// </summary>
        /// <param name="val1">The val1.</param>
        /// <param name="val2">The val2.</param>
        /// <returns>
        /// Returns GCD of two numbers.
        /// </returns>
        public override long GCD(long val1, long val2)
        {
            var v1 = Math.Abs(val1);
            var v2 = Math.Abs(val2);
            
            if (v1 == 0)
            {
                return v2;
            }
            
            if (v2 == 0 || v1 == v2)
            {
                return v1;
            } 
              
            if (v1 == 1 || v2 == 1)
            {
                return 1;
            }         
            
            // If v2 is even.
            if ((v1 & 1) == 0)
            {                      
                return ((v2 & 1) == 0)
                    ? this.GCD(v1 >> 1, v2 >> 1) << 1       // If v2 is even GCD(v1, v2) = 2 * GCD(v1 / 2, v2 / 2)
                    : this.GCD(v1 >> 1, v2);                // If v2 isn't even GCD(v1, v2) = GCD(v1 / 2, v2)
            }
            // If v2 isn't even.
            else
            { 
                return ((v2 & 1) == 0)
                    ? this.GCD(v1, v2 >> 1)                 // If v2 is even GCD(v1, v2) = 2 * GCD(v1, v2 / 2)
                    : this.GCD(v2, Math.Abs(v1 - v2));      // If v2 isn't even GCD(v1, v2) = GCD(v2, |v1 - v2|)
            }
        }
    }
}
