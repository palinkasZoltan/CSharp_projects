using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharedResources
{
    internal class Program
    {
        private static bool isCompleted;
        static readonly object lockCompleted = new object();

        static void Main(string[] args)
        {
            Thread workerThread = new Thread(HelloWorld);

            

            // Worker thread
            workerThread.Start();

            // Main Thread
            HelloWorld();
        }

        private static void HelloWorld()
        {
            // Locking is necessary when working with shared resources
            lock (lockCompleted)
            {
                if (!isCompleted)
                {
                    Console.WriteLine("Hello, World should print only once");
                    isCompleted = true;
                }
            }
        }
    }
}
