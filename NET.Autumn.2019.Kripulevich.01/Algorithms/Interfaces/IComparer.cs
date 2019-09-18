using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    /// <summary>
    /// Comperer of two int.
    /// </summary>
    public interface IComparer
    {
        int Compare(int lhs, int rhs);
    }
}
