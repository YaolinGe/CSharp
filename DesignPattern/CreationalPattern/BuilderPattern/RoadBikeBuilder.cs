namespace BuilderPattern;

public class RoadBikeBuilder : IBicycleBuilder
{
    private BicycleProduct _bicycle; 

    public RoadBikeBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        _bicycle = new BicycleProduct(); 
    }

    public void BuildFrame()
    {
        _bicycle.Frame = new RoadBikeFrame(); 
    }
}
