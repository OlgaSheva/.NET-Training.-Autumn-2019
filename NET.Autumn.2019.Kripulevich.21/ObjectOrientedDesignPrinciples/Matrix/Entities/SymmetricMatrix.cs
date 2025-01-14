﻿using System;

namespace Matrix.Entities
{
    /// <summary>
    /// Symmetric mtrix.
    /// </summary>
    /// <typeparam name="T">The t.</typeparam>
    /// <seealso cref="Matrix.Entities.AbstractSquareMatrix{T}" />
    public class SymmetricMatrix<T> : AbstractSquareMatrix<T>
    {
        private readonly T[] matrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <exception cref="ArgumentNullException">array</exception>
        /// <exception cref="ArgumentException">
        /// array
        /// or
        /// Not valid symmetric matrix. - array
        /// </exception>
        public SymmetricMatrix(T[,] array) : base(array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array));
            }

            base.Order = array.GetUpperBound(0) + 1;
            this.matrix = new T[(base.Order + array.Length) / 2];
            int k = 0;
            for (int i = 0; i < base.Order; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (!Equals(array[i, j], array[j, i]))
                    {
                        throw new ArgumentException("Not valid symmetric matrix.", nameof(array));
                    }

                    this.matrix[k++] = array[i, j];
                }
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
            int index = (row > column) ? GetIndex(row, column) : GetIndex(column, row);
            if (index < 0)
            {
                throw new ArgumentException($"The element [{row}, {column}] doesnot exist.");
            }

            return matrix[index];
        }

        protected override void SetElement(int row, int column, T value)
        {
            int index = (row > column) ? GetIndex(row, column) : GetIndex(column, row);
            if (index < 0)
            {
                throw new ArgumentException($"The element [{row}, {column}] doesnot exist.");
            }

            matrix[index] = value;
        }

        private int GetIndex(int row, int column)
        {
            int index = 0;
            for (int i = 0; i < base.Order; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if ((row == i) && (column == j))
                    {
                        return index;
                    }

                    index++;
                }
            }

            return -1;
        }
    }
}
