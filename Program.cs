using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();

            timer.OnAlarm += RunWashingMachine;
            timer.OnAlarm += RunConditioner;

            Console.Read();
        }


        static void RunConditioner()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("RunConditioner");
        }
        static void RunWashingMachine()
        {
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("RunWashingMachine");
        }
    }
}
