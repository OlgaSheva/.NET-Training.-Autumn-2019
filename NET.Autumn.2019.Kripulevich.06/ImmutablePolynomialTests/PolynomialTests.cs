using NUnit.Framework;
using ImmutablePolynomial;

namespace ImmutablePolynomialTests
{
    public class PolynomialTests
    {
        [TestCase(new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, ExpectedResult = true)]
        [TestCase(new double[] { 0.00000001, 0.1, 0.000000000005}, new double[] { 0, 0.1, 0.00000001 }, ExpectedResult = true)]
        [TestCase(new double[] { double.MaxValue, double.MinValue }, new double[] { double.MaxValue, double.MinValue }, ExpectedResult = true)]
        public bool Equals_TwoPolynomials_TrueOrFalse(double[] lhs, double[] rhs)
        {
            Polynomial lp = new Polynomial(lhs);
            Polynomial rp = new Polynomial(rhs);
            return lp.Equals(rp);
        }

        [TestCase(new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3 }, ExpectedResult = false)]
        [TestCase(new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, ExpectedResult = true)]
        [TestCase(new double[] { 0.00000001, 0.1, 0.000000000005 }, new double[] { 0, 0.1, 0.00000001 }, ExpectedResult = true)]
        [TestCase(new double[] { double.MaxValue, double.MinValue }, new double[] { double.MaxValue, double.MinValue }, ExpectedResult = true)]
        public bool OperatorEquals_TwoPolynomials_TrueOrFalse(double[] lhs, double[] rhs)
        {
            Polynomial lp = new Polynomial(lhs);
            Polynomial rp = new Polynomial(rhs);
            return lp == rp;
        }

        [TestCase(new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3 }, ExpectedResult = true)]
        [TestCase(new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, ExpectedResult = false)]
        [TestCase(new double[] { 0.00000001, 0.1, 0.000000000005 }, new double[] { 0, 0.1, 0.00000001 }, ExpectedResult = false)]
        [TestCase(new double[] { double.MaxValue, double.MinValue }, new double[] { double.MaxValue, double.MinValue }, ExpectedResult = false)]
        public bool OperatorNoEquals_TwoPolynomials_TrueOrFalse(double[] lhs, double[] rhs)
        {
            Polynomial lp = new Polynomial(lhs);
            Polynomial rp = new Polynomial(rhs);
            return lp != rp;
        }

        [TestCase(new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3 }, new double[] { 2, 4, 6, 4, 5 }, ExpectedResult = true)]
        [TestCase(new double[] { 0.0001, 0.0002, 0.00000001 }, new double[] { 0.0002, 0.0004, 0.005, -0.000000000001 }, new double[] { 0.0003, 0.0006, 0.005, 0 }, ExpectedResult = true)]
        [TestCase(new double[] { 0.000000000001, double.MinValue }, new double[] { double.MinValue, 0, 12.435 }, new double[] { double.MinValue, double.MinValue, 12.435 }, ExpectedResult = true)]
        public bool Plus_TwoPolynomials_NewPolynomial(double[] lhs, double[] rhs, double[] expected)
        {
            Polynomial lp = new Polynomial(lhs);
            Polynomial rp = new Polynomial(rhs);
            Polynomial exp = new Polynomial(expected);

            Polynomial actual = lp + rp;

            return actual == exp;
        }

        [TestCase(new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3 }, new double[] { 0, 0, 0, 4, 5 }, ExpectedResult = true)]
        [TestCase(new double[] { 0.0001, 0.0002, 0.00000001 }, new double[] { 0.0002, 0.0004, 0.005, -0.000000000001 }, new double[] { -0.0001, -0.0002, -0.005, 0 }, ExpectedResult = true)]
        [TestCase(new double[] { 0.000000000001, double.MinValue }, new double[] { double.MinValue, 0, 12.435 }, new double[] { -double.MinValue, double.MinValue, -12.435 }, ExpectedResult = true)]
        public bool Minus_TwoPolynomials_NewPolynomial(double[] lhs, double[] rhs, double[] expected)
        {
            Polynomial lp = new Polynomial(lhs);
            Polynomial rp = new Polynomial(rhs);
            Polynomial exp = new Polynomial(expected);

            Polynomial actual = lp - rp;

            return actual == exp;
        }

        [TestCase(new double[] { 0.0001, 0.0002, 0.00000001 }, ExpectedResult = 0.0001)]
        [TestCase(new double[] { 0.000000000001, double.MinValue }, ExpectedResult = 0.000000000001)]
        public double Indexator_Polynomial_Coefficient(double[] coefficients)
        {
            Polynomial pl = new Polynomial(coefficients);
            return pl[0];
        }
    }
}