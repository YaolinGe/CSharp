using Sandvik.Coromant.CoroPlus.Tooling.DataModel;
using Google.Protobuf;
using System.IO;
using SensorData; // The generated namespace from your .proto file


namespace CutFileReader
{
    public class CutFileParser
    {
        private CoroPlusDataModel _fileLoaded;

        public CutFileParser(string filePath)
        {
            LoadFileAsync(filePath).Wait();
        }

        private async Task LoadFileAsync(string filePath)
        {
            _fileLoaded = await CutFileOperations.ReadAllFromFileAsync(filePath);
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

        public async Task SaveSensorDataToProtobuf(string filePath, string sensorName)
        {
            var sensorDataList = new SensorDataList();

            List<KeyValuePair<TimeSpan, double>> data = await GetSensorData(sensorName);
            foreach (KeyValuePair<TimeSpan, double> item in data)
            {
                sensorDataList.Data.Add(new SensorDataEntry { TimeSpan = item.Key.ToString(), Value = item.Value });
            }

            using (FileStream output = File.Create("sensor_data.protobuf"))
            {
                sensorDataList.WriteTo(output);
                Console.WriteLine("Sensor data has been saved to 'sensor_data.protobuf'");
            }
        }
    }

}