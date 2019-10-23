using System;

namespace WeatherStationEvent
{
    /// <summary>
    /// The statistic report class.
    /// </summary>
    class StatisticReport
    {
        /// <summary>
        /// Gets the weather parameters.
        /// </summary>
        /// <value>
        /// The weather parameters.
        /// </value>
        public WeatherParameters WeatherParameters { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticReport"/> class.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public StatisticReport(WeatherParameters parameters)
        {
            WeatherParameters = parameters;
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

            if (info.WeatherParameters.Temperature < -70 || info.WeatherParameters.Temperature > 50
                || info.WeatherParameters.Humidity < 0 || info.WeatherParameters.Humidity > 100
                || info.WeatherParameters.Pressure < 730 || info.WeatherParameters.Pressure > 780)
            {
                throw new ArgumentException(
                    "The following ranges are valid: temperature(-70 - 50), humidity(0 - 100), pressure(730 - 780).");
            }

            Console.WriteLine($"The temperature has changed by " +
                $"{info.WeatherParameters.Temperature - this.WeatherParameters.Temperature} degrees." +
                $"\nThe humidity has changed by {info.WeatherParameters.Humidity - this.WeatherParameters.Humidity} %." +
                $"\nThe pressure has changed by {info.WeatherParameters.Pressure - this.WeatherParameters.Pressure} mmHg.");

            this.WeatherParameters = new WeatherParameters(
                info.WeatherParameters.Temperature,
                info.WeatherParameters.Humidity,
                info.WeatherParameters.Pressure);
        }
    }
}
