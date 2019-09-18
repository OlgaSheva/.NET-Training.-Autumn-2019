using System;

namespace Algorithms
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Array sorting using comprer and indexer.
        /// </summary>
        /// <param name="array">The array of int.</param>
        /// <param name="comparer">The comparison principle.</param>
        /// <param name="indexer">Indexer.</param>
        /// <exception cref="ArgumentNullException">Throw when array, comparer or indexer is null.</exception>
        public static void SortTheArray(int[] array, IComparer comparer, IIndexer indexer)
        {
            if (array == null)
                throw new ArgumentNullException($"{nameof(array)} can't be null.");
            if (comparer == null)
                throw new ArgumentNullException($"{nameof(comparer)} can't be null.");
            if (indexer == null)
                throw new ArgumentNullException($"{nameof(indexer)} can't be null.");

            BubbleSort.Sort(array, comparer, indexer);
        }

        /// <summary>
        /// Default array sorting.
        /// </summary>
        /// <param name="array"></param>
        /// <exception cref="ArgumentNullException">Throw when array is null.</exception>
        public static void SortTheArray(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException($"{nameof(array)} can't be null.");

            SortTheArray(array, new DefaultComparer(), new DefaultIndexer(array.Length));
        }
    }
}
