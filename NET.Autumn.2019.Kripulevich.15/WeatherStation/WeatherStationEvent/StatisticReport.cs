using System;

namespace WeatherStationEvent
{
    /// <summary>
    /// The statistic report class.
    /// </summary>
    class StatisticReport
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

            Console.WriteLine($"The temperature has changed by {info.NewTemperature - Temperature} degrees." +
                $"\nThe humidity has changed by {info.NewHumidity - Humidity} %." +
                $"\nThe pressure has changed by {info.NewPressure - Pressure} mmHg.");

            Temperature = info.NewTemperature;
            Humidity = info.NewHumidity;
            Pressure = info.NewPressure;
        }
    }
}
