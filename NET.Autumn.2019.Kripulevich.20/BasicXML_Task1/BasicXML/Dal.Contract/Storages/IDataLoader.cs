namespace Dal.Contract.Storages
{
    /// <summary>
    /// The data loder interfce.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataLoader<T>
    {
        /// <summary>
        /// Loads this instance.
        /// </summary>
        /// <returns>T.</returns>
        T Load();
    }
}
