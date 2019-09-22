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
            var v1 = (val1 > 0) ? val1 : -val1;
            var v2 = (val2 > 0) ? val2 : -val2;
            
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
            
            if ((v1 & 1) == 0)
            {                      // Если а — чётное, то…
                return ((v2 & 1) == 0)
                    ? this.GCD(v1 >> 1, v2 >> 1) << 1       // …если b — чётное, то НОД(a, b) = 2 * НОД(a / 2, b / 2)
                    : this.GCD(v1 >> 1, v2);                // …если b — нечётное, то НОД(a, b) = НОД(a / 2, b)
            }
            else
            {                                  // Если a — нечётное, то…
                return ((v2 & 1) == 0)
                    ? this.GCD(v1, v2 >> 1)                 // …если b — чётное, то НОД(a, b) = НОД(a, b / 2)
                    : this.GCD(v2, v1 > v2 ? v1 - v2 : v2 - v1); // …если b — нечётное, то НОД(a, b) = НОД(b, |a - b|)
            }
        }
    }
}
