namespace DesignPatternLibrary;

public class Recumbent : Bike
{
    public Recumbent()
    {
        ModelName = "Recumbent";
        Suspension = SuspensionTypes.Front;
        Color = BicyclePaintColors.White;
        Geometry = BicycleGeometries.Recumbent;
    }
}
