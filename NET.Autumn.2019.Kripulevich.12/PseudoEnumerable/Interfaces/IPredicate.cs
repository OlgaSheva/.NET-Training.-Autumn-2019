namespace PseudoEnumerable.Interfaces
{
    public interface IPredicate<in T>
    {
        bool IsMatching(T item);
    }
}