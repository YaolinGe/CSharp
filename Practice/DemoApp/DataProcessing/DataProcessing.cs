using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;


namespace DataProcessing; 

class DataProcessing
{
    public string folderPath;
    public string[] sensorSelected;
    public Dictionary<string, List<KeyValuePair<DateTime, double>>> data = new Dictionary<string, List<KeyValuePair<DateTime, double>>>();

    public DataProcessing(string folderPath, string[] sensorSelected)
    {
        this.folderPath = folderPath ?? @"C:\Users\nq9093\CodeSpace\DeepLearningAI\DeepLearning\PyTorchBasics\practice\anomaly_detection\data\YaoBox\";
        this.sensorSelected = sensorSelected ?? new string[] { "Accelerometer", "Strain" };
    }

    public async Task LoadData()
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

    public double[,] NormalizeData(double[,] synchronizedData)
    {
        double[] minValues = new double[synchronizedData.GetLength(1)];
        double[] maxValues = new double[synchronizedData.GetLength(1)];

        for (int i = 0; i < synchronizedData.GetLength(1); i++)
        {
            minValues[i] = synchronizedData.Cast<double>().Skip(i).Take(synchronizedData.GetLength(0)).Min();
            maxValues[i] = synchronizedData.Cast<double>().Skip(i).Take(synchronizedData.GetLength(0)).Max();
        }

        double[,] normalizedData = new double[synchronizedData.GetLength(0), synchronizedData.GetLength(1)];
        for (int i = 0; i < synchronizedData.GetLength(0); i++)
        {
            for (int j = 0; j < synchronizedData.GetLength(1); j++)
            {
                normalizedData[i, j] = (synchronizedData[i, j] - minValues[j]) / (maxValues[j] - minValues[j]);
            }
        }
        return normalizedData;
    }
}
