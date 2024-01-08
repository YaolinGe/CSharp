namespace LinqLibrary;

public class Person
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName => $"{FirstName} {LastName}";
    public string? Title { get; set; }
    public int Age { get; set; }
    public int YearsExperience { get; set; }
    public int Salary { get; set; }
}