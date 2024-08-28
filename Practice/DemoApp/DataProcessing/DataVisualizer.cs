using System;
using System.Diagnostics;
using System.IO;

namespace DataProcessing
{
    public class DataVisualizer
    {
        string pythonExecutablePath = @"C:\Users\nq9093\AppData\Local\anaconda3\envs\ML\python.exe";
        string pythonScriptPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plot.py");
        string outputImagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "output.png");

        public string LinePlot(double[] x, double[] y)
        {
            string imageBase64 = ""; 
            string xValues = string.Join(",", x);
            string yValues = string.Join(",", y);

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = pythonExecutablePath;
            start.Arguments = $"{pythonScriptPath} \"{xValues}\" \"{yValues}\" \"{outputImagePath}\"";
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
            return imageBase64;
        }
    }
}
