using System;

namespace Matrix.Entities
{
    public class SquareMatrix<T> : AbstractSquareMatrix<T>
    {
        private readonly T[] matrix;

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
