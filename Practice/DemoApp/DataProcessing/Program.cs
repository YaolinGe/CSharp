namespace Sandvik.Coromant.CoroPlus.Tooling.SilentTools.BlazorApp.Pages.Playground.DevelopmentModules.AnomalyDetector;

class Program
{
    public static void Main(string[] args)
    {
        var dataProcessing = new DataProcessing(null, null);
        var dataVisualizer = new DataVisualizer();
        dataProcessing.LoadDataDictFromCSVFiles();
        var synchronizedData = dataProcessing.SynchronizeData(dataProcessing.dataDict);
        var normalizedData = dataProcessing.NormalizeData(synchronizedData);
        double[] elapsedSeconds = dataProcessing.GetElapsedSeconds();

        //string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "normalizedData.csv");
        //dataProcessing.SaveDataFrameToFile(filePath, normalizedData);

        //var dv = new DataVisualizer();
        //double[] x = new double[] { 1, 2, 3 };
        //double[] y = new double[] { 4, 5, 6 };
        //var line = dv.LinePlot(x, y);

        //LSTMAutoEncoder lstmAutoEncoder = new LSTMAutoEncoder();
        //lstmAutoEncoder.LoadModel();
        //lstmAutoEncoder.RunAnomalyDetection(normalizedData);

        //string dataPath = @"C:\Users\nq9093\CodeSpace\CSharp\Practice\DemoApp\DataProcessing\indices_anomalies.csv";
        //int[] indices = ReadIndices(dataPath);
        //double[] strainData = dataProcessing.GetDataSeriesFromColumnIndex(normalizedData, 6);
        //string imageBase64 = dataVisualizer.PlotAnomalies(x, y, indices);
        //string imageBase64 = dataVisualizer.PlotAnomalies(elapsedSeconds, strainData, indices);

        //string imageBase64 = dataVisualizer.PlotSubplots(normalizedData, elapsedSeconds);


    }

    private static int[] ReadIndices(string filePath)
    {
        List<int> indices = new List<int>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            bool skipFirstRow = true;

            while ((line = reader.ReadLine()) != null)
            {
                if (skipFirstRow)
                {
                    skipFirstRow = false;
                    continue;
                }

                if (int.TryParse(line, out int index))
                {
                    indices.Add(index);
                }
            }
        }
        return indices.ToArray();
    }

}

