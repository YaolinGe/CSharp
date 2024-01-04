//using DemoLibrary; 
using LinqLibrary;

List<Person> people = PersonBuilder.GetPeople();

people = people.Where(x => x.Age > 30).ToList();

people = people.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();

foreach (Person person in people)
{
    Console.WriteLine($"{person.FirstName} {person.LastName} is a {person.Title} and has {person.YearsExperience} years of experience.");
}

