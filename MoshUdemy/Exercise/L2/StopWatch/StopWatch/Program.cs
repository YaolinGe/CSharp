using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ex1, test the stopwatch
            //var stopWatch = new StopWatch();

            //while (true)
            //{
            //    Console.WriteLine("Enter 'start' to start the stopwatch.");
            //    Console.WriteLine("Enter 'stop' to stop the stopwatch.");
            //    Console.WriteLine("Enter 'exit' to exit the program.");

            //    var input = Console.ReadLine();

            //    if (input == "start")
            //    {
            //        stopWatch.Start();
            //        Console.WriteLine("Stopwatch started.");
            //    }
            //    else if (input == "stop")
            //    {
            //        stopWatch.Stop();
            //        Console.WriteLine("Stopwatch stopped.");
            //        Console.WriteLine("Duration: {0}", stopWatch.GetInterval());
            //    }
            //    else if (input == "exit")
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid input.");
            //    }
            //}

            // ex2, test the stackoverflow post
            var post = new StackOverflowPost("Title", "Description");
            post.DisplayPost();
            post.UpVote();
            post.UpVote();
            post.UpVote();
            post.UpVote();
            post.UpVote();
            post.DisplayPost();
        }
    }
}
