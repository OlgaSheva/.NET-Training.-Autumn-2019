using Matrix.Entities;
using Matrix.Visitors;
using System;

namespace Matrix.Extensions
{
    public static class AbstractSquareMatrixExtension
    {
        public static AbstractSquareMatrix<T> Add<T>(this AbstractSquareMatrix<T> sourceMatrix, AbstractSquareMatrix<T> addindMatrix)
        {
            if (sourceMatrix == null)
            {
                throw new ArgumentNullException(nameof(addindMatrix));
            }

            if (addindMatrix == null)
            {
                throw new ArgumentNullException(nameof(addindMatrix));
            }

            var visitor = new AddVisitor<T>();
            visitor.DynamicVisit(sourceMatrix);
            visitor.DynamicVisit(addindMatrix);

            return visitor.Result;
        }
    }
}
