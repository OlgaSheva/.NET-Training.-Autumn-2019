using System;

namespace Matrix.Entities
{
    /// <summary>
    /// Diagonl matrix.
    /// </summary>
    /// <typeparam name="T">The t.</typeparam>
    /// <seealso cref="Matrix.Entities.AbstractSquareMatrix{T}" />
    public class DiagonalMatrix<T> : AbstractSquareMatrix<T>
    {
        private readonly T[] matrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <exception cref="ArgumentNullException">array</exception>
        /// <exception cref="ArgumentException">
        /// array
        /// or
        /// Not valid diagonal matrix. - array
        /// </exception>
        public DiagonalMatrix(T[,] array) : base(array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array));
            }

            base.Order = array.GetLength(0);
            this.matrix = new T[base.Order];
            for (int i = 0; i < base.Order; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (i != j && (!Equals(default(T), array[i, j]) || !Equals(default(T), array[j, i])))
                    {
                        throw new ArgumentException("Not valid diagonal matrix.", nameof(array));
                    }

                    if (i == j)
                    {
                        this.matrix[i] = array[i, j];
                    }
                }
            }
        }

        public override T[,] ToArray()
        {
            T[,] array = new T[Order, Order];
            for (int i = 0; i < Order; i++)
            {
                array[i, i] = this[i, i];
            }

            return array;
        }

        protected override T GetElement(int row, int column)
        {
            if (row != column)
            {
                return default(T);
            }

            return matrix[row];
        }

        protected override void SetElement(int row, int column, T value)
        {
            if (row != column)
            {
                throw new ArgumentException("Invalid idexes.");
            }

            matrix[row] = value;
        }
    }
}
