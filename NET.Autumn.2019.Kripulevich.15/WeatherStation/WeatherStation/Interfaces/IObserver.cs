namespace WeatherStationCA.Interfaces
{
    /// <summary>
    /// The observer class interface.
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// Updates the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="temperature">The temperature.</param>
        /// <param name="humidity">The humidity.</param>
        /// <param name="pressure">The pressure.</param>
        void Update(IObservable sender, int temperature, int humidity, int pressure);
    }
}
