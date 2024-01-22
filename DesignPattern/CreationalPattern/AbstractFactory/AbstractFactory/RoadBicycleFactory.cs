namespace AbstractFactory;

public class RoadBicycleFactory : IBicycleFactory
{
    public IFrame CreateBicycleFrame()
    {
        return new RoadBikeFrame(); 
    }

    public IHandlebars CreateBicycleHandleBars()
    {
        return new RoadBikeHandlebars(); 
    }
}
