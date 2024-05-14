using Sandvik.Coromant.CoroPlus.Tooling.DataModel;
//using Google.Protobuf;
//using System.IO;
//using SensorData;
using CsvHelper;
using System.Globalization; // The generated namespace from your .proto file


namespace CutFileParser
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

        public async Task<List<KeyValuePair<TimeSpan, double>>> GetSensorDataAsync(string sensorName)
        {
            var dataDescription = _fileLoaded.DataDescriptions.FirstOrDefault(d => d.Description == sensorName);
            if (dataDescription is null)
            {
                return new List<KeyValuePair<TimeSpan, double>>();
            }

            var data = await _fileLoaded.GetDataSeriesValuesByDataDescriptionAsync(dataDescription);
            return data.Values.ToList();
        }

        //public async Task DuplicateCutFileAsync(string newFilePath)
        //{
        //    _fileLoaded.Id = Guid.NewGuid();
        //    _fileLoaded.FilePath = newFilePath;
        //    var dataSeries = await GetSensorDataAsync("Load");
        //    _fileLoaded.DataSeries.Add(new DataSeries
        //    {
        //        DataDescription = new DataDescription { Description = "Load" },
        //        Values = { dataSeries.Select(kv => new DataPoint { Time = kv.Key, Value = kv.Value }) }
        //    });
        //    await _fileLoaded.SaveAsync();
        //}

        public async Task SaveSensorDataToCSV(string filePath, string sensorName)
        {
            List<KeyValuePair<TimeSpan, double>> data = await GetSensorDataAsync(sensorName);
            string tempPath = Path.GetTempPath();
            string subfolder = "CutFileParser";
            Directory.CreateDirectory(Path.Combine(tempPath, subfolder));
            string csvFileName = Path.Combine(tempPath, subfolder, $"{sensorName}.csv");

            using (var writer = new StreamWriter(csvFileName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(data.Select(kv => new { Time = kv.Key.ToString(), Value = kv.Value }));
            }

            Console.WriteLine($"Sensor data for '{sensorName}' has been saved to '{csvFileName}'");
        }

        //public async Task SaveSensorDataToProtobuf(string filePath, string sensorName)
        //{
        //    var sensorDataList = new SensorDataList();

        //    List<KeyValuePair<TimeSpan, double>> data = await GetSensorData(sensorName);
        //    foreach (KeyValuePair<TimeSpan, double> item in data)
        //    {
        //        sensorDataList.Data.Add(new SensorDataEntry { TimeSpan = item.Key.ToString(), Value = item.Value });
        //    }

        //    using (FileStream output = File.Create("sensor_data.protobuf"))
        //    {
        //        sensorDataList.WriteTo(output);
        //        Console.WriteLine("Sensor data has been saved to 'sensor_data.protobuf'");
        //    }
        //}


    }
}