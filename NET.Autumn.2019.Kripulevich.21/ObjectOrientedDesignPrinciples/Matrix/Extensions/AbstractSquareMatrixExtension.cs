using Matrix.Entities;
using Matrix.Visitors;
using System;

namespace Matrix.Extensions
{
    /// <summary>
    /// Abstract square matrix extensions.
    /// </summary>
    public static class AbstractSquareMatrixExtension
    {
        /// <summary>
        /// Adds the specified addind matrix.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceMatrix">The source matrix.</param>
        /// <param name="addindMatrix">The addind matrix.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// addindMatrix
        /// or
        /// addindMatrix
        /// </exception>
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
