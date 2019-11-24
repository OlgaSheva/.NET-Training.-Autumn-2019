using Matrix.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixTests
{
    class DiagonalMatrixTests
    {
        [Test]
        public void Constructor_NullSourseArray_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new DiagonalMatrix<object>(null));

        [Test]
        public void Constructor_EmptySourseArray_ThrowsArgumentException() =>
            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<object>(new object[0, 0]));

        [Test]
        public void Constructor_InvalidSourceArray_ThrowsArgumentException()
        {
            int[,] square = new int[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 0, 1, 2 },
                { 3, 4, 5, 6 },
            };
            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<int>(square));
        }

        [Test]
        public void Constructor_SourceArray_ValidMatrix()
        {
            int[,] symmetric = new int[,]
            {
                { 1, 0, 0, 0 },
                { 0, 6, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 6 },
            };
            DiagonalMatrix<int> squareMatrix = new DiagonalMatrix<int>(symmetric);
            Assert.AreEqual(squareMatrix.Order, symmetric.GetLength(0));
            for (int i = 0; i < symmetric.GetLength(0); i++)
            {
                for (int j = 0; j < symmetric.GetLength(1); j++)
                {
                    Assert.AreEqual(symmetric[i, j], squareMatrix[i, j]);
                }
            }
        }
    }
}
