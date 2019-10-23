using System;

namespace WeatherStationEvent
{
    /// <summary>
    /// The weather data.
    /// </summary>
    class WeatherData
    {
        /// <summary>
        /// Occurs when [weather changed].
        /// </summary>
        public event EventHandler<WeatherChangedEventArgs> WeatherChanged = delegate { };

        private Random random = new Random(Environment.TickCount);
        private WeatherParameters weatherParameters;

        /// <summary>
        /// Gets the weather parameters.
        /// </summary>
        /// <value>
        /// The weather parameters.
        /// </value>
        public WeatherParameters WeatherParameters
        {
            get => weatherParameters;
            private set
            {
                weatherParameters = value;
                OnWeatherChanged(new WeatherChangedEventArgs(weatherParameters));
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherData"/> class.
        /// </summary>
        public WeatherData()
        {
            WeatherParameters = new WeatherParameters(15, 80, 760);
        }

        /// <summary>
        /// Emulates the weather change.
        /// </summary>
        public void EmulateWeatherChange()
        {
            WeatherParameters = new WeatherParameters(
                random.Next(-30, 40),
                random.Next(40, 100), 
                random.Next(756, 766));
        }

        protected virtual void OnWeatherChanged(WeatherChangedEventArgs args)
        {
            var temp = WeatherChanged;
            temp?.Invoke(this, new WeatherChangedEventArgs(weatherParameters));
        }
    }
}
