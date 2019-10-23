using System;
using System.Threading;

namespace SimulatedCountdownClock
{
    public class Timer
    {
        public event EventHandler<TimerOnEventArgs> TimerOn = delegate { };

        private int seconds;

        public int Seconds
        {
            get => seconds;
            private set
            {
                seconds = value;
                OnTimerOn(new TimerOnEventArgs(seconds));
            }
        }

        public void StartTimer(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            Seconds = seconds;
        }

        protected virtual void OnTimerOn(TimerOnEventArgs timerOn)
        {
            var temp = TimerOn;
            temp?.Invoke(this, new TimerOnEventArgs(seconds));
        }
    }
}
