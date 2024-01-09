using DesignPatternLibrary;
namespace DesignPattern;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bike test");
        const string errorText = "You must pass in mountainbike, cruiser, recumbent, or roadbike";
        if (args.Length > 0)
        {
            var bicycleType = args[0].Trim().ToLower();
            var bikeFactory = new SimpleBikeFactory();
            var bikeToBuild = bikeFactory.CreateBike(bicycleType);
            bikeToBuild.Build();
        }
        else
        {
            Console.WriteLine(errorText);
        }


        //Console.WriteLine("Area Test");
        //var areaCalculator = new AreaCalculator();
        //areaCalculator.addShape(new Square(5));
        //areaCalculator.addShape(new Circle(5));
        //areaCalculator.addShape(new Rectangle(5, 5));
        //areaCalculator.addShape(new Triangle(5, 5));
        //Console.WriteLine(areaCalculator.getTotalArea());

    }
}