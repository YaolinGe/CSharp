namespace CutFileReader;

public class Program
{
    static async Task Main(string[] args)
    {
        // c1, test parser cli tool
        //if (args.Length < 2)
        //{
        //    Console.WriteLine("Usage: CutFileReader.exe <cutFilePath> <sensorName>");
        //    return;
        //}

        //string filePath = args[0];
        //string sensorName = args[1];

        //CutFileParser loader = new CutFileParser(filePath);

        //// Save sensor data to a Protobuf file
        //await loader.SaveSensorDataToProtobuf(filePath, sensorName);


        // c2, test loader 
        string filePath = @"C:\Users\nq9093\Downloads\ExportedFiles_20240105_024938\CoroPlus_230912-150326.cut";
        string sensorName = "Load"; 
        CutFileLoader loader = new CutFileLoader(filePath);
        loader.GetSensorLists();
        //var data = await loader.GetSensorData(sensorName);
    }
}
