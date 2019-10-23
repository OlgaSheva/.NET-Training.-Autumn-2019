using System;
namespace WeatherStationEvent
{
    /// <summary>
    /// Class providing additional information about a weather change event.
    /// </summary>
    class WeatherChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Creates new temperature.
        /// </summary>
        /// <value>
        /// The new temperature.
        /// </value>
        public int NewTemperature { get; private set; }

        /// <summary>
        /// Creates new humidity.
        /// </summary>
        /// <value>
        /// The new humidity.
        /// </value>
        public int NewHumidity { get; private set; }

        /// <summary>
        /// Creates new pressure.
        /// </summary>
        /// <value>
        /// The new pressure.
        /// </value>
        public int NewPressure { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherChangedEventArgs"/> class.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <param name="humidity">The humidity.</param>
        /// <param name="pressure">The pressure.</param>
        public WeatherChangedEventArgs(int temperature, int humidity, int pressure)
        {
            NewTemperature = temperature;
            NewHumidity = humidity;
            NewPressure = pressure;
        }
    }
}
