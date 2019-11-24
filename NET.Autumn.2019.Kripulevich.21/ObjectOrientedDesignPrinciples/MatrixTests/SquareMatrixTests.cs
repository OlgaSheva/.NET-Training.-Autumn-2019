using Matrix.Entities;
using NUnit.Framework;
using System;

namespace MatrixTests
{
    class SquareMatrixTests
    {
        [Test]
        public void Constructor_NullSourseArray_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new SquareMatrix<object>(null));

        [Test]
        public void Constructor_EmptySourseArray_ThrowsArgumentException() =>
            Assert.Throws<ArgumentException>(() => new SquareMatrix<object>(new object[0, 0]));

        [Test]
        public void Constructor_SourceArray_ValidMatrix()
        {
            int[,] square = new int[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 0, 1, 2 },
                { 3, 4, 5, 6 },
            };
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(square);
            Assert.AreEqual(squareMatrix.Order, square.GetLength(0));
            for (int i = 0; i < square.GetLength(0); i++)
            {
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    Assert.AreEqual(square[i,j], squareMatrix[i,j]);
                }
            }
        }
    }
}
