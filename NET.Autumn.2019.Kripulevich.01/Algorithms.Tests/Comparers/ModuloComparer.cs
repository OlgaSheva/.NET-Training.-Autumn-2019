using System;

namespace Algorithms.Tests
{
    /// <summary>
    /// Comparer by number modulo.
    /// </summary>
    public class ModuloComparer : IComparer
    {
        public int Compare(int lhs, int rhs)
        {
            return Math.Abs(lhs) - Math.Abs(rhs);
        }
    }
}
