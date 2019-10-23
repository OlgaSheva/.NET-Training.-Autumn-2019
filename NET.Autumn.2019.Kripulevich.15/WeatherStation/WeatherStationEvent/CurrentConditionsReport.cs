using System;

namespace WeatherStationEvent
{
    /// <summary>
    /// The current conditions report class.
    /// </summary>
    class CurrentConditionsReport
    {
        /// <summary>
        /// Updates the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="info">The <see cref="WeatherChangedEventArgs"/> instance containing the event data.</param>
        /// <exception cref="ArgumentNullException">
        /// The {nameof(sender)} cannot be null.
        /// or
        /// The {nameof(info)} cannot be null.
        /// </exception>
        /// <exception cref="ArgumentException">The following ranges are valid: temperature(-70 - 50), humidity(0 - 100), pressure(730 - 780).</exception>
        public void Update(object sender, WeatherChangedEventArgs info)
        {
            if (sender == null)
            {
                throw new ArgumentNullException($"The {nameof(sender)} cannot be null.");
            }

            if (info == null)
            {
                throw new ArgumentNullException($"The {nameof(info)} cannot be null.");
            }

            if (info.NewTemperature < -70 || info.NewTemperature > 50
                || info.NewHumidity < 0 || info.NewHumidity > 100
                || info.NewPressure < 730 || info.NewPressure > 780)
            {
                throw new ArgumentException(
                    "The following ranges are valid: temperature(-70 - 50), humidity(0 - 100), pressure(730 - 780).");
            }

            Console.WriteLine($"Temperture: {info.NewTemperature}" +
                    $"\nHumidity: {info.NewHumidity}" +
                    $"\nPressure: {info.NewPressure}");
        }
    }
}
