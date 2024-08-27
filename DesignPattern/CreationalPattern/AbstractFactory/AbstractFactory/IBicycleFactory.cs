namespace AbstractFactory;

public interface IBicycleFactory
{
    public IFrame CreateBicycleFrame();
    public IHandlebars CreateBicycleHandleBars(); 
}
