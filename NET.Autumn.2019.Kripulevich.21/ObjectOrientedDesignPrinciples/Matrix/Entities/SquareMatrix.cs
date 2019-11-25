using System;

namespace Matrix.Entities
{
    /// <summary>
    /// Square matrix.
    /// </summary>
    /// <typeparam name="T">The t.</typeparam>
    /// <seealso cref="Matrix.Entities.AbstractSquareMatrix{T}" />
    public class SquareMatrix<T> : AbstractSquareMatrix<T>
    {
        private readonly T[] matrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="array">The array.</param>
        public SquareMatrix(T[,] array) : base(array)
        {
            base.Order = array.GetUpperBound(0) + 1;
            this.matrix = new T[base.Order * base.Order];
            int j = 0;
            foreach (T i in array)
            {
                this.matrix[j++] = i;
            }
        }

        public override T[,] ToArray()
        {
            T[,] array = new T[Order, Order];
            for (int i = 0; i < Order; i++)
            {
                for (int j = 0; j < Order; j++)
                {
                    array[i, j] = this[i, j];
                }
            }

            return array;
        }

        protected override T GetElement(int row, int column)
        {
            return matrix[(row * Order) + column];
        }

        protected override void SetElement(int row, int column, T value)
        {
            matrix[(row * Order) + column] = value;
        }
    }
}
