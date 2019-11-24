using Matrix.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Matrix.Visitors
{
    public class AddVisitor<T> : MatrixVisitor<T>
    {
        private readonly Dictionary<Type, int> matrixTypePriority = new Dictionary<Type, int>
        {
            [typeof(SquareMatrix<T>)] = 1,
            [typeof(SymmetricMatrix<T>)] = 2,
            [typeof(DiagonalMatrix<T>)] = 3,
        };

        public AbstractSquareMatrix<T> Result { get; set; }

        protected override void Visit(SquareMatrix<T> matrix)
        {
            this.ValidateMatrix(matrix);
            T[,] array = new T[matrix.Order, matrix.Order];
            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    array[i, j] = matrix[i, j];
                }
            }

            this.NormalizeResultType(matrix, () => new SquareMatrix<T>(array));
        }

        protected override void Visit(SymmetricMatrix<T> matrix)
        {
            this.ValidateMatrix(matrix);
            T[,] array = new T[matrix.Order, matrix.Order];
            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    array[i, j] = matrix[i, j];
                }
            }

            this.NormalizeResultType(matrix, () => new SymmetricMatrix<T>(array));
        }

        protected override void Visit(DiagonalMatrix<T> matrix)
        {
            this.ValidateMatrix(matrix);
            T[,] array = new T[matrix.Order, matrix.Order];
            for (int i = 0; i < matrix.Order; i++)
            {
                array[i, i] = matrix[i, i];
            }

            this.NormalizeResultType(matrix, () => new DiagonalMatrix<T>(array));
        }

        private void ValidateMatrix(AbstractSquareMatrix<T> matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (this.Result != null && this.Result.Order != matrix.Order)
            {
                throw new InvalidOperationException("Matrices order must match.");
            }
        }

        private void NormalizeResultType(AbstractSquareMatrix<T> matrix, Func<AbstractSquareMatrix<T>> creator)
        {
            if (this.Result is null)
            {
                this.Result = creator();
            }
            else if (this.matrixTypePriority[this.Result.GetType()] > this.matrixTypePriority[matrix.GetType()])
            {
                dynamic temp = this.Result;
                this.Result = creator();
                this.Add(temp);
            }
            else
            {
                this.Add(matrix);
            }
        }

        private void Add(AbstractSquareMatrix<T> matrix)
        {
            for (int i = 0; i < matrix.Order; i++)
            {
                for (int j = 0; j < matrix.Order; j++)
                {
                    this.Result[i, j] = Add(this.Result[i, j], matrix[i, j]);
                }
            }
        }

        private void Add(DiagonalMatrix<T> matrix)
        {
            for (int i = 0; i < matrix.Order; i++)
            {
                this.Result[i, i] = Add(this.Result[i, i], matrix[i, i]);
            }
        }

        private static T Add(T first, T second)
        {
            try
            {
                return ExpressionAdd(first, second);
            }
            catch (InvalidOperationException ex)
            {
                throw new NotSupportedException($"The '{typeof(T)}' type is not supported.", ex);
            }
        }

        private static T ExpressionAdd(T lth, T rth)
        {
            ParameterExpression a = Expression.Parameter(typeof(T), "a");
            ParameterExpression b = Expression.Parameter(typeof(T), "b");
            Expression<Func<T, T, T>> lambda = Expression.Lambda<Func<T, T, T>>(Expression.Add(a, b), a, b);
            Func<T, T, T> add = lambda.Compile();
            return add(lth, rth);
        }
    }
}