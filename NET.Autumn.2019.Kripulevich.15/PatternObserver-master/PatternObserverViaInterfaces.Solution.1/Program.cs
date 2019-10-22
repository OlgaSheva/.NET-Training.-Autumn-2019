using System;
using System.Collections.Generic;

namespace PatternObserverViaInterfaces.Solution._1
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

    //интерфейс класса наблюдателя
    public interface IObserver
    {
        void Update(IObservable sender, TemperatureEventArgs info);
    }

    //интерфейс наблюдаемого класса 
    public interface IObservable
    {
        void Register(IObserver observer);
        void Unregister(IObserver observer);
        void Notify();
    }

    //базовый класс, предоставляющий дополнительную информацию о событии
    // для событий не предоставляющих дополнительную информацию свойство Empty
    public class EventArgs
    {
        public static readonly EventArgs Empty;
    }

    // класс, предоставляющий дополнительную информацию о событии изменения температуры
    public class TemperatureEventArgs : EventArgs
    {
        public int OldTemperature { get; }
        public int NewTemperature { get; }

        public TemperatureEventArgs(int oldTemperature, int newTemperature)
        {
            OldTemperature = oldTemperature;
            NewTemperature = newTemperature;
        }
    }

    public class Cooler : IObserver
    {
        public Cooler(int temperature) => Temperature = temperature;

        public int Temperature { get; private set; }

        public void Update(IObservable sender, TemperatureEventArgs info)
        {
            Console.WriteLine(info.NewTemperature > Temperature
                        ? $"Cooler: On. Changed: old temperature - {info.OldTemperature}, new temperature - {info.NewTemperature}."
                        : $"Cooler: Off. Changed: old temperature - {info.OldTemperature}, new temperature - {info.NewTemperature}.");
        }
    }

    public class Heater : IObserver
    {
        public Heater(int temperature) => Temperature = temperature;

        public int Temperature { get; private set; }

        public void Update(IObservable sender, TemperatureEventArgs info)
        {
            Console.WriteLine(info.NewTemperature < Temperature
            ? $"Heater: On. Changed:{Math.Abs(info.NewTemperature - Temperature)}"
            : $"Heater: Off. Changed:{Math.Abs(info.NewTemperature - Temperature)}");
        }
    }

    public class Thermostat : IObservable
    {
        private readonly List<IObserver> observers;

        private int currentTemperature;
        private int previusTemperature;

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
                    previusTemperature = currentTemperature;
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
                observer.Update(this, new TemperatureEventArgs(previusTemperature, currentTemperature));
            }
        }

        public void Register(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Unregister(IObserver observer)
        {
            observers.Remove(observer);
        }
    }
}