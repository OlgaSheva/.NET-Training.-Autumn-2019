using Extensions.Interfaces;
using System;

namespace Extensions.Decorators
{
    public class IEEE754Decorator<TSource, TResult> : IConvertor<TSource, TResult>
    {
        public TResult Convert(TSource source)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} can't be null.");
            }

            if (source is double)
            {
                return (TResult)(object)(IEEE754.IEEE754Format((double)(object)source));
            }

            return (TResult)(object)source;
        }
    }
}
