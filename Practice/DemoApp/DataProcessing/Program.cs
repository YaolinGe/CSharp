using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Hello world!"); 
    }
}
=======
using System.Diagnostics;
using System.IO;
using System.Linq;

class Program
{
    public Dictionary<string, List<KeyValuePair<DateTime, double>>> data = new Dictionary<string, List<KeyValuePair<DateTime, double>>>();

    public static void Main(string[] args)
    {
        Program program = new Program();
        program.LoadData();
        var synchronizedData = program.SynchronizeData();
        // You can now use synchronizedData for further processing
    }

    public void LoadData()
    {
        string folderPath = @"C:\Users\nq9093\CodeSpace\DeepLearningAI\DeepLearning\PyTorchBasics\practice\anomaly_detection\data\YaoBox\";
        string[] sensorSelected = { "Accelerometer", "Strain" };
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

    public double[,] SynchronizeData()
    {
        // Convert the dictionary to a list of time series
        var seriesList = data.Values.ToList();

        // Determine the range of timestamps
        DateTime minTimestamp = seriesList.SelectMany(series => series.Select(kvp => kvp.Key)).Min();
        DateTime maxTimestamp = seriesList.SelectMany(series => series.Select(kvp => kvp.Key)).Max();

        // Determine the maximum number of samples
        int maxSamples = seriesList.Max(series => series.Count);

        // Create a regular grid of timestamps
        var allTimestamps = new List<DateTime>();
        double interval = (maxTimestamp - minTimestamp).TotalSeconds / (maxSamples - 1);
        for (int i = 0; i < maxSamples; i++)
        {
            allTimestamps.Add(minTimestamp.AddSeconds(i * interval));
        }

        // Initialize the result matrix
        double[,] result = new double[allTimestamps.Count, seriesList.Count];

        // Interpolate data for each series
        for (int i = 0; i < seriesList.Count; i++)
        {
            var interpolatedSeries = Interpolate(seriesList[i], allTimestamps);
            for (int j = 0; j < allTimestamps.Count; j++)
            {
                result[j, i] = interpolatedSeries[j].Value;
            }
        }

        return result;
    }

    private List<KeyValuePair<DateTime, double>> Interpolate(
        List<KeyValuePair<DateTime, double>> series, List<DateTime> allTimestamps)
    {
        var interpolatedSeries = new List<KeyValuePair<DateTime, double>>();
        int j = 0;

        for (int i = 0; i < allTimestamps.Count; i++)
        {
            while (j < series.Count - 1 && series[j + 1].Key <= allTimestamps[i])
            {
                j++;
            }

            if (j == series.Count - 1 || series[j].Key == allTimestamps[i])
            {
                interpolatedSeries.Add(new KeyValuePair<DateTime, double>(allTimestamps[i], series[j].Value));
            }
            else
            {
                double t1 = (allTimestamps[i] - series[j].Key).TotalSeconds;
                double t2 = (series[j + 1].Key - series[j].Key).TotalSeconds;
                double v1 = series[j].Value;
                double v2 = series[j + 1].Value;
                double interpolatedValue = v1 + (v2 - v1) * (t1 / t2);
                interpolatedSeries.Add(new KeyValuePair<DateTime, double>(allTimestamps[i], interpolatedValue));
            }
        }

        return interpolatedSeries;
    }
}
>>>>>>> b86abade59bc48313fcf2fd3e0faeca5c072dc0c
