namespace DesignPatternLibrary;

public class Cruiser : Bike
{
    public Cruiser()
    {
        ModelName = "Cruiser";
        Suspension = SuspensionTypes.Hardtail;
        Color = BicyclePaintColors.Red;
        Geometry = BicycleGeometries.Upright;
    }
}
