using Matrix.Entities;
using System;

namespace MatrixConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var squareMatrix = new SquareMatrix<int>(new int[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 0, 1, 2 },
                { 3, 4, 5, 6 },
            });
            squareMatrix.MatrixChanged += MatrixChangedEvent;
            squareMatrix[0, 0] = 1;
            squareMatrix.MatrixChanged -= MatrixChangedEvent;
            squareMatrix[0, 1] = 2;
            squareMatrix.MatrixChanged += MatrixChangedEvent;
            squareMatrix[1, 1] = 3;
            Console.ReadKey();
        }

        static void MatrixChangedEvent(object sender, MatrixChangedEventArgs<int> e)
        {
            Console.WriteLine($"Element [{e.X}, {e.Y}] has been changed.");
        }
    }
}
