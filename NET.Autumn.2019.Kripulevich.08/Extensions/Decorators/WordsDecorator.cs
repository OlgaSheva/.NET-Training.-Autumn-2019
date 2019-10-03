using Extensions.Interfaces;
using System;
using System.Collections.Generic;

namespace Extensions.Decorators
{
    public class WordsDecorator<TSource, TResult> : Words, IConvertor<TSource, TResult>
    {
        private readonly Words words;

        public WordsDecorator(Words words, IDictionary<char, string> dictionary) : base(dictionary)
        {
            if (words == null)
            {
                throw new ArgumentNullException($"{nameof(words)} can't be null.");
            }

            this.words = words;
        }

        public TResult Convert(TSource source)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} can't be null.");
            }

            if (source is double)
            {
                return (TResult)(object)(words.TransformToWords((double)(object)source));
            }

            return (TResult)(object)source;
        }        
    }
}
