
namespace DataProcessing; 

class Program
{
    public static void Main(string[] args)
    {
        var dataProcessing = new DataProcessing(null, null);
        dataProcessing.LoadData();
        var synchronizedData = dataProcessing.SynchronizeData(dataProcessing.data);
        var normalizedData = dataProcessing.NormalizeData(synchronizedData);

    }
}

