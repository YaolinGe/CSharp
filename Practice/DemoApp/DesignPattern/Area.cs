namespace DesignPattern;

public interface IShape
{
    public double Area { get; }
}

public class Square : IShape
{
    public double Area { get; }

    public Square(double side)
    {
        Area = side * side;
    }
}

public class Circle : IShape
{
    public double Area { get; }

    public Circle(double radius)
    {
        Area = radius * radius * Math.PI;
    }
}

public class Rectangle : IShape
{
    public double Area { get; }

    public Rectangle(double length, double width)
    {
        Area = length * width;
    }
}

public class Triangle : IShape
{
    public double Area { get; }

    public Triangle(double bottom, double height)
    {
        Area = bottom * height / 2;
    }
}

public class AreaCalculator
{
    private List<IShape> shapes = new List<IShape>();

    public void addShape(IShape shape)
    {
        shapes.Add(shape);
    }

    public double getTotalArea()
    {
        double totalArea = 0;
        foreach (IShape shape in shapes)
        {
            totalArea += shape.Area;
        }
        return totalArea;
    }
}
