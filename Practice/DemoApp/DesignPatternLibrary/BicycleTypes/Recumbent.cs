using DesignPatternLibrary.BikeProperties;

namespace DesignPatternLibrary.BicycleTypes;

public class Recumbent : Bicycle
{
    public Recumbent()
    {
        ModelName = "Recumbent";
        Suspension = SuspensionTypes.Front;
        Color = BicyclePaintColors.White;
        Geometry = BicycleGeometries.Recumbent;
    }
}
