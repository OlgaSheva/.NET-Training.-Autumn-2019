namespace Algorithms
{
    /// <summary>
    /// Indexer by multiplicity some number.
    /// </summary>
    /// <seealso cref="Algorithms.IIndexer" />
    public class MultiplicityIndexer : IIndexer
    {
        int position = -1;
        private int Length { get; }
        private int MultiplicityKey { get; }
        private int lastIndex;

        public MultiplicityIndexer(int length, int multiplicityKey)
        {
            Length = length;
            MultiplicityKey = multiplicityKey;
            lastIndex = GetLastIndex(Length, MultiplicityKey);
        }

        int IIndexer.StartWith => 0;

        int IIndexer.EndThis => lastIndex;

        int IIndexer.Next(int index) => position = index + MultiplicityKey;

        private int GetLastIndex(int length, int multiplicityKey)
        {
            for (int i = 0; i < length; i++)
            {
                if (i % multiplicityKey == 0)
                {
                    lastIndex = i;
                }
            }
            return lastIndex;
        }
    }
}
