namespace Algorithms.Tests.Comparers
{
    /// <summary>
    /// Convertation by count char symbol.
    /// </summary>
    /// <seealso cref="Algorithms.IComparer" />
    class ConversionComparer : IComparer
    {
        public char CharSymbol {get;}
        public int NumberSystem { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConversionComparer"/> class.
        /// </summary>
        /// <param name="numberSystem">The number system.</param>
        /// <param name="symbol">The symbol.</param>
        public ConversionComparer(int numberSystem, char symbol)
        {
            CharSymbol = symbol;
            NumberSystem = numberSystem;
        }

        /// <summary>
        /// Compares lhs and rhs.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        public int Compare(int lhs, int rhs)
        {
            int lhsCount = CountingTheNumberOfCharactersInTheString.Counting(
                Convertation.ConvertationIntToAnother(lhs, NumberSystem), CharSymbol);
            int rhsCount = CountingTheNumberOfCharactersInTheString.Counting(
                Convertation.ConvertationIntToAnother(rhs, NumberSystem), CharSymbol);

            return lhsCount - rhsCount;
        }        
    }
}
