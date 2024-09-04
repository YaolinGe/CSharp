namespace Sandvik.Coromant.CoroPlus.Tooling.SilentTools.BlazorApp.Pages.Playground.DevelopmentModules.AnomalyDetector;

class Program
{
    public static void Main(string[] args)
    {
        var dataProcessing = new DataProcessing(null, null);
        var dataVisualizer = new DataVisualizer();
        LSTMAutoEncoder lstmAutoEncoder = new LSTMAutoEncoder();

        double[] x = dataProcessing.GetDataSeriesFromColumnIndex(dataProcessing.dataNormalized, 0);
        double[] y = dataProcessing.GetDataSeriesFromColumnIndex(dataProcessing.dataNormalized, 1);

        dataVisualizer.PlotSubplots(dataProcessing.dataNormalized);

        lstmAutoEncoder.RunAnomalyDetection(dataProcessing.dataNormalized);

        int[] indicesAnomaly = lstmAutoEncoder.indicesAnomaly.ToArray();
        double[] errorAnomaly = lstmAutoEncoder.errorAnomaly.ToArray();

        dataVisualizer.PlotAnomalies(dataProcessing.dataNormalized, indicesAnomaly, errorAnomaly);
    }



}

