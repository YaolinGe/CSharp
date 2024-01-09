
namespace DesignPatternLibrary;

public class MountainBike : Bike
{
    public MountainBike()
    {
        ModelName = "Mountain Bike";
        Suspension = SuspensionTypes.Full;
        Color = BicyclePaintColors.Black;
        Geometry = BicycleGeometries.Upright;
    }
}
