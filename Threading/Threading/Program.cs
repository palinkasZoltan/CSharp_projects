using System;
using System.Threading;

namespace Threading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread workerThread = new Thread(WriteOnNewThread);
            workerThread.Name = "Worker Thread";
            workerThread.Start();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Main Thread: {0}", i);
                Thread.Sleep(100);
            }
        }

        private static void WriteOnNewThread()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Worker Thread: {0}", i);
                Thread.Sleep(100);
            }
        }
    }
}
