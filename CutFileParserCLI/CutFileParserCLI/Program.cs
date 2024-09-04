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

            // Gen 1
            //List<string> sensors = new List<string>
            //{
            //    //"BobbenAccelerometerX",
            //    //"BobbenAccelerometerY",
            //    "Box1Accelerometer2GRaw0",
            //    "Box1Accelerometer2GRaw1",
            //    "Box1Accelerometer2GRaw2",
            //    "Box1Accelerometer50GRaw0",
            //    "Box1Accelerometer50GRaw1",
            //    "Box2StrainRaw0",
            //    "Box2StrainRaw1",
            //    "Box3Clock",
            //    "Box1ClockPeripheral",
            //    "Box2ClockPeripheral",
            //    "Deflection",
            //    "Load",
            //    "SurfaceFinish",
            //    "Vibration",
            //    "Temperature"
            //};


            // Gen 2
            List<string> sensors = new List<string>
            {
                "BenderStrainRaw0",
                "BenderStrainRaw1",
                "ZeldaClock",
                "PacmanClockPeripheral",
                "BenderClockPeripheral",
                "PacmanAccelerometerRaw0",
                "PacmanAccelerometerRaw1",
                "PacmanAccelerometerRaw2",
                "Deflection",
                "Load",
                "SurfaceFinish",
                "Vibration",
                "Temperature",
                "SP1",
                "U1",
                "W1",
                "X1",
                "Z1",
            }; 

            CutFileParser parser = new CutFileParser(filePath);
            await parser.SaveSensorDataToCSVsAsync(filePath, sensors);
        }
    }
}

