using DesignPatternLibrary.BikeProperties;

namespace DesignPatternLibrary.BicycleTypes;

public class Cruiser : Bicycle
{
    public Cruiser()
    {
        ModelName = "Cruiser";
        Suspension = SuspensionTypes.Hardtail;
        Color = BicyclePaintColors.Red;
        Geometry = BicycleGeometries.Upright;
    }
}
