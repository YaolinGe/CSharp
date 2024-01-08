using System;
using System.Collections.Generic;
using System.Linq;

namespace w6
{
    internal class ArrayList
    {
        // ex1, display names for Facebook names
        public static void ex1()
        {
            Console.WriteLine("Enter names: ");
            var count = 0;
            var names = new List<string>();
            while (true)
            {
                var input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                {
                    break;
                }
                names.Add(input);
                count++; 
            }

            var namesLength = names.Count;
            if (namesLength == 1)
            {
                Console.WriteLine("{0} likes your post", names[0]);
            }
            else if (namesLength == 2)
            {
                Console.WriteLine("{0} and {1} like your post", names[0], names[1]);
            }
            else if (namesLength > 2)
            {
                Console.WriteLine("{0}, {1} and {2} others like your post", names[0], names[1], namesLength - 2);
            }
            else
            {
                Console.WriteLine("");
            }
        }

        // ex2, reverse name 
        public static void ex2()
        {
            Console.WriteLine("Enter your name: ");
            var input = Console.ReadLine();
            var name = new char[input.Length];
            for (var i = input.Length; i > 0; i--)
            {
                name[input.Length - i] = input[i - 1];
            }
            var reversed = new string(name);
            Console.WriteLine("Reversed name: {0}", reversed);
        }

        // ex3, check for duplicates and sort the numeric array
        public static void ex3()
        {
            Console.WriteLine("Enter 5 unique numbers: ");
            var numbers = new List<int>();
            var count = 0; 
            while (true)
            {
                if (count == 5)
                {
                    numbers.Sort();
                    Console.WriteLine("Sorted numbers: ");
                    foreach (var num in numbers)
                    {
                        Console.WriteLine(num);
                    }
                    break;
                }

                var number = Convert.ToInt32(Console.ReadLine());
                if (numbers.Contains(number))
                {
                    Console.WriteLine("Number already exists, try again");
                    continue;
                }
                numbers.Add(number);
                count++; 
            }
        }

        // ex4, display unique numbers after the user typing multiple numbers with Quit to exit
        public static void ex4()
        {
            Console.WriteLine("Enter a few numbers (or 'Quit' to exit): ");
            var numbers = new List<int>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    break;
                }
                numbers.Add(Convert.ToInt32(input));
            }

            var uniqueNumbers = new List<int>();
            foreach (var num in numbers)
            {
                if (!uniqueNumbers.Contains(num))
                {
                    uniqueNumbers.Add(num);
                }
            }

            Console.WriteLine("Unique numbers: ");
            foreach (var num in uniqueNumbers)
            {
                Console.WriteLine(num);
            }
        }

        // ex5, ask the user to enter a list of comma separated numbers and display the smallest 3 elements the list, if the user enters less than 5 numbers, display "Invalid List" message
        public static void ex5()
        {
            Console.WriteLine("Enter a list of comma separated numbers: ");
            var input = Console.ReadLine();
            var numbers = new List<int>();
            foreach (var num in input.Split(','))
            {
                numbers.Add(Convert.ToInt32(num));
            }

            if (numbers.Count < 5)
            {
                Console.WriteLine("Invalid List");
            }
            else
            {
                var smallestNumbers = new List<int>();
                while (smallestNumbers.Count < 3)
                {
                    var min = numbers[0];
                    foreach (var num in numbers)
                    {
                        if (num < min)
                        {
                            min = num;
                        }
                    }
                    smallestNumbers.Add(min);
                    numbers.Remove(min);
                }

                Console.WriteLine("The 3 smallest numbers are: ");
                foreach (var num in smallestNumbers)
                {
                    Console.WriteLine(num);
                }
            }
        }

        static void Main(string[] args)
        {
            ex5(); 
        }
    }
}
