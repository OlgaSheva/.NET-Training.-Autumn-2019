using System;

namespace WeatherStationEvent
{
    /// <summary>
    /// Class providing additional information about a weather change event.
    /// </summary>
    class WeatherChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the weather parameters.
        /// </summary>
        /// <value>
        /// The weather parameters.
        /// </value>
        public WeatherParameters WeatherParameters { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherChangedEventArgs"/> class.
        /// </summary>
        /// <param name="weatherParameters">The weather parameters.</param>
        public WeatherChangedEventArgs(WeatherParameters weatherParameters)
        {
            WeatherParameters = weatherParameters;
        }
    }
}
