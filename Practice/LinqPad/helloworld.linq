<Query Kind="Statements" />

string[] languages = new string[] { "English", "French", "Portuguese", "Spanish" };
foreach (string language in languages)
{
    Console.WriteLine(language);
}

Console.Write("What is your name: ");
string myName;
myName = Console.ReadLine();
Console.WriteLine();
Console.WriteLine($"Hello, {myName}");