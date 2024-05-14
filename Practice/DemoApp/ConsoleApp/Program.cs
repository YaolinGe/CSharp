using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Create a simple object
            //var person = new Person
            //{
            //    Name = "John Doe",
            //    Age = 30,
            //    Occupation = "Software Developer"
            //};

            //Console.WriteLine(person);
            //Console.WriteLine("Good", person, person);
            System.Boolean bP = true;
            Console.WriteLine(bP);
            Console.WriteLine(bP.GetType());

            int number = 123;    // Value type
            object boxed = number;   // Boxing
            int unboxed = (int)boxed; // Unboxing

            Console.WriteLine(number.GetType());
            Console.WriteLine(boxed.GetType());
            Console.WriteLine(unboxed.GetType());


            uint a = 0b_1010_1010;
            Console.WriteLine(a);

            uint b = ~a;
            Console.WriteLine(Convert.ToString(b, toBase: 2));

            Person person1 = new Person("Leopold", 10);
            Console.WriteLine("person1 Name = {0} Age = {1}", person1.Name, person1.Age);

            Person person2 = person1;
            person2.Name = "Molly";
            person2.Age = 12;

            Console.WriteLine(person1);
            Console.WriteLine(person2);
            Console.WriteLine();
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }

        public Person (string name, int age)
        {
            Name = name;
            Age = age;
            Occupation = "SWE"; 
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Occupation: {Occupation}";
        }
    }
}
