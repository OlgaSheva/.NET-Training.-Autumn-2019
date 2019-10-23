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
        private int temperature;

        /// <summary>
        /// Gets the current temperature.
        /// </summary>
        /// <value>
        /// The current temperature.
        /// </value>
        public int Temperature
        {
            get => temperature;
            private set
            {
                temperature = value;
                OnWeatherChanged(new WeatherChangedEventArgs(temperature, Humidity, Pressure));
            }
        }

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
        /// Initializes a new instance of the <see cref="WeatherData"/> class.
        /// </summary>
        public WeatherData()
        {
            Temperature = 15;
            Humidity = 80;
            Pressure = 760;
        }

        /// <summary>
        /// Emulates the weather change.
        /// </summary>
        public void EmulateWeatherChange()
        {
            this.Humidity = random.Next(40, 100);
            this.Pressure = random.Next(756, 766);
            this.Temperature = random.Next(-30, 40);
        }

        protected virtual void OnWeatherChanged(WeatherChangedEventArgs args)
        {
            var temp = WeatherChanged;
            temp?.Invoke(this, new WeatherChangedEventArgs(Temperature, Humidity, Pressure));
        }
    }
}
