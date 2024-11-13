using System;
using System.Threading;

namespace ThreadPoolDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // This is on the main thread, so it should be false
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
            Employee employee = new Employee
            {
                Name = "John Doe",
                CompanyName = "Microsoft"
            };

            int processorCount = Environment.ProcessorCount;

            ThreadPool.SetMaxThreads(processorCount * 2, processorCount * 2);

            int workerThreads = 0; 
            int completionPortThreads = 0;
            ThreadPool.GetMinThreads(out workerThreads, out completionPortThreads);

            ThreadPool.QueueUserWorkItem(new WaitCallback(DisplayEmployeeInfo), employee);

            Console.ReadKey();
        }

        private static void DisplayEmployeeInfo(object employee)
        {
            // This is called from a threadpool thread, so it should be true
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
            Employee emp = employee as Employee;
            Console.WriteLine("Person name is {0} and company name is {1}", emp.Name, emp.CompanyName);
        }
    }
}
