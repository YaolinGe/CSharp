using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace test;

class Program
{
    static void Main(string[] args)
    {
        int number = 5;
        Console.WriteLine(number.ToString()); // Using Object's ToString method
        Console.WriteLine(number.GetHashCode()); // Using Object's GetHashCode method
        Console.WriteLine(number.Equals(5)); // Using Object's Equals method


    }
}
