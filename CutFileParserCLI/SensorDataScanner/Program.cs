namespace SensorDataScanner
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: SensorDataScanner.exe <cutFilePath>");
                return;
            }

            string filePath = args[0];

            SensorDataScanner scanner = new SensorDataScanner(filePath);
            scanner.ScanSensorData();
        }
    }
}