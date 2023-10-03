using System;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            var number = 2;
            Console.WriteLine(number);
            var count = 10;
            var totalPrice = 20.95f;
            Console.WriteLine("Total number is {0}", totalPrice);
            var character = 'A';
            var firstName = "Mosh";
            var isWorking = false;
            Console.WriteLine("Here comes all the numbers {0}, {1}, {2}, {3}, {4}",
                totalPrice, character, firstName, isWorking, count);
            Console.Beep();
            int Number = 1;
            const float Pi = 3.14f; 
            Console.WriteLine(Number);
            Console.WriteLine("Pi value is ");           
            Console.WriteLine("Wait here!");
            Console.WriteLine("Enter a number: ");
            number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("You entered: " + number);
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Your name is: " + name);
            Console.WriteLine("Hello " + name);
            Console.WriteLine("Hello {0}", name);
            Console.WriteLine("Hello {0}, your number is {1}", name, number);
            Console.WriteLine("Hello {0}, your number is {1}, and Pi value is {2}", name, number, Pi);
            Console.WriteLine("Hello {0}, your number is {1}, and Pi value is {2}", name, number, Pi.ToString("F2"));
            Console.WriteLine("Hello {0}, your number is {1}, and Pi value is {2}", name, number, Pi.ToString("C2"));
            Console.WriteLine("Hello {0}, your number is {1}, and Pi value is {2}", name, number, Pi.ToString("P2"));
            Console.WriteLine("Hello {0}, your number is {1}, and Pi value is {2}", name, number, Pi.ToString("N2"));
            Console.WriteLine("Wait here!");
        }
    }
}
