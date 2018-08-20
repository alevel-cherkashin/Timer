using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Timer
{
    class Timer:ITimer
    {
        int _currentTime;
        int _alarmTime;

        public Timer()
        {
            SetAlarm(2);
            Counter();
        }

        public delegate void DelegateTime();

        public event DelegateTime OnAlarm;

        public void SetAlarm(int minutes)
        {
            _alarmTime = minutes*60;
        }

        private void ShowAlarmTime()
        {
            int min;
            int hour;
            int sec = _alarmTime;
            min = sec / 60;
            hour = min / 60;
            min = min % 60;
            sec = sec % 60;

            Console.SetCursorPosition(0, 2);
            Console.Write($"Alarm time [{hour}: {min}: {sec}]   ");
        }

        public void ShowCurrentTime()
        {
            int min;
            int hour; ;
            int sec = _currentTime;
            min = sec / 60;
            hour = min / 60;
            min = min % 60;
            sec = sec % 60;

            if (min < 10)
            {
                if (sec < 10)
                {
                    Console.SetCursorPosition(21, 2);
                    Console.Write($"Current time [{hour}: {min}: {sec}]");
                }
                else
                {
                    Console.SetCursorPosition(21, 2);
                    Console.Write($"Current time [{hour}: {min}:{sec}]");
                }
            }
            else
            {
                if (sec < 10)
                {
                    Console.SetCursorPosition(21, 2);
                    Console.Write($"Current time [{hour}:{min}: {sec}]");
                }
                Console.SetCursorPosition(21, 2);
                Console.Write($"Current time [{hour}:{min}:{sec}]");
            }
        }

        private void Counter()
        {
            Task.Factory.StartNew(() =>
            {
                ShowAlarmTime();

                do
                {
                    ShowCurrentTime();
                    //Sleep for one second
                    Thread.Sleep(100);
                    //And increment our inner counter
                    _currentTime += 1;

                    if (_alarmTime == _currentTime) OnAlarm?.Invoke();
                } while (true);
            });
        }
    }


}
