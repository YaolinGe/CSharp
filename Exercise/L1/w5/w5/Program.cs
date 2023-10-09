using System;
using System.Xml;

namespace w5
{
    internal class Loop
    {
        /// <summary>
        /// Exercise 1, count the number of numbers divisible by 3 between 1 and 100
        /// </summary>
        public static void Exercise1()
        {
            int count = 0;
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0)
                {
                    count++;
                    Console.WriteLine(i + " / 3 = " + (i / 3));
                }
            }
            Console.WriteLine(count);
        }

        /// <summary>
        /// Exercise 2, sum of all user typed input
        /// </summary>
        public static void Exercise2()
        {
            double sum = .0;
            while (true)
            {
                Console.Write("Enter a number: ");
                var input = Console.ReadLine();
                if (input == "ok")
                {
                    break;
                }
                sum += Convert.ToDouble(input);
            }
            Console.WriteLine("Sum of all numbers is " + sum);
        }

        /// <summary>
        /// Exercise 3, factorial of a number
        /// </summary>
        public static void Exercise3()
        {
            Console.Write("Enter a number: ");
            var number = Convert.ToInt32(Console.ReadLine());
            var factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }

            for (int i = number; i > 0; i--)
            {
                if (i == 1)
                {
                    Console.Write(i);
                    break;
                }
                Console.Write(i + " x ");
            }
            Console.WriteLine(" = " + factorial);
        }

        // Exercise 4, guessing game
        public static void Exercise4()
        {
            var random = new Random();
            var number = random.Next(1, 10);
            var count = 0;
            while (true)
            {
                Console.Write("Guess the number: ");
                var guess = Convert.ToInt32(Console.ReadLine());
                count++;
                if (guess == number)
                {
                    Console.WriteLine("You won!");
                    break;
                }

                if (count == 4)
                {
                    Console.WriteLine("You lost!");
                    break;
                }
            }
        }

        // Exercise 5, find the maximum number of a list of numbers typed by the user with comma separation
        public static void Exercise5()
        {
            Console.Write("Enter a list of numbers separated by comma: ");
            var input = Console.ReadLine();
            var numbers = input.Split(',');
            var max = Convert.ToInt32(numbers[0]);
            foreach (var number in numbers)
            {
                if (Convert.ToInt32(number) > max)
                {
                    max = Convert.ToInt32(number);
                }
            }
            Console.WriteLine("Max number is " + max);
        }

        static void Main(string[] args)
        {
            Exercise5();
        }
    }
}
