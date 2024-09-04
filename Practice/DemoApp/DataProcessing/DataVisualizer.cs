using System;
using System.Diagnostics;
using System.IO;

namespace Sandvik.Coromant.CoroPlus.Tooling.SilentTools.BlazorApp.Pages.Playground.DevelopmentModules.AnomalyDetector;

public class DataVisualizer
{
    string pythonExecutablePath = @"C:\Users\nq9093\AppData\Local\anaconda3\envs\ML\python.exe";
    //string pythonScriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pages", "Playground", "DevelopmentModules", "AnomalyDetector", "plotting", "plot.py");
    string pythonScriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plot.py");
    string outputImagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "output.png");
    //string outputHtmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", "output.html");
    //string outputHtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "output.html");
    string outputHtmlPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "output.html");

    public void LinePlot(double[] x, double[] y)
    {
        string xValues = string.Join(",", x);
        string yValues = string.Join(",", y);

        RunPythonScript($"{pythonScriptPath} \"{outputImagePath}\" \"{xValues}\" \"{yValues}\"");

        Console.WriteLine("Image generated successfully!"); 
    }

    public void PlotAnomalies(double[,] data, int[] indicesAnomaly, double[] errorAnomaly)
    {
        string tempDataFilePath = Path.GetTempFileName();
        string tempAnomalyFilePath = Path.GetTempFileName();

        Console.WriteLine($"tempDataFilePath: {tempDataFilePath}");
        Console.WriteLine($"tempAnomalyFilePath: {tempAnomalyFilePath}");
        outputHtmlPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "output_anomaly.html");

        try
        {
            using (StreamWriter writer = new StreamWriter(tempDataFilePath))
            {
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        writer.Write(data[i, j]);
                        if (j < data.GetLength(1) - 1)
                        {
                            writer.Write(",");
                        }
                    }
                    writer.WriteLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(tempAnomalyFilePath))
            {
                for (int i = 0; i < indicesAnomaly.Length; i++)
                {
                    writer.WriteLine($"{indicesAnomaly[i]},{errorAnomaly[i]}");
                }
            }

            RunPythonScript($"{pythonScriptPath} \"{outputHtmlPath}\" \"{tempDataFilePath}\" \"{tempAnomalyFilePath}\"");

            if (File.Exists(outputImagePath))
            {
                Console.WriteLine("Image generated successfully at " + outputHtmlPath);
            }
            else
            {
                Console.WriteLine("Image generation failed.");
            }
        }
        finally
        {
            if (File.Exists(tempDataFilePath)) File.Delete(tempDataFilePath);
            if (File.Exists(tempAnomalyFilePath)) File.Delete(tempAnomalyFilePath);
        }
    }

    public void PlotSubplots(double[,] data)
    {
        string tempDataFilePath = Path.GetTempFileName();

        try
        {
            using (StreamWriter writer = new StreamWriter(tempDataFilePath))
            {
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        writer.Write(data[i, j]);
                        if (j < data.GetLength(1) - 1)
                        {
                            writer.Write(",");
                        }
                    }
                    writer.WriteLine();
                }
            }

            RunPythonScript($"{pythonScriptPath} \"{outputHtmlPath}\" \"{tempDataFilePath}\"");

            if (File.Exists(outputImagePath))
            {
                Console.WriteLine("Image generated successfully at " + outputHtmlPath);
            }
            else
            {
                Console.WriteLine("Image generation failed.");
            }
        }
        finally
        {
            if (File.Exists(tempDataFilePath)) File.Delete(tempDataFilePath);
        }
        //return "/output.html";
    }

    public void RunPythonScript(string arguments)
    {
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = pythonExecutablePath;
        start.Arguments = arguments;
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        start.RedirectStandardError = true;
        start.CreateNoWindow = true;

        using (Process process = Process.Start(start))
        {
            using (StreamReader reader = process.StandardOutput)
            {
                string result = reader.ReadToEnd();
                Console.WriteLine(result);
            }
            using (StreamReader reader = process.StandardError)
            {
                string error = reader.ReadToEnd();
                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine("Error: " + error);
                }
            }
        }
    }

}
