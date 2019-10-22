using System;

namespace PatternObserverViaActionDelegate
{
    static class Program
    {
        static void Main(string[] args)
        {
            Thermostat thermostat = new Thermostat();

            Heater heater = new Heater(30);

            Cooler cooler = new Cooler(40);

            thermostat.observers += heater.OnTemperatureChanged;
            thermostat.observers += cooler.Update;

            thermostat.EmulateTemperatureChange();

            thermostat.observers -= cooler.Update;

            thermostat.EmulateTemperatureChange();

            Console.ReadKey();
        }
    }

    public class Cooler
    {
        public Cooler(int temperature) => Temperature = temperature;

        public int Temperature { get; private set; }

        public void Update(int newTemperature)
        {
            Console.WriteLine(newTemperature > Temperature
                        ? $"Cooler: On. Changed:{Math.Abs(newTemperature - Temperature)}"
                        : $"Cooler: Off. Changed:{Math.Abs(newTemperature - Temperature)}");
        }
    }

    public class Heater
    {
        public Heater(int temperature) => Temperature = temperature;

        public int Temperature { get; private set; }

        public void OnTemperatureChanged(int newTemperature)
        {
            Console.WriteLine(newTemperature < Temperature
                ? $"Heater: On. Changed:{Math.Abs(newTemperature - Temperature)}"
                : $"Heater: Off. Changed:{Math.Abs(newTemperature - Temperature)}");
        }
    }

    public sealed class Thermostat
    {
        public Action<int> observers;

        private int currentTemperature;

        private Random random = new Random(Environment.TickCount);

        public Thermostat()
        {
            currentTemperature = 5;
        }

        public int CurrentTemperature
        {
            get => currentTemperature;
            private set
            {
                if (value != currentTemperature)
                {
                    currentTemperature = value;
                    observers?.Invoke(currentTemperature);
                }
            }
        }

        public void EmulateTemperatureChange()
        {
            this.CurrentTemperature = random.Next(0, 100);
        }
    }
}