using Sandvik.Coromant.CoroPlus.Tooling.DataModel;

namespace CalculatorLibrary
{
    public class Calculator
    {
        public async Task<int> Add(int a, int b)
        {
            return await Task.FromResult(a + b);
        }

        public int Subtract(int a, int b) => a - b;

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b) => a / b;
    }
    //public class CutFileLoader
    //{
    //    private CoroPlusDataModel fileLoaded;

    //    public CutFileLoader(string filePath)
    //    {
    //        LoadFileAsync(filePath).Wait();
    //    }

    //    private async Task LoadFileAsync(string filePath)
    //    {
    //        // existing code to load file
    //        fileLoaded = await CutFileOperations.ReadAllFromFileAsync(filePath);
    //    }

    //    public async Task<List<KeyValuePair<TimeSpan, double>>> GetSensorData(string sensorName)
    //    {
    //        var dataDescription = fileLoaded.DataDescriptions.FirstOrDefault(d => d.Description == sensorName);
    //        if (dataDescription == null)
    //        {
    //            return new List<KeyValuePair<TimeSpan, double>>(); // or handle this scenario appropriately
    //        }

    //        var data = await fileLoaded.GetDataSeriesValuesByDataDescriptionAsync(dataDescription);
    //        return data.Values.ToList();
    //    }
    //}

}
