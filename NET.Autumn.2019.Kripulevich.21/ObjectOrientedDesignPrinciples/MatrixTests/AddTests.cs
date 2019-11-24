using NUnit.Framework;
using Matrix.Entities;
using Matrix.Extensions;
using System;

namespace MatrixTests
{
    public class AddTests
    {
        private readonly int[,] resultSquareSymmetric = new int[,]
        {
            { 2, 7, 12, 7 },
            { 10, 12, 7, 12 },
            { 18, 0, 2, 7 },
            { 6, 8, 10, 12 }
        };

        private readonly int[,] resultSquareDiagonal = new int[,]
        {
            { 2, 2, 3, 4 },
            { 5, 12, 7, 8 },
            { 9, 0, 2, 2 },
            { 3, 4, 5, 12 },
        };

        private readonly int[,] resultSymmetricDiagonal = new int[,]
        {
            { 2, 5, 9, 3 },
            { 5, 12, 0, 4 },
            { 9, 0, 2, 5 },
            { 3, 4, 5, 12 },
        };

        private readonly SquareMatrix<int> squareMatrix = new SquareMatrix<int>(new int[,]
        {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 0, 1, 2 },
            { 3, 4, 5, 6 },
        });

        private readonly SymmetricMatrix<int> symmetricMatrix = new SymmetricMatrix<int>(new int[,]
        {
            { 1, 5, 9, 3 },
            { 5, 6, 0, 4 },
            { 9, 0, 1, 5 },
            { 3, 4, 5, 6 },
        });

        private readonly DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(new int[,]
        {
            { 1, 0, 0, 0 },
            { 0, 6, 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 6 },
        });

        private readonly SquareMatrix<int> resultSquareSymmetricMatrices = new SquareMatrix<int>(new int[,]
        {
            { 2, 7, 12, 7 },
            { 10, 12, 7, 12 },
            { 18, 0, 2, 7 },
            { 6, 8, 10, 12 },
        });

        [Test]
        public void Add_SourceMatrixIsNull_ThrowsArgumentNullException()
        {
            AbstractSquareMatrix<int> sourse = null;
            Assert.Throws<ArgumentNullException>(() => sourse.Add(symmetricMatrix));
        }

        [Test]
        public void Add_AddingMatrixIsNull_ThrowsArgumentNullException()
        {
            AbstractSquareMatrix<int> sourse = symmetricMatrix;
            Assert.Throws<ArgumentNullException>(() => sourse.Add(null));
        }

        [Test]
        public void AddMatrixTests()
        {
            Assert.AreEqual(resultSquareSymmetricMatrices, squareMatrix.Add(symmetricMatrix));
            Assert.AreEqual(new SquareMatrix<int>(resultSquareDiagonal), squareMatrix.Add(diagonalMatrix));
            Assert.AreEqual(new SymmetricMatrix<int>(resultSymmetricDiagonal), symmetricMatrix.Add(diagonalMatrix));
        }

        [Test]
        public void MatrixFailTests()
        {
            SquareMatrix<int> matrixInt = new SquareMatrix<int>(new int[1, 1] { { 1 } });
            Assert.Throws<InvalidOperationException>(() => matrixInt.Add(squareMatrix));
        }
    }
}