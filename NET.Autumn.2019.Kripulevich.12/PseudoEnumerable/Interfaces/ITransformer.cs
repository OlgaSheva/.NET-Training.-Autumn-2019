namespace PseudoEnumerable.Interfaces
{
    public interface ITransformer<in TSource, out TResult>
    {
        TResult Transform(TSource item);
    }
}