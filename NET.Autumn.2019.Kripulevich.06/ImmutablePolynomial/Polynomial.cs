using System;
using System.Configuration;

namespace ImmutablePolynomial
{
    /// <summary>
    /// Class polynomial.
    /// </summary>
    public sealed class Polynomial : ICloneable, IEquatable<Polynomial>
    {
        private static readonly double epsilon;

        /// <summary>
        /// Coefficients of polynomial.
        /// </summary>
        private readonly double[] coefficients;

        /// <summary>
        /// The degree of polynomial.
        /// </summary>
        private readonly int degree;
        
        static Polynomial()
        {
            try
            {
                epsilon = double.Parse(ConfigurationManager.AppSettings.Get("epsilon"));
            }
            catch
            {
                epsilon = 0.0000001;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="coefficients">The cofficients.</param>
        public Polynomial(double[] coefficients)
        {
            if (coefficients == null)
            {
                throw new ArgumentNullException($"{nameof(coefficients)} can't be null.");
            }

            if (coefficients.Length == 0)
            {
                throw new ArgumentException($"{nameof(coefficients)} length must be more than 0.");
            }

            this.coefficients = new double[coefficients.Length];
            Array.Copy(coefficients, this.coefficients, coefficients.Length);
            this.degree = coefficients.Length - 1;
        }

        /// <summary>
        /// Equals of two polynomials.
        /// </summary>
        /// <param name="other">The polynomial.</param>
        /// <returns>False if polynomials aren't equals, true if they are equels.</returns>
        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.degree != other.degree || this.coefficients.Length != other.coefficients.Length)
            {
                return false;
            }

            for (int i = 0; i < this.coefficients.Length; i++)
            {
                if (!IsEquivalent(this.coefficients[i], other.coefficients[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Equals of two polynomials.
        /// </summary>
        /// <param name="obj">The polynomial.</param>
        /// <returns>False if polynomials aren't equals, true if they are equels.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((Polynomial)obj);
        }

        /// <summary>
        /// Get hash code of the polynomial.
        /// </summary>
        /// <returns>Hash code of the polynomial.</returns>
        public override int GetHashCode()
        {
            return degree.GetHashCode();
        }

        /// <summary>
        /// Operator ==.
        /// </summary>
        /// <param name="lhs">The polynomial.</param>
        /// <param name="rhs">The polynomial.</param>
        /// <returns>False if polynomials aren't equals, true if they are equels.</returns>
        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, rhs))
            {
                return true;
            }

            if (ReferenceEquals(lhs, null))
            {
                return false;
            }

            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Operator !=.
        /// </summary>
        /// <param name="lhs">The polynomial.</param>
        /// <param name="rhs">The polynomial.</param>
        /// <returns>True if polynomials aren't equals, false if they are equels.</returns>
        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// The sum of two Polynomial.
        /// </summary>
        /// <param name="lhs">The polynomial.</param>
        /// <param name="rhs">The polynomial.</param>
        /// <returns>The sum of two Polynomial.</returns>
        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            if (lhs == null || rhs == null)
            {
                throw new ArgumentNullException($"{nameof(lhs)} or {nameof(rhs)} can't be null.");
            }

            Polynomial larger = (lhs.coefficients.Length > rhs.coefficients.Length) ? lhs.Clone() : rhs.Clone();
            Polynomial smoller = (lhs.coefficients.Length < rhs.coefficients.Length) ? lhs : rhs;

            for (int i = 0; i < smoller.coefficients.Length; i++)
            {
                larger.coefficients[i] += smoller.coefficients[i];
            }

            return larger;
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="polynomial">The polynomial.</param>
        /// <param name="number">The number.</param>
        /// <returns>
        /// The result of multiply.
        /// </returns>
        /// <exception cref="ArgumentNullException">Throws if polynomial is null.</exception>
        public static Polynomial operator *(Polynomial polynomial, double number)
        {
            if (polynomial == null)
            {
                throw new ArgumentNullException($"{nameof(polynomial)} can't be null.");
            }

            Polynomial p = polynomial.Clone();
            for (int i = 0; i < p.coefficients.Length; i++)
            {
                p.coefficients[i] = p.coefficients[i] * number;
            }

            return p;
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="polynomial">The polynomial.</param>
        /// <returns>
        /// The result of multiply.
        /// </returns>
        /// <exception cref="ArgumentNullException">Throws if polynomial is null.</exception>
        public static Polynomial operator *(double number, Polynomial polynomial)
        {
            if (polynomial == null)
            {
                throw new ArgumentNullException($"{nameof(polynomial)} can't be null.");
            }

            Polynomial p = polynomial.Clone();
            for (int i = 0; i < p.coefficients.Length; i++)
            {
                p.coefficients[i] = p.coefficients[i] * number;
            }

            return p;
        }

        /// <summary>
        /// The difference of two Polynomial.
        /// </summary>
        /// <param name="lhs">The polynomial.</param>
        /// <param name="rhs">The polynomial.</param>
        /// <returns>The difference of two Polynomial.</returns>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            return lhs + rhs * (-1);
        }

        /// <summary>
        /// Gets the <see cref="System.Double"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="System.Double"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index > coefficients.Length)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(index)} is out of the allowed range.");
                }

                return coefficients[index];
            }
            private set
            {
                if (index >= 0 || index < coefficients.Length)
                {
                    coefficients[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"{nameof(index)} is out of the allowed range.");
                }
            }
        }

        /// <summary>
        /// Clone the polynomial.
        /// </summary>
        /// <returns>Returns clone of the polynomial.</returns>
        public Polynomial Clone()
        {
            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Realization of ICloneable.Clone.
        /// </summary>
        /// <returns></returns>
        object ICloneable.Clone()
        {
            return new Polynomial(coefficients);
        }

        private bool IsEquivalent(double lhs, double rhs)
        {
            return Math.Abs(lhs - rhs) < epsilon;
        }
    }
}
