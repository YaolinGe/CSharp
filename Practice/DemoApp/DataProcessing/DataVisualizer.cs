using System;
using System.Diagnostics;
using System.IO;

namespace Sandvik.Coromant.CoroPlus.Tooling.SilentTools.BlazorApp.Pages.Playground.DevelopmentModules.AnomalyDetector;

public class DataVisualizer
{
    string pythonExecutablePath = @"C:\Users\nq9093\AppData\Local\anaconda3\envs\ML\python.exe";
    string pythonScriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pages", "Playground", "DevelopmentModules", "AnomalyDetector", "plotting", "plot.py");
    string outputImagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "output.png");
    //string outputHtmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", "output.html");
    string outputHtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "output.html");

    public void LinePlot(double[] x, double[] y)
    {
        string xValues = string.Join(",", x);
        string yValues = string.Join(",", y);

        RunPythonScript($"{pythonScriptPath} \"{outputImagePath}\" \"{xValues}\" \"{yValues}\"");

        Console.WriteLine("Image generated successfully!"); 
    }

    public string PlotAnomalies(double[] x, double[] y, int[] indices)
    {
        string imageBase64 = "";
        string tempXFilePath = Path.GetTempFileName();
        string tempYFilePath = Path.GetTempFileName();
        string tempIndicesFilePath = Path.GetTempFileName();

        try
        {
            // Save x to the temporary file
            using (StreamWriter writer = new StreamWriter(tempXFilePath))
            {
                writer.WriteLine(string.Join(",", x));
            }

            // Save y to the temporary file
            using (StreamWriter writer = new StreamWriter(tempYFilePath))
            {
                writer.WriteLine(string.Join(",", y));
            }

            // Save indices to the temporary file
            using (StreamWriter writer = new StreamWriter(tempIndicesFilePath))
            {
                writer.WriteLine(string.Join(",", indices));
            }

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = pythonExecutablePath;
            start.Arguments = $"{pythonScriptPath} \"{outputImagePath}\" \"{tempXFilePath}\" \"{tempYFilePath}\" \"{tempIndicesFilePath}\"";
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

            if (File.Exists(outputImagePath))
            {
                byte[] imageBytes = File.ReadAllBytes(outputImagePath);
                imageBase64 = Convert.ToBase64String(imageBytes);
                Console.WriteLine("Image Base64: " + imageBase64);
            }
            else
            {
                Console.WriteLine("Image generation failed.");
            }
        }
        finally
        {
            // Clean up the temporary files
            if (File.Exists(tempXFilePath)) File.Delete(tempXFilePath);
            if (File.Exists(tempYFilePath)) File.Delete(tempYFilePath);
            if (File.Exists(tempIndicesFilePath)) File.Delete(tempIndicesFilePath);
        }

        return imageBase64;
    }

    public string PlotSubplots(double[,] data)
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
                Console.WriteLine("Image generated successfully!");
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
        return "/output.html";
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
