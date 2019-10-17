using System;
using System.Diagnostics;

namespace Algorithms.V5
{
    public static class GCDAlgorithms
    {
        #region GreatestCommonDivisior

        public static int GreatestCommonDivisor(int first, int second)
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

        public static int GreatestCommonDivisor(int first, int second, out long elapsedTimeMilliSecs) =>
            CommonDivisor2ParamsWithTime(GreatestCommonDivisor, first, second, out elapsedTimeMilliSecs);

        public static int GreatestCommonDivisor(int first, int second, int third) =>
            CommonDivisor3Params(GreatestCommonDivisor, first, second, third);

        public static int GreatestCommonDivisor(int first, int second, int third, out long elapsedTimeMilliSecs) =>
            CommonDivisor3ParamsWithTime(GreatestCommonDivisor, first, second, third, out elapsedTimeMilliSecs);

        public static int GreatestCommonDivisor(params int[] arrayOfNumbers) =>
            CommonDivisorParams(GreatestCommonDivisor, arrayOfNumbers);

        public static int GreatestCommonDivisor(out long elapsedTimeMilliSecs, params int[] arrayOfNumbers) =>
            CommonDivisorParamsWithTime(out elapsedTimeMilliSecs, GreatestCommonDivisor, arrayOfNumbers);

        #endregion

        #region BinaryGreatestCommonDivisior

        public static int BinaryGreatestCommonDivisor(int first, int second)
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

            // If v2 is even.
            if ((v1 & 1) == 0)
            {
                return ((v2 & 1) == 0)
                    ? BinaryGreatestCommonDivisor(v1 >> 1, v2 >> 1) << 1       // If v2 is even GCD(v1, v2) = 2 * GCD(v1 / 2, v2 / 2)
                    : BinaryGreatestCommonDivisor(v1 >> 1, v2);                // If v2 isn't even GCD(v1, v2) = GCD(v1 / 2, v2)
            }
            // If v2 isn't even.
            else
            {
                return ((v2 & 1) == 0)
                    ? BinaryGreatestCommonDivisor(v1, v2 >> 1)                 // If v2 is even GCD(v1, v2) = 2 * GCD(v1, v2 / 2)
                    : BinaryGreatestCommonDivisor(v2, Math.Abs(v1 - v2));      // If v2 isn't even GCD(v1, v2) = GCD(v2, |v1 - v2|)
            }
        }

        public static int BinaryGreatestCommonDivisor(int first, int second, out long elapsedTimeMilliSecs) =>
            CommonDivisor2ParamsWithTime(BinaryGreatestCommonDivisor, first, second, out elapsedTimeMilliSecs);

        public static int BinaryGreatestCommonDivisor(int first, int second, int third) =>
            CommonDivisor3Params(BinaryGreatestCommonDivisor, first, second, third);

        public static int
            BinaryGreatestCommonDivisor(int first, int second, int third, out long elapsedTimeMilliSecs) =>
            CommonDivisor3ParamsWithTime(BinaryGreatestCommonDivisor, first, second, third, out elapsedTimeMilliSecs);

        public static int BinaryGreatestCommonDivisor(params int[] arrayOfNumbers) =>
            CommonDivisorParams(BinaryGreatestCommonDivisor, arrayOfNumbers);

        public static int BinaryGreatestCommonDivisor(out long elapsedTimeMilliSecs, params int[] arrayOfNumbers) =>
            CommonDivisorParamsWithTime(out elapsedTimeMilliSecs, BinaryGreatestCommonDivisor, arrayOfNumbers);

        #endregion

        #region Helper methods

        private static int CommonDivisor2ParamsWithTime(Func<int, int, int> gcd, int first, int second,
            out long elapsedTimeMilliSecs)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            int result = gcd(first, second);

            stopWatch.Stop();
            elapsedTimeMilliSecs = stopWatch.ElapsedMilliseconds;

            return result;
        }

        private static int CommonDivisor3Params(Func<int, int, int> gcd, int first, int second, int third) =>
            gcd(gcd(first, second), third);

        private static int CommonDivisor3ParamsWithTime(Func<int, int, int> gcd, int first, int second, int third,
            out long elapsedTimeMilliSecs)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            int result = CommonDivisor3Params(gcd, first, second, third);

            stopWatch.Stop();
            elapsedTimeMilliSecs = stopWatch.ElapsedMilliseconds;

            return result;
        }

        private static int CommonDivisorParams(Func<int, int, int> gcd, params int[] arrayOfNumbers)
        {
            bool flag = false;
            foreach (var item in arrayOfNumbers)
            {
                if (item != 0)
                {
                    flag = true;
                }
            }

            if (flag)
            {
                int result = arrayOfNumbers[0];
                for (int i = 1; i < arrayOfNumbers.Length; i++)
                {
                    result = gcd(result, arrayOfNumbers[i]);
                }
                return result;
            }
            else
            {
                throw new ArgumentException($"The {nameof(arrayOfNumbers)} cannot consist only from zeros.");
            }

        }

        private static int CommonDivisorParamsWithTime(out long elapsedTimeMilliSecs, Func<int, int, int> gcd,
            params int[] arrayOfNumbers)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            int result = CommonDivisorParams(gcd, arrayOfNumbers);

            stopWatch.Stop();
            elapsedTimeMilliSecs = stopWatch.ElapsedMilliseconds;

            return result;
        }

        #endregion
    }
}