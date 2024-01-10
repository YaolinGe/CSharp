using Sandvik.Coromant.CoroPlus.Tooling.DataModel;

namespace CutFileReader;

public class CutFileLoader
{
    public CutFileLoader(string filePath)
    {
        LoadFileAsync(filePath).Wait();
    }

    private async Task LoadFileAsync(string filePath)
    {
        await Console.Out.WriteLineAsync(filePath);
        CoroPlusDataModel fileLoaded = await CutFileOperations.ReadAllFromFileAsync(filePath);
        await Console.Out.WriteLineAsync(fileLoaded.ToString());
        
        var allDataDescriptions = fileLoaded.DataDescriptions;
        List<string> sensorNames = new();

        foreach (DataDescription item in allDataDescriptions)
        {
            sensorNames.Add(item.Description); 
        }

        (Guid DataSeriesId, IEnumerable<KeyValuePair<TimeSpan, double>> Values) tempData = await fileLoaded.GetDataSeriesValuesByDataDescriptionAsync(allDataDescriptions.Where(d => d.Description == sensorNames[0]).First());
        
        tempData.Values.ToList().ForEach(v => Console.WriteLine($"{v.Key} {v.Value}"));

    }

}
