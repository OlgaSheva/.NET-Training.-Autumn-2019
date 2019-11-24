using Matrix.Entities;
using NUnit.Framework;
using System;

namespace MatrixTests
{
    class SymmetricMatrixTest
    {
        private readonly string[,] stringSquare = new string[,]
        {
            { "1", "2", "3", "4" },
            { "5", "6", "7", "8" },
            { "9", "0", "1", "2" },
            { "3", "4", "5", "6" },
        };

        [Test]
        public void Constructor_NullSourseArray_ThrowsArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new SymmetricMatrix<object>(null));

        [Test]
        public void Constructor_EmptySourseArray_ThrowsArgumentException() =>
            Assert.Throws<ArgumentException>(() => new SymmetricMatrix<object>(new object[0, 0]));

        [Test]
        public void FailAddMatrixTests() =>
            Assert.Throws<ArgumentException>(() => new SymmetricMatrix<string>(stringSquare));

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
            Assert.Throws<ArgumentException>(() => new SymmetricMatrix<int>(square));
        }

        [Test]
        public void Constructor_SourceArray_ValidMatrix()
        {
            int[,] symmetric = new int[,]
            {
                { 1, 5, 9, 3 },
                { 5, 6, 0, 4 },
                { 9, 0, 1, 5 },
                { 3, 4, 5, 6 },
            };
            SymmetricMatrix<int> squareMatrix = new SymmetricMatrix<int>(symmetric);
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