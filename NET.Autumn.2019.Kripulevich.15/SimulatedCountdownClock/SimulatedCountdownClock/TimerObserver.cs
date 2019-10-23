using System;

namespace SimulatedCountdownClock
{
    public class TimerObserver
    {
        public int Seconds { get; private set; }

        public TimerObserver(int seconds)
        {
            Seconds = seconds;
        }

        public void Update(object sender, TimerOnEventArgs info)
        {
            if (sender == null)
            {
                throw new ArgumentNullException($"The {nameof(sender)} cannot be null.");
            }

            if (info == null)
            {
                throw new ArgumentNullException($"The {nameof(info)} cannot be null.");
            }

            Console.WriteLine($"The timer for observer worked for {info.Seconds} seconds.");
        }
    }
}
