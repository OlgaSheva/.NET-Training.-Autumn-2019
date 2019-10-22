using System;
using System.Reflection;

namespace PatternObserverViaEvents
{
    static class Program
    {
        static void Main(string[] args)
        {
            Thermostat thermostat = new Thermostat();

            Heater heater = new Heater(30);

            Cooler cooler = new Cooler(40);

            thermostat.TemperatureChanged += heater.OnTemperatureChanged;
            thermostat.TemperatureChanged += cooler.Update;

            thermostat.EmulateTemperatureChange();

            thermostat.TemperatureChanged -= cooler.Update;

            thermostat.EmulateTemperatureChange();

            Type type = thermostat.GetType();

            foreach (var t in type.GetMethods(BindingFlags.Instance | BindingFlags.Public|BindingFlags.NonPublic ))
            {
                Console.WriteLine(t.Name);
            }
        }
    }

    /// <summary>
    /// Class providing additional information about a temperature change event.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class TemperatureChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Creates new temperature.
        /// </summary>
        /// <value>
        /// The new temperature.
        /// </value>
        public int NewTemperature { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TemperatureChangedEventArgs"/> class.
        /// </summary>
        /// <param name="newTemperature">The new temperature.</param>
        public TemperatureChangedEventArgs(int newTemperature)
        {
            NewTemperature = newTemperature;
        }
    }

    /// <summary>
    /// The cooler.
    /// </summary>
    public class Cooler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cooler"/> class.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        public Cooler(int temperature) => Temperature = temperature;

        /// <summary>
        /// Gets the temperature.
        /// </summary>
        /// <value>
        /// The temperature.
        /// </value>
        public int Temperature { get; private set; }

        /// <summary>
        /// Updates the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="info">The <see cref="TemperatureChangedEventArgs"/> instance containing the event data.</param>
        /// <exception cref="ArgumentNullException">
        /// The {nameof(sender)} cannot be null.
        /// or
        /// The {nameof(info)} cannot be null.
        /// </exception>
        public void Update(object sender, TemperatureChangedEventArgs info)
        {
            if (sender == null)
            {
                throw new ArgumentNullException($"The {nameof(sender)} cannot be null.");
            }

            if (info == null)
            {
                throw new ArgumentNullException($"The {nameof(info)} cannot be null.");
            }

            Console.WriteLine(info.NewTemperature > Temperature
                        ? $"Cooler: On. Changed:{Math.Abs(info.NewTemperature - Temperature)}"
                        : $"Cooler: Off. Changed:{Math.Abs(info.NewTemperature - Temperature)}");
        }
    }

    /// <summary>
    /// The heater.
    /// </summary>
    public class Heater
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Heater"/> class.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        public Heater(int temperature) => Temperature = temperature;

        /// <summary>
        /// Gets the temperature.
        /// </summary>
        /// <value>
        /// The temperature.
        /// </value>
        public int Temperature { get; private set; }

        /// <summary>
        /// Called when [temperature changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="info">The <see cref="TemperatureChangedEventArgs"/> instance containing the event data.</param>
        /// <exception cref="ArgumentNullException">
        /// The {nameof(sender)} cannot be null.
        /// or
        /// The {nameof(info)} cannot be null.
        /// </exception>
        public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs info)
        {
            if (sender == null)
            {
                throw new ArgumentNullException($"The {nameof(sender)} cannot be null.");
            }

            if (info == null)
            {
                throw new ArgumentNullException($"The {nameof(info)} cannot be null.");
            }

            Console.WriteLine(info.NewTemperature < Temperature
                ? $"Heater: On. Changed:{Math.Abs(info.NewTemperature - Temperature)}"
                : $"Heater: Off. Changed:{Math.Abs(info.NewTemperature - Temperature)}");
        }
    }

    /// <summary>
    /// The thermostat.
    /// </summary>
    public sealed class Thermostat
    {
        /// <summary>
        /// Occurs when [temperature changed].
        /// </summary>
        public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged = delegate { };

        private int currentTemperature;

        private Random random = new Random(Environment.TickCount);

        /// <summary>
        /// Initializes a new instance of the <see cref="Thermostat"/> class.
        /// </summary>
        public Thermostat()
        {
            currentTemperature = 5;
        }

        /// <summary>
        /// Gets the current temperature.
        /// </summary>
        /// <value>
        /// The current temperature.
        /// </value>
        public int CurrentTemperature
        {
            get => currentTemperature;
            private set
            {
                if (value != currentTemperature)
                {
                    currentTemperature = value;
                    OnTemperatureChanged(new TemperatureChangedEventArgs(currentTemperature));
                }
            }
        }

        /// <summary>
        /// Emulates the temperature change.
        /// </summary>
        public void EmulateTemperatureChange()
        {
            this.CurrentTemperature = random.Next(0, 100);
        }

        private void OnTemperatureChanged(TemperatureChangedEventArgs args)
        {
            var temp = TemperatureChanged;
            temp?.Invoke(this, new TemperatureChangedEventArgs(currentTemperature));
        }
    }
}
