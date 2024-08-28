namespace DataProcessing;

class Program
{
    public static void Main(string[] args)
    {
        var dataProcessing = new DataProcessing(null, null);
        dataProcessing.LoadData();
        var synchronizedData = dataProcessing.SynchronizeData(dataProcessing.data);
        var normalizedData = dataProcessing.NormalizeData(synchronizedData);

        //var dv = new DataVisualizer();
        //double[] x = new double[] { 1, 2, 3 };
        //double[] y = new double[] { 4, 5, 6 };
        //var line = dv.LinePlot(x, y);

        LSTMAutoEncoder lstmAutoEncoder = new LSTMAutoEncoder();
        lstmAutoEncoder.LoadModel();
        lstmAutoEncoder.RunAnomalyDetection(normalizedData);
    }
}

