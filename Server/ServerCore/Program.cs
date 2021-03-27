using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class Program
    {
        volatile static bool _stop = false;

        static void ThreadMain()
        {
            Console.WriteLine("Start Thread!");

            while(_stop == false)
            {
                // wait stop signal
            }

            Console.WriteLine("Stop Thread!");
        }

        static void Main(string[] args)
        {
            Task t = new Task(ThreadMain);
            t.Start();

            Thread.Sleep(1000);

            _stop = true;

            Console.WriteLine("Stop Call");
            Console.WriteLine("Waiting End");

            t.Wait();

            Console.WriteLine("Success End");
        }
    }
}
