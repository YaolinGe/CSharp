namespace CutFileParser
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: CutFileParserCLI.exe <cutFilePath> <generation:Gen1|Gen2> <parallel:true|false> <outputDirectory>");
                return;
            }

            string filePath = args[0];
            string generation = args[1];
            bool useParallel = bool.Parse(args[2]);
            string outputDirectory = args.Length > 3 ? args[3] : Path.Combine(Path.GetTempPath(), "CutFileParser"); 

            List<string> sensors;
            if (generation.Equals("Gen1", StringComparison.OrdinalIgnoreCase))
            {
                sensors = GetGen1Sensors();
            }
            else
            {
                sensors = GetGen2Sensors();
            }

            CutFileParser parser = new CutFileParser(filePath);

            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            if (useParallel)
            {
                await parser.SaveSensorDataToCSVsAsync(filePath, sensors, outputDirectory);
            }
            else
            {
                foreach (string sensorName in sensors)
                {
                    await parser.SaveSensorDataToCSV(filePath, sensorName, outputDirectory);
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Parsing completed in {stopwatch.Elapsed.TotalSeconds} seconds. Parallel: {useParallel}");
        }

        private static List<string> GetGen1Sensors()
        {
            return new List<string>
            {
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
        }

        private static List<string> GetGen2Sensors()
        {
            return new List<string>
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
                "Z1"
            };
        }
    }
}