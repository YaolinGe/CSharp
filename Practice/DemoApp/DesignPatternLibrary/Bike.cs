namespace DesignPatternLibrary;

public abstract class Bike
{
    protected string ModelName { get; init; }
    private int Year { get; set; }
    private string SerialNumber { get; }
    protected BicyclePaintColors Color { get; init; }
    protected BicycleGeometries Geometry { get; init; }
    protected SuspensionTypes Suspension { get; init; }
    private ManufacturingStatuses BuildStatus { get; set; }

    public Bike()
    {
        ModelName = string.Empty; 
        SerialNumber = Guid.NewGuid().ToString();
        Year = DateTime.Now.Year;
        BuildStatus = ManufacturingStatuses.Specified;
    }

    public void Build()
    {
        Console.WriteLine($"Manufacturing a {Geometry} frame...");
        BuildStatus = ManufacturingStatuses.FrameManufactured;
        PrintBuildStatus();

        Console.WriteLine($"Painting the frame {Color}");
        BuildStatus = ManufacturingStatuses.Painted;
        PrintBuildStatus();

        if (Suspension != SuspensionTypes.Hardtail)
        {
            Console.WriteLine($"Mounting the {Suspension} suspension.");
            BuildStatus = ManufacturingStatuses.SuspensionMounted;
            PrintBuildStatus();
        }

        Console.WriteLine("{0} {1} Bicycle serial number {2} manufacturing complete!", Year, ModelName, SerialNumber);
        BuildStatus = ManufacturingStatuses.Complete;
        PrintBuildStatus();
    }

    public void PrintBuildStatus()
    {
        Console.WriteLine($"Build Status: {BuildStatus}");
    }
}

