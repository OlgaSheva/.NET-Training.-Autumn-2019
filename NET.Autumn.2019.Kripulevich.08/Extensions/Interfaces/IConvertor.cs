namespace Extensions.Interfaces
{
    public interface IConvertor<TSource, TResult>
    {
        TResult Convert(TSource source);
    }
}