using System;

namespace SimulatedCountdownClock
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();

            TimerObserver observer = new TimerObserver(3);

            timer.TimerOn += observer.Update;

            timer.StartTimer(observer.Seconds);
            timer.StartTimer(4);

            timer.TimerOn -= observer.Update;

            timer.StartTimer(3);

            Console.WriteLine("That's all.");
            Console.ReadKey();
        }
    }
}
