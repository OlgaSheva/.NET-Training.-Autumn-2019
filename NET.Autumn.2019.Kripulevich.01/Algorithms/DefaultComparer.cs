using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    /// <summary>
    /// Default comporator.
    /// </summary>
    public class DefaultComparer : IComparer
    {
        public DefaultComparer() { }
        public int Compare(int lhs, int rhs) => lhs - rhs;
    }
}
