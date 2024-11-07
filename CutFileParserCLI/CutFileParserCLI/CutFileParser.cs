//using Sandvik.Coromant.CoroPlus.Tooling.DataModel;
//using CsvHelper;
//using System.Globalization;


//namespace CutFileParser
//{
//    public class CutFileParser
//    {
//        private CoroPlusDataModel _fileLoaded;

//        public CutFileParser(string filePath)
//        {
//            LoadFileAsync(filePath).Wait();
//        }

//        private async Task LoadFileAsync(string filePath)
//        {
//            _fileLoaded = await CutFileOperations.ReadAllFromFileAsync(filePath);
//        }

//        public async Task SaveSensorDataToCSVsAsync(string filePath, List<string> sensors)
//        {
//            var stopwatch = new System.Diagnostics.Stopwatch();
//            stopwatch.Start();

//            foreach (var sensorName in sensors)
//            {
//                List<KeyValuePair<TimeSpan, double>> data = await GetSensorDataAsync(sensorName);
//                string tempPath = Path.GetTempPath();
//                string subfolder = "CutFileParser";
//                Directory.CreateDirectory(Path.Combine(tempPath, subfolder));
//                string csvFileName = Path.Combine(tempPath, subfolder, $"{sensorName}.csv");

//                using (var writer = new StreamWriter(csvFileName))
//                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
//                {
//                    csv.WriteRecords(data.Select(kv => new { Time = kv.Key.ToString(), Value = kv.Value }));
//                }

//                Console.WriteLine($"Sensor data for '{sensorName}' has been saved to '{csvFileName}'");
//            }

//            stopwatch.Stop();
//            Console.WriteLine($"Process completed in {stopwatch.Elapsed.TotalSeconds} seconds.");
//        }

//        public async Task<List<KeyValuePair<TimeSpan, double>>> GetSensorDataAsync(string sensorName)
//        {
//            var dataDescription = _fileLoaded.DataDescriptions.FirstOrDefault(d => d.Description.Contains(sensorName));
//            if (dataDescription is null)
//            {
//                return new List<KeyValuePair<TimeSpan, double>>();
//            }

//            var data = await _fileLoaded.GetDataSeriesValuesByDataDescriptionAsync(dataDescription);
//            return data.Values.ToList();
//        }
//    }
//}




using Sandvik.Coromant.CoroPlus.Tooling.DataModel;
using CsvHelper;
using System.Globalization;
using System.Threading.Tasks;

namespace CutFileParser
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
            try
            {
                _fileLoaded = await CutFileOperations.ReadAllFromFileAsync(filePath);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error loading file: {ex.Message}");
                Console.Error.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public async Task SaveSensorDataToCSVsAsync(string filePath, List<string> sensorNames, string outputDirectory)
        {

            Directory.CreateDirectory(outputDirectory);

            // Use parallel processing to save sensor data to CSVs
            await Task.WhenAll(sensorNames.Select(async sensorName =>
            {
                string csvFileName = Path.Combine(outputDirectory, $"{sensorName}.csv");
                List<KeyValuePair<TimeSpan, double>> data = await GetSensorDataAsync(sensorName);

                using (var writer = new StreamWriter(csvFileName))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    await csv.WriteRecordsAsync(data.Select(kv => new { Time = kv.Key.ToString(), Value = kv.Value }));
                }

                Console.WriteLine($"Sensor data for '{sensorName}' has been saved to '{csvFileName}'");
            }));
        }

        public async Task SaveSensorDataToCSV(string filePath, string sensorName, string outputDirectory)
        {
            List<KeyValuePair<TimeSpan, double>> data = await GetSensorDataAsync(sensorName);
            Directory.CreateDirectory(outputDirectory);
            string csvFileName = Path.Combine(outputDirectory, $"{sensorName}.csv");

            using (var writer = new StreamWriter(csvFileName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(data.Select(kv => new { Time = kv.Key.ToString(), Value = kv.Value }));
            }
            Console.WriteLine($"Sensor data for '{sensorName}' has been saved to '{csvFileName}'");
        }

        public async Task<List<KeyValuePair<TimeSpan, double>>> GetSensorDataAsync(string sensorName)
        {
            var dataDescription = _fileLoaded.DataDescriptions.FirstOrDefault(d => d.Description.Contains(sensorName));
            if (dataDescription is null)
            {
                return new List<KeyValuePair<TimeSpan, double>>();
            }
            var data = await _fileLoaded.GetDataSeriesValuesByDataDescriptionAsync(dataDescription);
            return data.Values.ToList();
        }
    }
}