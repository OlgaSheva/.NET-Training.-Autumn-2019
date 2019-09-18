using System;

namespace Algorithms
{    
    static class BubbleSort
    {
        /// <summary>
        /// Array bubble sorting.
        /// </summary>
        /// <param name="array">The array of int.</param>
        /// <param name="comparer">The comparison principle.</param>
        /// <param name="indexer">Indexer.</param>
        public static void Sort(int[] array, IComparer comparer, IIndexer indexer)
        {
            bool flag = true;
            while (flag)
            {                
                for (int i = indexer.StartWith; i <= indexer.EndThis; i = indexer.Next(i))
                {
                    flag = false;
                    for (int j = indexer.Next(i); j <= indexer.EndThis; j = indexer.Next(j))
                    {
                        if (comparer.Compare(array[i], array[j]) > 0)
                        {
                            int temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                            flag = true;
                        }
                    }
                }
            }
        }
    }
}
