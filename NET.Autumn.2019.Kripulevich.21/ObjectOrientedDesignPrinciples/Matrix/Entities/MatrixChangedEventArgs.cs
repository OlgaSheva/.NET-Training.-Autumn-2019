namespace Matrix.Entities
{
    /// <summary>
    /// Matrix changed EventArgs.
    /// </summary>
    /// <typeparam name="T">The matrix type parameter.</typeparam>
    public class MatrixChangedEventArgs<T>
    {
        /// <summary>
        /// Gets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public int X { get; private set; }

        /// <summary>
        /// Gets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public int Y { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixChangedEventArgs{T}"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public MatrixChangedEventArgs(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
