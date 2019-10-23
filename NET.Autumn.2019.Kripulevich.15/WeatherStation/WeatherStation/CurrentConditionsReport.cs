using System;
using WeatherStationCA.Interfaces;

namespace WeatherStation
{
    /// <summary>
    /// The current conditions report class.
    /// </summary>
    /// <seealso cref="WeatherStationCA.Interfaces.IObserver" />
    public class CurrentConditionsReport : IObserver
    {
        /// <summary>
        /// Updates the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="temperature">The temperature.</param>
        /// <param name="humidity">The humidity.</param>
        /// <param name="pressure">The pressure.</param>
        /// <exception cref="ArgumentNullException">The {nameof(sender)} cannot be null.</exception>
        /// <exception cref="ArgumentException">The following ranges are valid: temperature(-70 - 50), humidity(0 - 100), pressure(730 - 780).</exception>
        public void Update(IObservable sender, int temperature, int humidity, int pressure)
        {
            if (sender == null)
            {
                throw new ArgumentNullException($"The {nameof(sender)} cannot be null.");
            }

            if (temperature < -70 || temperature > 50 || humidity < 0 || humidity > 100 || pressure < 730 || pressure > 780)
            {
                throw new ArgumentException(
                    "The following ranges are valid: temperature(-70 - 50), humidity(0 - 100), pressure(730 - 780).");
            }

            Console.WriteLine($"Temperture: {temperature}" +
                    $"\nHumidity: {humidity}" +
                    $"\nPressure: {pressure}");
        }
    }
}
