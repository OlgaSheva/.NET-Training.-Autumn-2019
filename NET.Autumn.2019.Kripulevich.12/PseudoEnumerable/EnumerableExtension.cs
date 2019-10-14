using System;
using System.Collections.Generic;
using PseudoEnumerable.Interfaces;

namespace PseudoEnumerable
{
    public static class EnumerableExtension
    {
        #region Implementation through interfaces

        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source,
            IPredicate<TSource> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"The {nameof(source)} can't be null.");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException($"The {nameof(predicate)} can't be null.");
            }

            foreach (var item in source)
            {
                if (predicate.IsMatching(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> source,
            ITransformer<TSource, TResult> transformer)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"The {nameof(source)} can't be null.");
            }

            if (transformer == null)
            {
                throw new ArgumentNullException($"The {nameof(transformer)} can't be null.");
            }

            Converter<TSource, TResult> t = transformer.Transform;
            return Transform(source, t);
        }

        public static IEnumerable<TSource> OrderAccordingTo<TSource>(this IEnumerable<TSource> source,
            IComparer<TSource> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} can't be null.");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException($"{nameof(comparer)} can't be null.");
            }

            var list = new List<TSource>(source);
            list.Sort(comparer);
            
            return list;
        }

        #endregion

        #region Implementation vs delegates

        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source,
            Predicate<TSource> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"The {nameof(source)} can't be null.");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException($"The {nameof(predicate)} can't be null.");
            }

            var p = new WrapperIPredicate<TSource>(predicate);
            return Filter(source, p);
        }

        public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> source,
            Converter<TSource, TResult> transformer)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"The {nameof(source)} can't be null.");
            }

            if (transformer == null)
            {
                throw new ArgumentNullException($"The {nameof(transformer)} can't be null.");
            }

            foreach (var item in source)
            {
                yield return transformer(item);
            }
        }

        public static IEnumerable<TSource> OrderAccordingTo<TSource>(this IEnumerable<TSource> source,
            Comparison<TSource> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"The {nameof(source)} can't be null.");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException($"The {nameof(comparer)} can't be null.");
            }

            var c = new WrapperIComparer<TSource>(comparer);
            return OrderAccordingTo(source, c);
        }

        #endregion

        #region private

        private class WrapperIPredicate<T> : IPredicate<T>
        {
            Predicate<T> predicate;

            public WrapperIPredicate(Predicate<T> predicate)
            {
                this.predicate = predicate;
            }

            public bool IsMatching(T item)
            {
                return predicate.Invoke(item);
            }
        }

        private class WrapperIComparer<T> : IComparer<T>
        {
            Comparison<T> predicate;

            public WrapperIComparer(Comparison<T> predicate)
            {
                this.predicate = predicate;
            }

            public int Compare(T x, T y)
            {
                return predicate.Invoke(x, y);
            }
        }

#endregion
    }
}