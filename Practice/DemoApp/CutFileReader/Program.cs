using Sandvik.Coromant.CoroPlus.Tooling.DataModel;

Console.WriteLine("Hello");
string filePath = @"C:\Users\nq9093\Downloads\ExportedFiles_20240105_024938\CoroPlus_230912-145816.cut"; 
var fileLoaded = await CutFileOperations.ReadAllFromFileAsync(filePath);

var allData = fileLoaded.DataDescriptions;
foreach (var item in allData.Where(d => d.Classification == DataClassification.Raw))
{
    Console.WriteLine(item.Description);
}


//foreach (var item in allData.Where(d => d.Classification == DataClassification.Processed))
//{
//    Console.WriteLine(item.Description);
//}

var temp = await fileLoaded.GetDataSeriesValuesByDataDescriptionAsync(allData.Where(d => d.Classification == DataClassification.Raw).First());

//temp.Values.ToList().ForEach(v => Console.WriteLine(v));
Console.WriteLine(temp.Values.ToList()[0]);

Console.WriteLine(fileLoaded.Process.); 