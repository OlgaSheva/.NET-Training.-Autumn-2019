namespace Extensions.Interfaces
{
    public interface IPredicate<T>
    {
        bool IsMatch(T value);
    }
}
