using Extensions.Interfaces;
using System;

namespace ExtensionsTests.Sorters
{
    public class ArraySorter<T> : ISorter<T>
    {
        public T[] Sort(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be null.");
            }

            T[] sortedArray = new T[array.Length];
            Array.Copy(array, sortedArray, array.Length);
            Array.Sort(sortedArray);

            return sortedArray;
        }
    }
}
