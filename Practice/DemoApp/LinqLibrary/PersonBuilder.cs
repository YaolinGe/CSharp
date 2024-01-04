namespace LinqLibrary;

public class PersonBuilder
{
    public static List<Person> GetPeople()
    {
        List<Person> Persons = new List<Person>();
        Persons.Add(new Person { FirstName = "Tim", LastName = "Corey", Age = 47, YearsExperience = 15, Title = "Owner", Salary = 120000 });
        Persons.Add(new Person { FirstName = "Sue", LastName = "Storm", Age = 27, YearsExperience = 5, Title = "Developer", Salary = 60000 });
        Persons.Add(new Person { FirstName = "Nancy", LastName = "Roman", Age = 37, YearsExperience = 10, Title = "Developer", Salary = 65000 });
        Persons.Add(new Person { FirstName = "Harry", LastName = "Harding", Age = 52, YearsExperience = 20, Title = "VP", Salary = 120000 });
        Persons.Add(new Person { FirstName = "Pam", LastName = "Peters", Age = 55, YearsExperience = 15, Title = "VP", Salary = 125000 });
        Persons.Add(new Person { FirstName = "Mary", LastName = "Maddison", Age = 30, YearsExperience = 7, Title = "Developer", Salary = 65000 });
        Persons.Add(new Person { FirstName = "Frank", LastName = "Fountain", Age = 28, YearsExperience = 6, Title = "Developer", Salary = 60000 });
        return Persons;
    }
}
