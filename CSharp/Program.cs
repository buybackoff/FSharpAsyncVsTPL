using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CSharp {
    class Program {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            var sum = 0;
            var t = Task.Run(async () =>
            {
                while (sum < 10000000)
                {
                    var r = await Task.FromResult(1);  //await Task.Run(() => 1);// Task.FromResult(1);
                    sum += r;
                }
                
                return sum;
            });
            t.Wait();
            sw.Stop();
            Console.WriteLine("Sum:" + t.Result);
            Console.WriteLine("Elapsed:" + sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
