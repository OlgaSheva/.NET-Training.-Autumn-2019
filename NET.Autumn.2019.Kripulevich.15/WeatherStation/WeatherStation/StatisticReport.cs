using System;
using WeatherStationCA.Interfaces;

namespace WeatherStation
{
    /// <summary>
    /// The statistic report class.
    /// </summary>
    /// <seealso cref="WeatherStationCA.Interfaces.IObserver" />
    class StatisticReport : IObserver
    {
        /// <summary>
        /// Gets the temperature.
        /// </summary>
        /// <value>
        /// The temperature.
        /// </value>
        public int Temperature { get; private set; }

        /// <summary>
        /// Gets the humidity.
        /// </summary>
        /// <value>
        /// The humidity.
        /// </value>
        public int Humidity { get; private set; }

        /// <summary>
        /// Gets the pressure.
        /// </summary>
        /// <value>
        /// The pressure.
        /// </value>
        public int Pressure { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticReport"/> class.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <param name="humidity">The humidity.</param>
        /// <param name="pressure">The pressure.</param>
        public StatisticReport(int temperature, int humidity, int pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
        }

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

            Console.WriteLine($"The temperature has changed by {temperature - Temperature} degrees." +
                $"\nThe humidity has changed by {humidity - Humidity} %." +
                $"\nThe pressure has changed by {pressure - Pressure} mmHg.");

            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
        }
    }
}
