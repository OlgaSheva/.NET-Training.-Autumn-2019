using System;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();

            CurrentConditionsReport current = new CurrentConditionsReport();
            StatisticReport statistic = new StatisticReport(10, 80, 756);

            weatherData.Register(current);
            weatherData.Register(statistic);

            weatherData.EmulateWeatherChange();
            weatherData.EmulateWeatherChange();

            Console.ReadKey();
        }
    }
}
