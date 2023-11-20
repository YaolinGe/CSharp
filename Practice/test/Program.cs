using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace test;

class Program
{
    static void Main(string[] args)
    {
        int[] data = new int[3]; 
        var data1 = data;
        // Console.WriteLine(data); 
        data = new int[3]; 
        Console.WriteLine(data);
        Console.WriteLine(data.Length); 
    }
}
