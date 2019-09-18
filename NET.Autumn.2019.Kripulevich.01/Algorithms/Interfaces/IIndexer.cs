namespace Algorithms
{
    /// <summary>
    /// Indexer for array.
    /// </summary>
    public interface IIndexer
    {
        /// <summary>
        /// Start index.
        /// </summary>
        int StartWith { get; }

        /// <summary>
        /// Last index.
        /// </summary>
        int EndThis { get; }

        /// <summary>
        /// Step.
        /// </summary>
        int Next(int index);
    }
}