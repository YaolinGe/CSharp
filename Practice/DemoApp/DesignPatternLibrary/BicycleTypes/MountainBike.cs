using DesignPatternLibrary.BikeProperties;
using DesignPatternLibrary.FactoryMethod;
namespace DesignPatternLibrary.BicycleTypes;

//public class MountainBike : Bike
public class MountainBike : Bicycle
{
    public MountainBike()
    {
        ModelName = "Mountain Bike";
        Suspension = SuspensionTypes.Full;
        Color = BicyclePaintColors.Black;
        Geometry = BicycleGeometries.Upright;
    }
}
