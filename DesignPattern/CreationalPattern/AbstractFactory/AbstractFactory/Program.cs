using AbstractFactory;

Console.WriteLine("Let's make bikes");

IBicycleFactory roadBikeFactory = new RoadBicycleFactory();

var frame = roadBikeFactory.CreateBicycleFrame();
var handlebars = roadBikeFactory.CreateBicycleHandleBars();

Console.WriteLine("We just made a road bike!");
Console.WriteLine(frame.ToString());
Console.WriteLine(handlebars.ToString());

IBicycleFactory mountainBikeFactory = new MountainBicycleFactory();
Console.WriteLine("We just made a mountain bike!");
frame = mountainBikeFactory.CreateBicycleFrame();
handlebars = mountainBikeFactory.CreateBicycleHandleBars();
Console.WriteLine(frame.ToString());
Console.WriteLine(handlebars.ToString());
