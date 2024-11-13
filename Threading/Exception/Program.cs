using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Demo();
        }

        private static void Demo()
        {
            try
            {
                // This will be executed on the main thread, so it can be caught
                // Execute();

                // This will be executed on a worker thread, so it can't be caught
                new Thread(Execute).Start();

                // Reason:
                // Exception handling is not possible across threads.
                // The main thread can't catch exceptions thrown by worker threads.
                // The main thread can catch exceptions thrown by the main thread.
                // The worker thread can catch exceptions thrown by the worker thread.
            }
            // Main thread executes this catch block
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Execute()
        {
            // Solution is to put the try-catch block inside the method
            // try
            // {
            //     throw new Exception("Exception thrown from worker thread");
            // }
            // catch (System.Exception ex)
            // {
            //     Console.WriteLine(ex.Message);
            // }

            throw null;
        }
    }
}
