using Matrix.Entities;

namespace Matrix.Visitors
{
    /// <summary>
    /// Abstarct matrix visitor.
    /// </summary>
    /// <typeparam name="T">The t.</typeparam>
    public abstract class MatrixVisitor<T>
    {
        /// <summary>
        /// Dynamics the visit.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        public void DynamicVisit(AbstractSquareMatrix<T> matrix)
        {
            Visit((dynamic)matrix);
        }

        protected abstract void Visit(SquareMatrix<T> matrix);

        protected abstract void Visit(DiagonalMatrix<T> matrix);

        protected abstract void Visit(SymmetricMatrix<T> matrix);
    }
}