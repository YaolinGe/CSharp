//using DemoLibrary; 
//using LinqLibrary;

//List<Person> people = PersonBuilder.GetPeople();

//people = people.Where(x => x.Age > 30).ToList();

//people = people.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();

//foreach (Person person in people)
//{
//    Console.WriteLine($"{person.FirstName} {person.LastName} is a {person.Title} and has {person.YearsExperience} years of experience.");
//}
using ConsoleUI;
namespace GarbageCollection;

class Program
{
    static void ShortLives(Person parent)
    {
        Person fred = new Person
        {
            Name = "Fred",
            ChildOne = new Person
            {
                Name = "Bamm-Bamm"
            }
        };
        parent.ChildTwo = fred.ChildOne;
    }

    static void Run()
    {
        Person wilma = new Person
        {
            Name = "Wilma",
            ChildOne = new Person { Name = "Pebbles" }
        };

        ShortLives(wilma);

        Console.WriteLine("Leaving 'ShortLives'...");

        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    static void Main()
    {
        Run();
        Console.WriteLine("\n Leaving 'Run'...");

        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}


//public class Program
//{
//    static void Run()
//    {
//        PureManagedClass pureManagedClass = new PureManagedClass();

//        pureManagedClass.StartWriting();

//    }

//    static void Main()
//    {
//        Run();
//        Console.WriteLine("Finished disposing. ");
//        GC.Collect();
//        GC.WaitForPendingFinalizers();
//    }
//}


//Console.WriteLine("Hello"); 
//List<IControlSystem> platforms = new List<IControlSystem>();
//platforms.Add(new Car());
//platforms.Add(new Plane());

//foreach (IControlSystem platform in platforms)
//{
//    Console.WriteLine(platform.Accelerate());
//}



