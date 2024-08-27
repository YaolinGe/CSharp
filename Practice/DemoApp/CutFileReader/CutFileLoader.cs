using Sandvik.Coromant.CoroPlus.Tooling.DataModel;
using Google.Protobuf;
using System.IO;
using SensorData; // The generated namespace from your .proto file


namespace CutFileReader
{
    public class CutFileLoader
    {
        private CoroPlusDataModel _fileLoaded;

        public CutFileLoader(string filePath)
        {
            LoadFileAsync(filePath).Wait();
        }

        private async Task LoadFileAsync(string filePath)
        {
            _fileLoaded = await CutFileOperations.ReadAllFromFileAsync(filePath);
        }

        public void GetSensorLists()
        {
            foreach (var item in _fileLoaded.DataDescriptions)
            {
                Console.WriteLine(item.Description);
            }
        }

        public async Task<List<KeyValuePair<TimeSpan, double>>> GetSensorData(string sensorName)
        {
            var dataDescription = _fileLoaded.DataDescriptions.FirstOrDefault(d => d.Description == sensorName);
            if (dataDescription is null)
            {
                return new List<KeyValuePair<TimeSpan, double>>();
            }

            var data = await _fileLoaded.GetDataSeriesValuesByDataDescriptionAsync(dataDescription);
            return data.Values.ToList();
        }

    }

}