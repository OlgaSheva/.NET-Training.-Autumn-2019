using System;
using System.Collections;
using System.Collections.Generic;

namespace PsevdoEnumerable
{
    public static class Enumerable
    {
        /// <summary>
        /// Filters the specified predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Filtered source the specified predicate.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// The source cannot be null.
        /// or
        /// The predicate cannot be null.
        /// </exception>
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"The {nameof(source)} cannot be null.");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException($"The {nameof(predicate)} cannot be null.");
            }

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Ranges the specified start.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="count">The count.</param>
        /// <returns>Sequence of numbers.</returns>
        /// <exception cref="System.ArgumentException">
        /// The {nameof(start)} cannot be negative.
        /// or
        /// The {nameof(start)} is not valid.
        /// </exception>
        public static IEnumerable<int> Range(int start, int count)
        {
            if (start < 0)
            {
                throw new ArgumentException($"The {nameof(start)} cannot be negative.");
            }

            if ((int.MaxValue - count) < start)
            {
                throw new ArgumentException($"The {nameof(start)} is not valid.");
            }

            for (int i = start; i < start + count; i++)
            {
                yield return i;
            }
        }

        /// <summary>
        /// Reverses the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>Reversed the specified source.</returns>
        /// <exception cref="System.ArgumentNullException">The {nameof(source)} cannot be null.</exception>
        public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"The {nameof(source)} cannot be null.");
            }

            var buffer = new BufferData<TSource>(source);

            for (int i = buffer.count - 1; i >= 0; i--)
            {
                yield return buffer.items[i];
            }
        }

        /// <summary>
        /// Transforms the specified transformer.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="transformer">The transformer.</param>
        /// <returns>Transformed source.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// The {nameof(source)} cannot be null.
        /// or
        /// The {nameof(transformer)} cannot be null.
        /// </exception>
        public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> transformer)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"The {nameof(source)} cannot be null.");
            }

            if (transformer == null)
            {
                throw new ArgumentNullException($"The {nameof(transformer)} cannot be null.");
            }

            foreach (var item in source)
            {
                yield return transformer(item);
            }
        }

        /// <summary>
        /// Counts the specified predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>The count of specified by predicate elements in the source.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// The {nameof(source)} cannot be null.
        /// or
        /// The {nameof(predicate)} cannot be null.
        /// </exception>
        public static int Count<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"The {nameof(source)} cannot be null.");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException($"The {nameof(predicate)} cannot be null.");
            }

            int count = 0;
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Counts the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>The count of elements in the source.</returns>
        /// <exception cref="System.ArgumentNullException">The {nameof(source)} cannot be null.</exception>
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"The {nameof(source)} cannot be null.");
            }

            int count = 0;
            foreach (var item in source)
            {
                count++;
            }

            return count;
        }

        /// <summary>
        /// Casts the sequence to TResult sequence.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>The TResult sequence.</returns>
        /// <exception cref="System.ArgumentNullException">The {nameof(source)} cannot be null.</exception>
        public static IEnumerable<TResult> CastTo<TResult>(IEnumerable source)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"The {nameof(source)} cannot be null.");
            }

            foreach (TResult item in source)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Determines whether all elements of a sequence satisfy a condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        ///     <see langword="true" /> if every element of the source sequence passes the test in the specified predicate,
        ///     or if the sequence is empty; otherwise, <see langword="false" />.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// The {nameof(source)} cannot be null.
        /// or
        /// The {nameof(predicate)} cannot be null.
        /// </exception>
        public static bool ForAll<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"The {nameof(source)} cannot be null.");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException($"The {nameof(predicate)} cannot be null.");
            }

            foreach (TSource source1 in source)
            {
                if (!predicate(source1))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Sorts the sequence by key.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="key">The key.</param>
        /// <returns>Sorted sequence by key.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// The {nameof(source)} cannot be null.
        /// or
        /// The {nameof(key)} cannot be null.
        /// </exception>
        public static IEnumerable<TSource> SortBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> key)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"The {nameof(source)} cannot be null.");
            }

            if (key == null)
            {
                throw new ArgumentNullException($"The {nameof(key)} cannot be null.");
            }

            IComparer<TKey> comparer = Comparer<TKey>.Default;
            var buffer = SortBy(source, key, comparer);

            foreach (var item in buffer)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Sorts the sequence by key.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="key">The key.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>Sorted sequence by key.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// The {nameof(source)} cannot be null.
        /// or
        /// The {nameof(key)} cannot be null.
        /// </exception>
        public static IEnumerable<TSource> SortBy<TSource, TKey>(this IEnumerable<TSource> source,
            Func<TSource, TKey> key, IComparer<TKey> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"The {nameof(source)} cannot be null.");
            }

            if (key == null)
            {
                throw new ArgumentNullException($"The {nameof(key)} cannot be null.");
            }

            var buffer = new BufferData<TSource>(source).ToArray();
            comparer = comparer != null ? comparer : (IComparer<TKey>)Comparer<TKey>.Default;
            for (int i = 0; i < buffer.Length; i++)
            {
                for (int j = i; j < buffer.Length; j++)
                {
                    if (comparer.Compare(key(buffer[i]), key(buffer[j])) > 0)
                    {
                        var temp = buffer[i];
                        buffer[i] = buffer[j];
                        buffer[j] = temp;
                    }
                }
            }

            foreach (var item in buffer)
            {
                yield return item;
            }
        }
    }

    internal struct BufferData<T>
    {
        internal T[] items;
        internal int count;

        internal BufferData(IEnumerable<T> source)
        {
            ICollection<T> collection = source as ICollection<T>;
            if (collection != null)
            {
                count = collection.Count();
            }
            else
            {
                count = 0;
                foreach (var item in source)
                {
                    count++;
                }
            }

            items = new T[count];
            int i = 0;
            foreach (var item in source)
            {
                items[i++] = item;
            }
        }

        internal T[] ToArray()
        {
            return items;
        }
    }
}
