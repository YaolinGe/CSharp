using DesignPatternLibrary.BicycleTypes;
namespace DesignPatternLibrary.SimpleFactoryMethod;

public class SimpleBikeFactory
{
    public Bicycle CreateBike(string bikeType)
    {
        Bicycle bikeToBuild;
        switch (bikeType)
        {
            case "mountainbike":
                bikeToBuild = new MountainBike();
                break;
            case "roadbike":
                bikeToBuild = new RoadBike();
                break;
            case "cruiser":
                bikeToBuild = new Cruiser();
                break;
            case "recumbent":
                bikeToBuild = new Recumbent();
                break;
            default:
                throw new Exception("Unknown bicycle type: " + bikeType);
        }
        return bikeToBuild;
    }
}
