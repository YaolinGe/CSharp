using System;
using System.Collections.Generic;

namespace w8
{
    public class Text
    {

        // ex1, check if input numbers separated by - are consecutive or non-consecutive
        public static void ex1()
        {
            Console.WriteLine("Enter numbers separated by -");
            
            var input = Console.ReadLine();
            //Console.WriteLine("Before spliting: " + input);
            var numbers = input.Split('-');
            //Console.WriteLine("After splitting: " + numbers);

            var consecutive = true;
            for (var i = 1; i < numbers.Length; i++)
            {
                if (Convert.ToInt32(numbers[i]) != Convert.ToInt32(numbers[i - 1]) + 1)
                {
                    consecutive = false;
                    break;
                }
            }

            var message = consecutive ? "Consecutive" : "Not Consecutive";
            Console.WriteLine(message);
        }

        // ex2, check if input numbers separated by - are duplicates or not, exit immediately if enter directly
        public static void ex2()
        {
            Console.WriteLine("Enter numbers separated by -");
            var input = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(input))
                return;

            var numbers = input.Split('-');
            var uniques = new List<int>();
            var includesDuplicates = false;
            foreach (var number in numbers)
            {
                if (!uniques.Contains(Convert.ToInt32(number)))
                    uniques.Add(Convert.ToInt32(number));
                else
                {
                    includesDuplicates = true;
                    break;
                }
            }

            if (includesDuplicates)
                Console.WriteLine("Duplicate");
        }

        // ex3, check if user-input time value is valid in 24-hour format
        public static void ex3()
        {
            Console.WriteLine("Enter time value in 24-hour format (e.g. 19:00)");
            var input = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid Time");
                return;
            }

            var components = input.Split(':');
            if (components.Length != 2)
            {
                Console.WriteLine("Invalid Time");
                return;
            }

            try
            {
                var hour = Convert.ToInt32(components[0]);
                var minute = Convert.ToInt32(components[1]);

                if (hour >= 0 && hour <= 23 && minute >= 0 && minute <= 59)
                    Console.WriteLine("Ok");
                else
                    Console.WriteLine("Invalid Time");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Time");
            }
        }

        // ex4, convert user-input string to pascal case
        public static void ex4()
        {
            Console.WriteLine("Enter a few words separated by a space");
            var input = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Error");
                return;
            }

            var words = input.Split(' ');
            var pascalCase = "";
            foreach (var word in words)
            {
                var wordWithPascalCase = char.ToUpper(word[0]) + word.ToLower().Substring(1);
                pascalCase += wordWithPascalCase;
            }

            Console.WriteLine(pascalCase);
        }

        // ex5, count the number of vowels in a user-input string
        public static void ex5()
        {
            Console.WriteLine("Enter a word");
            var input = Console.ReadLine().ToLower();

            var vowels = new List<char>(new char[] { 'a', 'e', 'i', 'o', 'u' });
            var vowelsCount = 0;
            foreach (var character in input)
            {
                if (vowels.Contains(character))
                    vowelsCount++;
            }

            Console.WriteLine(vowelsCount);
        }


        static void Main(string[] args)
        {
            ex5(); 
        }
    }
}
