using Algorithms.V4.Interfaces;
using System;

namespace Algorithms.V4.GcdImplementations
{
    public class EuclideanAlgorithm : IAlgorithm
    {
        public int Calculate(int first, int second)
        {
            if (first == int.MinValue || second == int.MinValue)
            {
                throw new ArgumentException("Arguments can't be less than -2'147'483'647.");
            }

            var v1 = Math.Abs(first);
            var v2 = Math.Abs(second);

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

            while ((v1 != 0) && (v2 != 0))
            {
                if (v1 > v2)
                {
                    v1 -= v2;
                }
                else
                {
                    v2 -= v1;
                }
            }

            return (v1 > v2) ? v1 : v2;
        }
    }
}