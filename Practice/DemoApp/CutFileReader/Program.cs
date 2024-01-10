using CutFileReader;
using Sandvik.Coromant.CoroPlus.Tooling.DataModel;


Console.WriteLine("Hello");
string filePath = @"C:\Users\nq9093\Downloads\ExportedFiles_20240105_024938\CoroPlus_230912-145816.cut";

CutFileLoader cutFileLoader = new(filePath);


