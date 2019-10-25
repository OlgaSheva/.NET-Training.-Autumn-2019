namespace BinarySearchTreeTests
{
    /// <summary>
    /// The point class.
    /// </summary>
    public class Point
    {      
        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public double Y { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
