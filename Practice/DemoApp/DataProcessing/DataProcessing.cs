using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;


namespace Sandvik.Coromant.CoroPlus.Tooling.SilentTools.BlazorApp.Pages.Playground.DevelopmentModules.AnomalyDetector;

public class DataProcessing
{
    public string folderPath;
    public string[] sensorSelected;
    public Dictionary<string, List<KeyValuePair<DateTime, double>>> dataDict = new Dictionary<string, List<KeyValuePair<DateTime, double>>>();
    public List<string> Keys = [];
    List<double> commonTimeStamps = new List<double>();
    public double[,] dataArray; 

    public DataProcessing(string folderPath, string[] sensorSelected)
    {
        //this.folderPath = folderPath ?? @"C:\Users\nq9093\CodeSpace\DeepLearningAI\DeepLearning\PyTorchBasics\practice\anomaly_detection\data\YaoBox\";
        this.folderPath = folderPath ?? @"C:\Users\nq9093\CodeSpace\DeepLearningAI\DeepLearning\PyTorchBasics\practice\anomaly_detection\data\strainTest\";
        this.sensorSelected = sensorSelected ?? new string[] { "Accelerometer", "Strain" };
    }

    public void LoadDataDictFromCSVFiles()
    {
        string[] files = Directory.GetFiles(folderPath, "*.csv");
        foreach (string file in files)
        {
            string fileName = Path.GetFileNameWithoutExtension(file);
            foreach (string sensor in sensorSelected)
            {
                if (fileName.Contains(sensor))
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    dataDict.Add(fileName, LoadCSVFromFile(file));
                    Keys.Add(fileName);

                    stopwatch.Stop();
                    Console.WriteLine($"Time taken to load {fileName}: {stopwatch.ElapsedMilliseconds} milliseconds");
                }
            }
        }
    }

    public List<KeyValuePair<DateTime, double>> LoadCSVFromFile(string file)
    {
        List<KeyValuePair<DateTime, double>> dataList = new List<KeyValuePair<DateTime, double>>();
        using (StreamReader reader = new StreamReader(file))
        {
            string[] headers = reader.ReadLine().Split(',');
            while (!reader.EndOfStream)
            {
                string[] rows = reader.ReadLine().Split(',');
                string timestampString = rows[0];
                if (timestampString[0] == '-')
                    continue;
                DateTime timestamp = DateTime.Parse(timestampString);
                double value = double.Parse(rows[1]);

                dataList.Add(new KeyValuePair<DateTime, double>(timestamp, value));
            }
        }
        return dataList;
    }


    public double[,] SynchronizeData(Dictionary<string, List<KeyValuePair<DateTime, double>>> data)
    {
        Console.WriteLine($"Synchronize data: {data.Count}");
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        var seriesList = data.Values.ToList();
        DateTime minTimestamp = seriesList.SelectMany(series => series.Select(kvp => kvp.Key)).Min();
        DateTime maxTimestamp = seriesList.SelectMany(series => series.Select(kvp => kvp.Key)).Max();
        int maxSamples = seriesList.Max(series => series.Count);
        double interval = (maxTimestamp - minTimestamp).TotalSeconds / (maxSamples - 1);

        // Generate common timestamps in elapsed seconds
        for (int i = 0; i < maxSamples; i++)
        {
            commonTimeStamps.Add(i * interval);
        }

        // Initialize the result array with an extra column for the common timestamps
        double[,] result = new double[commonTimeStamps.Count, seriesList.Count + 1];

        // Fill the first column with the common timestamps
        for (int i = 0; i < commonTimeStamps.Count; i++)
        {
            result[i, 0] = commonTimeStamps[i];
        }

        // Interpolate each series and fill the result array
        for (int i = 0; i < seriesList.Count; i++)
        {
            var interpolatedSeries = Interpolate(seriesList[i], commonTimeStamps, minTimestamp);
            for (int j = 0; j < commonTimeStamps.Count; j++)
            {
                result[j, i + 1] = interpolatedSeries[j].Value;
            }
        }
        stopwatch.Stop();
        Console.WriteLine($"Synlchronize data time consumed: {stopwatch.Elapsed.TotalSeconds} seconds");
        return result;
    }

    private List<KeyValuePair<double, double>> Interpolate(List<KeyValuePair<DateTime, double>> series, List<double> commonTimeStamps, DateTime minTimestamp)
    {
        List<KeyValuePair<double, double>> interpolatedSeries = new List<KeyValuePair<double, double>>();

        for (int i = 0; i < commonTimeStamps.Count; i++)
        {
            double elapsedSeconds = commonTimeStamps[i];
            DateTime targetTime = minTimestamp.AddSeconds(elapsedSeconds);

            // Find the closest points for interpolation
            var lower = series.LastOrDefault(kvp => kvp.Key <= targetTime);
            var upper = series.FirstOrDefault(kvp => kvp.Key >= targetTime);

            if (lower.Key == default(DateTime) || upper.Key == default(DateTime))
            {
                interpolatedSeries.Add(new KeyValuePair<double, double>(elapsedSeconds, double.NaN));
            }
            else if (lower.Key == upper.Key)
            {
                interpolatedSeries.Add(new KeyValuePair<double, double>(elapsedSeconds, lower.Value));
            }
            else
            {
                // Linear interpolation
                double t = (targetTime - lower.Key).TotalSeconds / (upper.Key - lower.Key).TotalSeconds;
                double interpolatedValue = lower.Value + t * (upper.Value - lower.Value);
                interpolatedSeries.Add(new KeyValuePair<double, double>(elapsedSeconds, interpolatedValue));
            }
        }

        return interpolatedSeries;
    }

    public double[,] NormalizeData(double[,] data)
    {
        int rows = data.GetLength(0);
        int cols = data.GetLength(1);
        double[,] normalizedData = new double[rows, cols];

        for (int col = 1; col < cols; col++)  // skip the first column (common timestamps)
        {
            double min = double.MaxValue;
            double max = double.MinValue;

            // Find the min and max values in the column
            for (int row = 0; row < rows; row++)
            {
                if (data[row, col] < min) min = data[row, col];
                if (data[row, col] > max) max = data[row, col];
            }

            // Check if min and max are the same
            if (min == max)
            {
                // If all values are the same, set them to 0.5 (or any constant value between 0 and 1)
                for (int row = 0; row < rows; row++)
                {
                    normalizedData[row, col] = .0;
                }
            }
            else
            {
                // Normalize the column
                for (int row = 0; row < rows; row++)
                {
                    normalizedData[row, col] = (data[row, col] - min) / (max - min);
                }
            }
        }
        return normalizedData;
    }

    public List<double[,]> CreateSequences(double[,] data, int sequenceLength)
    {
        var sequences = new List<double[,]>();

        int numSamples = data.GetLength(0);
        int numFeatures = data.GetLength(1);

        for (int i = 0; i <= numSamples - sequenceLength; i++)
        {
            var sequence = new double[sequenceLength, numFeatures];
            for (int j = 0; j < sequenceLength; j++)
            {
                for (int k = 0; k < numFeatures; k++)
                {
                    sequence[j, k] = data[i + j, k];
                }
            }
            sequences.Add(sequence);
        }
        return sequences;
    }

    public double[] GetDataSeriesFromColumnIndex(double[,] data, int index)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        int rows = data.GetLength(0);
        double[] series = new double[rows];

        for (int row = 0; row < rows; row++)
        {
            series[row] = data[row, index];
        }
        stopwatch.Stop();
        Console.WriteLine($"Time consumed for fetching {rows} rows is {stopwatch.ElapsedMilliseconds} milliseconds");
        return series;
    }

    public void SaveDataFrameToFile(string filePath, double[,] data)
    {
        int rows = data.GetLength(0);
        int cols = data.GetLength(1);
        string[] columns = Keys.ToArray();

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.Write("Timestamp,");
            for (int i = 0; i < cols - 1; i++)
            {
                writer.Write($"{columns[i]},");
            }
            writer.WriteLine($"{columns[cols - 1]}");

            // Write the dataDict rows
            for (int row = 0; row < rows; row++)
            {
                writer.Write($"{commonTimeStamps[row]},");
                for (int col = 0; col < cols - 1; col++)
                {
                    writer.Write($"{data[row, col]},");
                }
                writer.WriteLine($"{data[row, cols - 1]}");
            }
        }
        Console.WriteLine(rows + " rows " + cols + " columns of data saved to " + filePath);
    }
}
