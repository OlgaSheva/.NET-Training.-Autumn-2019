using System;
using System.Collections;
using System.Collections.Generic;

namespace Matrix.Entities
{
    public abstract class AbstractSquareMatrix<T> : IEnumerable<T>
    {
        private readonly T[,] matrix;

        public int Order { get; protected set; }

        public event EventHandler<MatrixChangedEventArgs<T>> MatrixChanged = delegate { };        

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
