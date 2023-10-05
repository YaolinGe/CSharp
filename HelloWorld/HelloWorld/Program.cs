using System;
using System.Security.Cryptography.X509Certificates;
using HelloWorld.Math;

namespace HelloWorld
{
    public enum ShippingMethod
    {
        RegularAirMail = 1,
        RegisteredAirMail = 2,
        Express = 3
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Enums
            var method = ShippingMethod.Express;
            Console.WriteLine((int)method);

            var methodId = 3; 
            Console.WriteLine((ShippingMethod)methodId);

            Console.WriteLine(method.ToString());
            Console.WriteLine(method);
            var methodName = "Express";
            var shippingMethod = (ShippingMethod)Enum.Parse(typeof(ShippingMethod), methodName);

            //int number; 
            //string firstName = "Mosh";
            //string lastName = "Hamedani";
            //var fullName = firstName + " " + lastName;
            //var myFullName = string.Format("My name is {0} {1}", firstName, lastName);
            //var names = new string[3] { "John", "Jack", "Mary" };
            //var formattedNames = string.Join(",", names); 
            //Console.WriteLine(formattedNames);

            //var text = "Hi John\nLook into the following paths\nc:\\folder1\\folder2\nc:\\folder3\\folder4";
            //Console.WriteLine(text);

            //var text2 = @"Hi John
            //            Look into the following paths
            //            c:\folder1\folder2
            //            c:\folder3\folder4";

            //// Arrays
            //int[] numbers = new int[3];
            //numbers[0] = 1;
            //numbers[1] = 2;
            //numbers[2] = 3;
            //Console.WriteLine(numbers[0]);
            //Console.WriteLine(numbers[1]);
            //Console.WriteLine(numbers[2]);

            //var numbers2 = new int[3] { 1, 2, 3 };
            //Console.WriteLine(numbers2[0]);
            //Console.WriteLine(numbers2[1]);
            //Console.WriteLine(numbers2[2]);

            ////Loop through array
            //for (int i = 0; i < numbers2.Length; i++)
            //{
            //    Console.WriteLine(numbers2[i]);
            //}

            //var flags = new bool[3];
            //flags[0] = true;
            //Console.WriteLine(flags[0]);
            //Console.WriteLine(flags[1]);
            //Console.WriteLine(flags[2]);

            //var names = new string[3] { "Jack", "John", "Mary" };
            //Console.WriteLine(names[0]);
            //Console.WriteLine(names[1]);
            //Console.WriteLine(names[2]);

            //// Classes and Objects
            //var john = new Person();
            //john.FirstName = "John";
            //john.LastName = "Smith";
            //john.Introduce();

            //Calculator calculator = new Calculator();
            //var  result = calculator.Add(1, 2); 
            //Console.WriteLine(result);

            //// Arithemtic operation
            //var a = 1;
            //var b = 2; 
            //Console.WriteLine(a + b);
            //Console.WriteLine(a / b);
            //Console.WriteLine((float)a / b);
            //Console.WriteLine(a % b);
            //Console.WriteLine((float)a / (float)b);
            //var c = 3; 

            //Console.WriteLine(a + b * c);
            //Console.WriteLine((a + b) * c);

            // Comparison operation
            //Console.WriteLine(a > b);
            //Console.WriteLine(a == b);
            //Console.WriteLine(!(a != b));
            //Console.WriteLine(a <= b);
            //Console.WriteLine(a >= b);
            //Console.WriteLine(a != b);
            //Console.WriteLine(c > b && c > a);
            //Console.WriteLine(c > b && c == a);
            //Console.WriteLine(c > b || c == a);
            //Console.WriteLine(!(c > b || c == a));


            //int a = 1;
            //int b = a++; 
            //Console.WriteLine("a: {0}, b: {1}", a, b);

            //int c = ++a; 
            //Console.WriteLine("a: {0}, c: {1}", a, c);

            //// Type Conversion
            //byte b = 1;
            //int i = b;
            //Console.WriteLine("b: {0}, i: {1}", b, i);

            //int j = 1000;
            //byte c = (byte) j;
            //Console.WriteLine("j: {0}, c: {1}", j, c);

            //try
            //{
            //    var number = "1234";
            //    byte k = Convert.ToByte(number);
            //    Console.WriteLine("number: {0}, k: {1}", number, k);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("The number could not be converted to a byte. !");
            //}

            //try
            //{
            //    string str = "true"; 
            //    bool d = Convert.ToBoolean(str);
            //    Console.WriteLine("str: {0}, c: {1}", str, d);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}


            //const float Pi = 3.14f;
            //int i = 1;
            //byte b = (byte) i;
            //Console.WriteLine("{0} {1}", i, b);
            //Console.WriteLine("Hello World");
            //var number = 2;
            //Console.WriteLine(number);
            //var count = 10;
            //var totalPrice = 20.95f;
            //Console.WriteLine("Total number is {0}", totalPrice);
            //var character = 'A';
            //var firstName = "Mosh";
            //var isWorking = false;
            //Console.WriteLine("Here comes all the numbers {0}, {1}, {2}, {3}, {4}",
            //    totalPrice, character, firstName, isWorking, count);
            //Console.Beep();
            //int Number = 1;
            //const float Pi = 3.14f; 
            //Console.WriteLine(Number);
            //Console.WriteLine("Pi value is ");           
            //Console.WriteLine("Wait here!");
            //Console.WriteLine("Enter a number: ");
            //number = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("You entered: " + number);
            //Console.WriteLine("Enter your name: ");
            //string name = Console.ReadLine();
            //Console.WriteLine("Your name is: " + name);
            //Console.WriteLine("Hello " + name);
            //Console.WriteLine("Hello {0}", name);
            //Console.WriteLine("Hello {0}, your number is {1}", name, number);
            //Console.WriteLine("Hello {0}, your number is {1}, and Pi value is {2}", name, number, Pi);
            //Console.WriteLine("Hello {0}, your number is {1}, and Pi value is {2}", name, number, Pi.ToString("F2"));
            //Console.WriteLine("Hello {0}, your number is {1}, and Pi value is {2}", name, number, Pi.ToString("C2"));
            //Console.WriteLine("Hello {0}, your number is {1}, and Pi value is {2}", name, number, Pi.ToString("P2"));
            //Console.WriteLine("Hello {0}, your number is {1}, and Pi value is {2}", name, number, Pi.ToString("N2"));
            //Console.WriteLine("Wait here!");
        }
    }

}

