using System;

namespace SimulatedCountdownClock
{
    public class TimerOnEventArgs : EventArgs
    {
        public int Seconds { get; private set; }

        public TimerOnEventArgs(int seconds)
        {
            Seconds = seconds;
        }
    }
}
