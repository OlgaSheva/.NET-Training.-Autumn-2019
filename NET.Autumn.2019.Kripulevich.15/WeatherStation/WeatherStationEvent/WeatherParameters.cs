namespace WeatherStationEvent
{
    public struct WeatherParameters
    {
        /// <summary>
        /// Creates new temperature.
        /// </summary>
        /// <value>
        /// The new temperature.
        /// </value>
        public int Temperature { get; private set; }

        /// <summary>
        /// Creates new humidity.
        /// </summary>
        /// <value>
        /// The new humidity.
        /// </value>
        public int Humidity { get; private set; }

        /// <summary>
        /// Creates new pressure.
        /// </summary>
        /// <value>
        /// The new pressure.
        /// </value>
        public int Pressure { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherChangedEventArgs"/> class.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <param name="humidity">The humidity.</param>
        /// <param name="pressure">The pressure.</param>
        public WeatherParameters(int temperature, int humidity, int pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
        }
    }
}
