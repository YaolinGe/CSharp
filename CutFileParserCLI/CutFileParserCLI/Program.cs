namespace CutFileParser
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: CutFileParserCLI.exe <cutFilePath>");
                return;
            }

            string filePath = args[0];

            List<string> sensors = new List<string>
            {
                //"BobbenAccelerometerX",
                //"BobbenAccelerometerY",
                "Box1Accelerometer2GRaw0",
                "Box1Accelerometer2GRaw1",
                "Box1Accelerometer2GRaw2",
                "Box1Accelerometer50GRaw0",
                "Box1Accelerometer50GRaw1",
                "Box2StrainRaw0",
                "Box2StrainRaw1",
                "Box3Clock",
                "Box1ClockPeripheral",
                "Box2ClockPeripheral",
                "Deflection",
                "Load",
                "SurfaceFinish",
                "Vibration",
                "Temperature"
            };

            CutFileLoader loader = new CutFileLoader(filePath);

            // Save sensor data to a Protobuf file
            //await loader.SaveSensorDataToProtobuf(filePath, sensorName);
            foreach (string sensorName in sensors)
            {
                await loader.SaveSensorDataToCSV(filePath, sensorName);
            }
        }
    }
}

