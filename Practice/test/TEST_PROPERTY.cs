// using System.ComponentModel;
// using System.Reflection.Metadata.Ecma335;
// using System.Runtime.CompilerServices;

// namespace test;

// class Program
// {
//     public class FieldTest 
//     {
//         private string _data = "test"; 
//         public string Data 
//         {
//             get => _data; 
//             set{
//                 _data = value;
//             }
//         }
//     }

//     public class PropertyTest 
//     {
//         // declare a property
//         public string Data { get; set; } = "property test";
//     }

//     static void Main(string[] args)
//     {
//         Console.WriteLine("Hello, this is just a test!"); 
//         FieldTest ft = new FieldTest();
//         Console.WriteLine(ft.Data); 
//         ft.Data = "Updated test"; 
//         Console.WriteLine(ft.Data);
//         Console.WriteLine("End of the test!"); 

//         PropertyTest pt = new PropertyTest();
//         Console.WriteLine(pt.Data);
//         pt.Data = "Updated property test";
//         Console.WriteLine(pt.Data);
//     }
// }
