using System;
using System.Collections;
using System.Collections.Generic;

namespace Matrix.Entities
{
    /// <summary>
    /// Abstract square matrix.
    /// </summary>
    /// <typeparam name="T">The t.</typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
    public abstract class AbstractSquareMatrix<T> : IEnumerable<T>
    {
        private readonly T[,] matrix;

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public int Order { get; protected set; }

        /// <summary>
        /// Occurs when [matrix changed].
        /// </summary>
        public event EventHandler<MatrixChangedEventArgs<T>> MatrixChanged = delegate { };

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractSquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <exception cref="ArgumentNullException">array</exception>
        /// <exception cref="ArgumentException">
        /// array
        /// or
        /// array
        /// </exception>
        public AbstractSquareMatrix(T[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));

            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array));
            }

            int row = array.GetLength(0);
            int colomn = array.GetLength(1);
            if (row != colomn)
            {
                throw new ArgumentException(nameof(array));
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="T"/> with the specified row.
        /// </summary>
        /// <value>
        /// The <see cref="T"/>.
        /// </value>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        public virtual T this[int row, int column]
        {
            get
            {
                IsInAValidRange(row, 0, Order);
                IsInAValidRange(column, 0, Order);
                return GetElement(row, column);
            }
            set
            {
                IsInAValidRange(row, 0, Order);
                IsInAValidRange(column, 0, Order);
                SetElement(row, column, value);
                OnMatrixChanged(new MatrixChangedEventArgs<T>(row, column));
            }
        }

        public abstract T[,] ToArray();

        protected abstract T GetElement(int row, int column);
        protected abstract void SetElement(int row, int column, T value);

        protected virtual void OnMatrixChanged(MatrixChangedEventArgs<T> args)
        {
            MatrixChanged?.Invoke(this, args);
        }

        private void IsInAValidRange(int index, int minvalue, int order)
        {
            if (index < minvalue || index >= order)
            {
                throw new IndexOutOfRangeException($"Value of the index '{index}' is out of range.");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
