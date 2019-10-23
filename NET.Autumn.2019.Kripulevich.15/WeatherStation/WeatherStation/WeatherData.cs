using System;
using System.Collections.Generic;
using WeatherStationCA.Interfaces;

namespace WeatherStation
{
    /// <summary>
    /// The weather data class.
    /// </summary>
    /// <seealso cref="WeatherStationCA.Interfaces.IObservable" />
    public class WeatherData : IObservable
    {
        private Random random = new Random(Environment.TickCount);
        private int temperature;
        private readonly List<IObserver> observers = new List<IObserver>();

        /// <summary>
        /// Gets the temperature.
        /// </summary>
        /// <value>
        /// The temperature.
        /// </value>
        public int Temperature
        {
            get => temperature;
            private set
            {
                temperature = value;
                Notify();
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
        /// Registers the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <exception cref="ArgumentNullException">The {nameof(observer)} cannot be null.</exception>
        public void Register(IObserver observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException($"The {nameof(observer)} cannot be null.");
            }

            observers.Add(observer);
        }

        /// <summary>
        /// Unregisters the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <exception cref="ArgumentNullException">The {nameof(observer)} cannot be null.</exception>
        public void Unregister(IObserver observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException($"The {nameof(observer)} cannot be null.");
            }

            observers.Remove(observer);
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

        /// <summary>
        /// Notifies this instance.
        /// </summary>
        private void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(this, Temperature, Humidity, Pressure);
            }
        }
    }
}
