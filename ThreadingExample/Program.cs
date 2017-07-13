using System;
using System.Threading;

namespace ThreadingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            autoEvent = new AutoResetEvent(false);
            Console.WriteLine("Main thread starting worker thread...");
            Thread t = new Thread(DoWork);
            t.Start();

            Console.WriteLine("Main thread sleeping for 10 second...");
            Thread.Sleep(10000);

            Console.WriteLine("Main thread signaling worker thread End...");

            autoEvent.Set();


            Console.ReadKey();
        }

        static AutoResetEvent autoEvent;


        static void DoWork()
        {
            Console.WriteLine("     Worker thread started, now waiting on event...");
            autoEvent.WaitOne();
            Console.WriteLine("    Worker thread reactivated, now exiting...");
        }
    }
}
