using System.Collections.Generic;

namespace PseudoEnumerable.Tests.Comparers
{
    class LengthComparer<T> : IComparer<T>
    {
        public int Compare(T x, T y)
        {
            return (x as string).Length - (y as string).Length;
        }
    }
}
