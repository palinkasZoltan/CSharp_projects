using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskChaining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task<string> antecedent = Task.Run(() => DateTime.Today.ToShortDateString());

            Task<string> continuation = antecedent.ContinueWith((task) =>
            {
                return string.Format("Today is {0}", task.Result);
            });
        }
    }
}
