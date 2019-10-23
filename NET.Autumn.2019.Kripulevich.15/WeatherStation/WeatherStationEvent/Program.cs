using System;

namespace WeatherStationEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();

            CurrentConditionsReport current = new CurrentConditionsReport();
            StatisticReport statistic = new StatisticReport(new WeatherParameters(10, 80, 756));

            weatherData.WeatherChanged += current.Update;
            weatherData.WeatherChanged += statistic.Update;

            weatherData.EmulateWeatherChange();
            weatherData.EmulateWeatherChange();

            Console.ReadKey();
        }
    }
}
