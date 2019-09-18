namespace Algorithms
{
    /// <summary>
    /// Default indexer from 0 to array.Length-1 with step = 1.
    /// </summary>
    public class DefaultIndexer : IIndexer
    {
        private int Length { get; }
        private int position;

        public DefaultIndexer(int length)
        {
            Length = length;
            position = 0;
        }

        public int StartWith => 0;

        public int EndThis => Length - 1;

        public int Next(int index) => position = ++index;
    }
}
