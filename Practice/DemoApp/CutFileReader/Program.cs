namespace CutFileReader;

public class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: CutFileReader.exe <cutFilePath> <sensorName>");
            return;
        }

        string filePath = args[0];
        string sensorName = args[1];

        CutFileLoader loader = new CutFileLoader(filePath);

        // Save sensor data to a Protobuf file
        await loader.SaveSensorDataToProtobuf(filePath, sensorName);

    }
}
