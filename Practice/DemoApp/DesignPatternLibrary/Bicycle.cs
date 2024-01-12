using DesignPatternLibrary.BikeProperties;
using DesignPatternLibrary.FactoryMethod;
namespace DesignPatternLibrary;

public abstract class Bicycle : IBicycle
{
    protected Bicycle()
    {
        ModelName = string.Empty; // will be filled in subclass 
                                  // constructor 
        SerialNumber = new Guid().ToString();
        Year = DateTime.Now.Year;
        BuildStatus = ManufacturingStatus.Specified;
    }

    public string ModelName { get; set; }
    public int Year { get; }
    public string SerialNumber { get; }
    public BicyclePaintColors Color { get; set; }
    public BicycleGeometries Geometry { get; set; }
    public SuspensionTypes Suspension { get; set; }
    public ManufacturingStatus BuildStatus { get; set; }

    public void Build()
    {
        Console.WriteLine($"Manufacturing a {Geometry} frame...");
        BuildStatus = ManufacturingStatus.FrameManufactured;
        PrintBuildStatus();

        Console.WriteLine($"Painting the frame {Color}");
        BuildStatus = ManufacturingStatus.Painted;
        PrintBuildStatus();

        if (Suspension != SuspensionTypes.Hardtail)
        {
            Console.WriteLine($"Mounting the {Suspension} suspension.");
            BuildStatus = ManufacturingStatus.SuspensionMounted;
            PrintBuildStatus();
        }

        Console.WriteLine("{0} {1} Bicycle serial number {2} manufacturing complete!", Year, ModelName, SerialNumber);
        BuildStatus = ManufacturingStatus.Complete;
        PrintBuildStatus();
    }

    public void PrintBuildStatus()
    {
        Console.WriteLine($"Build Status: {BuildStatus}");
    }
}

