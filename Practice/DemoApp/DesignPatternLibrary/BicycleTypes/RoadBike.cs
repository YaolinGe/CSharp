using DesignPatternLibrary.BikeProperties;

namespace DesignPatternLibrary.BicycleTypes;

public class RoadBike : Bicycle
{
    public RoadBike()
    {
        ModelName = "Road Bike";
        Suspension = SuspensionTypes.Hardtail;
        Color = BicyclePaintColors.Blue;
        Geometry = BicycleGeometries.Upright;
    }
}
