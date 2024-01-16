namespace AbstractFactory;

public class MountainBicycleFactory : IBicycleFactory
{
    public IFrame CreateBicycleFrame()
    {
        return new MountainBikeFrame(); 
    }

    public IHandlebars CreateBicycleHandleBars()
    {
        return new MountainBikeHandlebars(); 
    }
}
