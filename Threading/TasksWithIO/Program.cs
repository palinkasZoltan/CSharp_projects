using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TasksWithIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<string> task = Task.Factory.StartNew<string>(() => GetPosts("https://jsonplaceholder.typicode.com/posts"));

            SomethingElse();
            // task.Wait(); // Wait for the task to complete

            try
            {
                Console.Write(task.Result); // Wait for the task to complete if it isn't already - blocks the main thread
            }
            // there could be exceptions while executing
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SomethingElse()
        {
            // Dummy Implementation
        }

        private static string GetPosts(string url)
        {
            // throw null;
            using(WebClient client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }
    }
}
