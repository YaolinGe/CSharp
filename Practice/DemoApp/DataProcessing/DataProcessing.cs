using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;


namespace DataProcessing;

public class DataProcessing
{
    public string folderPath;
    public string[] sensorSelected;
    public Dictionary<string, List<KeyValuePair<DateTime, double>>> data = new Dictionary<string, List<KeyValuePair<DateTime, double>>>();

    public DataProcessing(string folderPath, string[] sensorSelected)
    {
        this.folderPath = folderPath ?? @"C:\Users\nq9093\CodeSpace\DeepLearningAI\DeepLearning\PyTorchBasics\practice\anomaly_detection\data\YaoBox\";
        this.sensorSelected = sensorSelected ?? new string[] { "Accelerometer", "Strain" };
    }

    public void LoadData()
    {
        string[] files = Directory.GetFiles(folderPath, "*.csv");
        foreach (string file in files)
        {
            string fileName = Path.GetFileNameWithoutExtension(file);
            foreach (string sensor in sensorSelected)
            {
                if (fileName.Contains(sensor))
                {
                    List<KeyValuePair<DateTime, double>> dataList = new List<KeyValuePair<DateTime, double>>();
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
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
                    data.Add(fileName, dataList);

                    stopwatch.Stop();
                    Console.WriteLine($"Time taken to load {fileName}: {stopwatch.ElapsedMilliseconds} milliseconds");
                }
            }
        }
    }

    public double[,] SynchronizeData(Dictionary<string, List<KeyValuePair<DateTime, double>>> data)
    {
        var seriesList = data.Values.ToList();
        DateTime minTimestamp = seriesList.SelectMany(series => series.Select(kvp => kvp.Key)).Min();
        DateTime maxTimestamp = seriesList.SelectMany(series => series.Select(kvp => kvp.Key)).Max();
        int maxSamples = seriesList.Max(series => series.Count);
        var commonTimeStamps = new List<DateTime>();
        double interval = (maxTimestamp - minTimestamp).TotalSeconds / (maxSamples - 1);
        for (int i = 0; i < maxSamples; i++)
        {
            commonTimeStamps.Add(minTimestamp.AddSeconds(i * interval));
        }
        double[,] result = new double[commonTimeStamps.Count, seriesList.Count];
        for (int i = 0; i < seriesList.Count; i++)
        {
            var interpolatedSeries = Interpolate(seriesList[i], commonTimeStamps);
            for (int j = 0; j < commonTimeStamps.Count; j++)
            {
                result[j, i] = interpolatedSeries[j].Value;
            }
        }
        return result;
    }

    private List<KeyValuePair<DateTime, double>> Interpolate(
        List<KeyValuePair<DateTime, double>> series, List<DateTime> commonTimeStamps)
    {
        var interpolatedSeries = new List<KeyValuePair<DateTime, double>>();
        int j = 0;
        for (int i = 0; i < commonTimeStamps.Count; i++)
        {
            while (j < series.Count - 1 && series[j + 1].Key <= commonTimeStamps[i])
            {
                j++;
            }
            if (j == series.Count - 1 || series[j].Key == commonTimeStamps[i])
            {
                interpolatedSeries.Add(new KeyValuePair<DateTime, double>(commonTimeStamps[i], series[j].Value));
            }
            else
            {
                double t1 = (commonTimeStamps[i] - series[j].Key).TotalSeconds;
                double t2 = (series[j + 1].Key - series[j].Key).TotalSeconds;
                double v1 = series[j].Value;
                double v2 = series[j + 1].Value;
                double interpolatedValue = v1 + (v2 - v1) * (t1 / t2);
                interpolatedSeries.Add(new KeyValuePair<DateTime, double>(commonTimeStamps[i], interpolatedValue));
            }
        }
        return interpolatedSeries;
    }

    public double[,] NormalizeData(double[,] data)
    {
        int rows = data.GetLength(0);
        int cols = data.GetLength(1);
        double[,] normalizedData = new double[rows, cols];

        for (int col = 0; col < cols; col++)
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
}
