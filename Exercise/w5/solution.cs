// Here comes my code
using System;

namespace ControlFlow
{
    public class Loops
    {
        /// Exercise 1, a program to count how many numbers between 1 and 100 are divisible by 3 with no remainder.
        public void Exercise1()
        {
            var count = 0;
            for (var i = 1; i <= 100; i++)
            {
                if (i%3 == 0)
                    count++;
            }
            Console.WriteLine("There are {0} numbers divisible by 3 between 1 and 100.", count);
        }


    }

}