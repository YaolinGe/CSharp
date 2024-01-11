namespace DesignPatternLibrary.FactoryMethod;

public abstract class BicycleCreator
{
    public abstract IBicycle CreateProduct(string modelName); 
}
