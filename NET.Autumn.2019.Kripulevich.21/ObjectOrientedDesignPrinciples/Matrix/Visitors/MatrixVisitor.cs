using Matrix.Entities;

namespace Matrix.Visitors
{
    public abstract class MatrixVisitor<T>
    {
        public void DynamicVisit(AbstractSquareMatrix<T> matrix)
        {
            Visit((dynamic)matrix);
        }

        protected abstract void Visit(SquareMatrix<T> matrix);

        protected abstract void Visit(DiagonalMatrix<T> matrix);

        protected abstract void Visit(SymmetricMatrix<T> matrix);
    }
}