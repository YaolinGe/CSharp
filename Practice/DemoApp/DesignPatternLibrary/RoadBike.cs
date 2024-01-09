
namespace DesignPatternLibrary;

public class RoadBike : Bike
{
    public RoadBike()
    {
        ModelName = "Road Bike";
        Suspension = SuspensionTypes.Hardtail;
        Color = BicyclePaintColors.Blue; 
        Geometry = BicycleGeometries.Upright;
    }
}
