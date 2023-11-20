using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace test;

class Program
{
    static void Main(string[] args)
    {
        int[] data; 
        // Console.WriteLine(data); 
        data = new int[3]; 
        Console.WriteLine(data);
        var id = Guid.NewGuid(); 

        Console.WriteLine(id); 

    }
}
