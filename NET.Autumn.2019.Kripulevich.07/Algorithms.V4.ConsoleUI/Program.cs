using System;
using Algorithms.V4.GcdImplementations;
using Algorithms.V4.Interfaces;
using Algorithms.V4.StopWatcherImplementations;
using Algorithms.V4.LoggerImplementations;
using Microsoft.Extensions.DependencyInjection;

namespace Algorithms.V4.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            IAlgorithm algorithm = serviceProvider.GetService<IAlgorithm>();

            int a = -12, b = 120, c = 40, d = -40;
            Console.WriteLine($"GCD({a}, {b}) = {algorithm.Calculate(a, b).ToString()}.");

            AlgorithmDecorator gcdAlgorithm = serviceProvider.GetService<AlgorithmDecorator>();
            
            int gcd = gcdAlgorithm.Calculate(a, b);
            Console.WriteLine($"GCD({a}, {b}) = {gcd}. Algorithms time: {((GCD)gcdAlgorithm).Milliseconds.ToString()} ms.");

            gcd = gcdAlgorithm.Calculate(a, b, c);
            Console.WriteLine($"GCD({a}, {b}, {c}) = {gcd}. Algorithms time: {((GCD)gcdAlgorithm).Milliseconds.ToString()} ms.");

            gcd = gcdAlgorithm.Calculate(a, b, c, d);
            Console.WriteLine($"GCD({a}, {b}, {c}, {d}) = {gcd}. Algorithms time: {((GCD)gcdAlgorithm).Milliseconds.ToString()} ms.");

            Console.ReadKey();
        }

        private static IServiceProvider CreateServiceProvider()
        {
            return new ServiceCollection()
                .AddSingleton<ILogger, Logger>()
                .AddTransient<IStopWatcher, StopWatcher>()
                .AddTransient<IAlgorithm, EuclideanAlgorithm>()
                .AddTransient<AlgorithmDecorator, GCD>()
                .BuildServiceProvider();
        }
    }
}
