using System;
using System.Collections.Generic;

namespace PatternObserverViaInterfaces.Solution._2
{
    static class Program
    {
        static void Main(string[] args)
        {
            Thermostat thermostat = new Thermostat();

            Heater heater = new Heater(30);

            Cooler cooler = new Cooler(40);

            thermostat.Register(heater);

            thermostat.Register(cooler);

            thermostat.EmulateTemperatureChange();

            thermostat.Unregister(cooler);

            thermostat.EmulateTemperatureChange();

            Console.ReadKey();
        }
    }
   
    /// <summary>
    /// The observer class interface.
    /// </summary>
    public interface IObserver
    {
        void Update(IObservable sender, int info);
    }

    //интерфейс наблюдаемого класса     
    /// <summary>
    /// The observable class interface.
    /// </summary>
    public interface IObservable
    {
        void Register(IObserver observer);
        void Unregister(IObserver observer);
        void Notify();
    }

    /// <summary>
    /// The cooler.
    /// </summary>
    /// <seealso cref="PatternObserverViaInterfaces.Solution._2.IObserver" />
    public class Cooler : IObserver
    {
        public Cooler(int temperature) => Temperature = temperature;

        public int Temperature { get; private set; }
        
        public void Update(IObservable sender, int newTemperature)
        {
            if (sender == null)
            {
                throw new ArgumentNullException($"The {nameof(sender)} cannot be null.");
            }

            Console.WriteLine(newTemperature > Temperature
                        ? $"Cooler: On. Changed:{Math.Abs(newTemperature - Temperature)}"
                        : $"Cooler: Off. Changed:{Math.Abs(newTemperature - Temperature)}");
        }
    }

    /// <summary>
    /// The heater.
    /// </summary>
    /// <seealso cref="PatternObserverViaInterfaces.Solution._2.IObserver" />
    public class Heater : IObserver
    {
        public Heater(int temperature) => Temperature = temperature;

        public int Temperature { get; private set; }

        public void Update(IObservable sender, int newTemperature)
        {
            if (sender == null)
            {
                throw new ArgumentNullException($"The {nameof(sender)} cannot be null.");
            }

            Console.WriteLine(newTemperature < Temperature
            ? $"Heater: On. Changed:{Math.Abs(newTemperature - Temperature)}"
            : $"Heater: Off. Changed:{Math.Abs(newTemperature - Temperature)}");
        }
    }

    /// <summary>
    /// The thermostat.
    /// </summary>
    /// <seealso cref="PatternObserverViaInterfaces.Solution._2.IObservable" />
    public class Thermostat : IObservable
    {
        private readonly List<IObserver> observers;

        private int currentTemperature;

        private Random random = new Random(Environment.TickCount);

        public Thermostat()
        {
            currentTemperature = 5;
            observers = new List<IObserver>();
        }

        public int CurrentTemperature
        {
            get => currentTemperature;
            private set
            {
                if (value != currentTemperature)
                {
                    currentTemperature = value;
                    Notify();
                }
            }
        }

        public void EmulateTemperatureChange()
        {
            this.CurrentTemperature = random.Next(0, 100);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(this, currentTemperature);
            }
        }

        public void Register(IObserver observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException($"The {nameof(observer)} cannot be null.");
            }

            observers.Add(observer);
        }

        public void Unregister(IObserver observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException($"The {nameof(observer)} cannot be null.");
            }

            observers.Remove(observer);
        }
    }
}