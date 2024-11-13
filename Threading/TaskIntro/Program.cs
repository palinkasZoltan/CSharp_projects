using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskIntro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(SimpleMethod);
            task.Start();

            Task<string> taskThatReturns = new Task<string>(TaskThatReturns);
            taskThatReturns.Start();

            taskThatReturns.Wait(); // Wait for the task to complete
            Console.WriteLine(taskThatReturns.Result); // It only has the "Result" property if it is a Task<T>
        }

        private static string TaskThatReturns()
        {
            Thread.Sleep(2000); // To simulate a task which takes some time to complete
            return "Hello";
        }

        private static void SimpleMethod()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
