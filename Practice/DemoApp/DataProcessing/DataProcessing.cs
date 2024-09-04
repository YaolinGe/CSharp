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

    public Dictionary<string, List<KeyValuePair<DateTime, double>>> dataDictionary = new Dictionary<string, List<KeyValuePair<DateTime, double>>>();
    public List<string> Keys = [];

    DateTime startTimeStamp; 
    double[] commonTimeStamps;
    int maxSamples;

    public double[,] dataSynchronized;
    public double[,] dataNormalized; 

    public DataProcessing(string folderPath, string[] sensorSelected)
    {
        this.folderPath = folderPath ?? @"C:\Users\nq9093\CodeSpace\DeepLearningAI\DeepLearning\PyTorchBasics\practice\anomaly_detection\data\YaoBox\processed\";
        //this.folderPath = folderPath ?? @"C:\Users\nq9093\CodeSpace\DeepLearningAI\DeepLearning\PyTorchBasics\practice\anomaly_detection\data\strainTest\";
        this.sensorSelected = sensorSelected ?? new string[] { "Accelerometer", "Strain" };

        LoadDataDictFromCSVFiles();
        CreateCommonTimeStamps();
        SynchronizeData();
        dataNormalized = NormalizeData(dataSynchronized);
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

                    dataDictionary.Add(fileName, LoadCSVFromFile(file));
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
        int count = 0;

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
                count++;
            }
        }

        if (count > maxSamples)
            maxSamples = count;

        Console.WriteLine($"Loaded {count} rows from {Path.GetFileName(file)}; MaxSamples is {maxSamples}"); 

        return dataList;
    }

    public void CreateCommonTimeStamps()
    {
        var seriesList = dataDictionary.Values.ToList();
        DateTime minTimestamp = seriesList.SelectMany(series => series.Select(kvp => kvp.Key)).Min();
        DateTime maxTimestamp = seriesList.SelectMany(series => series.Select(kvp => kvp.Key)).Max();
        double interval = (maxTimestamp - minTimestamp).TotalSeconds / (maxSamples - 1);
        commonTimeStamps = new double[maxSamples];
        
        for (int i = 0; i < maxSamples; i++)
        {
            commonTimeStamps[i] = i * interval;
        }
        
        if (startTimeStamp < minTimestamp)
        {
            startTimeStamp = minTimestamp;
        }
    }

    public void SynchronizeData()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        dataSynchronized = new double[commonTimeStamps.Length, dataDictionary.Count + 1];

        foreach (var itemList in dataDictionary.Values.ToList())
        {
            double[] interpolatedSamples = Interpolate(itemList);
            for (int i = 0; i < maxSamples; i++)
            {
                dataSynchronized[i, 0] = commonTimeStamps[i];
                dataSynchronized[i, dataDictionary.Values.ToList().IndexOf(itemList) + 1] = interpolatedSamples[i];
            }
        }

        stopwatch.Stop();
        Console.WriteLine($"Synchronizing the data took {stopwatch.Elapsed.TotalSeconds} seconds");
    }

    private double[] Interpolate(List<KeyValuePair<DateTime, double>> series)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        double[] interpolatedSamples = new double[maxSamples];

        double[] deltaTime = new double[series.Count];
        for (int i = 0; i < series.Count - 1; i++)
        {
            deltaTime[i] = (series[i].Key - startTimeStamp).TotalSeconds;
        }

        for (int i = 0; i < maxSamples; i++)
        {
            double currentTimeStamp = commonTimeStamps[i];

            int j = 0;
            while (deltaTime[j] < currentTimeStamp)
            {
                j++;
                if (j == series.Count)
                {
                    break;
                }
            }
            if (j == 0)
            {
                interpolatedSamples[i] = series[j].Value;
            }
            else if (j == series.Count)
            {
                interpolatedSamples[i] = series[j - 1].Value;
            }
            else
            {
                interpolatedSamples[i] = series[j].Value + (currentTimeStamp - deltaTime[j]) * (series[j + 1].Value - series[j].Value) / (deltaTime[j + 1] - deltaTime[j]);
            }
        }
        stopwatch.Stop();
        Console.WriteLine($"Interpolating the original {series.Count} samples to {maxSamples} took {stopwatch.Elapsed.TotalSeconds} seconds");
        return interpolatedSamples;
    }

    public double[, ] NormalizeData(double[, ] data)
    {
        int rows = data.GetLength(0);
        int cols = data.GetLength(1);
        double[,] normalizedData = new double[rows, cols];

        for (int col = 0; col < cols; col++)  
        {
            if (col == 0)
            {
                for (int row = 0; row < rows; row++)
                {
                    normalizedData[row, col] = data[row, col];
                }
                continue;
            }

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
                for (int row = 0; row < rows; row++)
                {
                    normalizedData[row, col] = .0;
                }
            }
            else
            {
                for (int row = 0; row < rows; row++)
                {
                    normalizedData[row, col] = (data[row, col] - min) / (max - min);
                }
            }
        }
        return normalizedData;
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

    public double[] GetValueFromIndices(double[] data, int[] indices)
    {
        double[] values = new double[indices.Length];
        for (int i = 0; i < indices.Length; i++)
        {
            values[i] = data[indices[i]];
        }
        return values;
    }
}
