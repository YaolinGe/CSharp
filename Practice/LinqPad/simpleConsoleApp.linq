<Query Kind="Program" />

void Main()
{
	Console.WriteLine("Tell me about yourself. "); 
	Console.WriteLine("Type your first name: "); 
	
	string myFirstName; 
	myFirstName = Console.ReadLine(); 
	
	Console.WriteLine("Type your last name: "); 
	string myLastName = Console.ReadLine(); 
	
	Console.WriteLine("What year were you born? "); 
	int myBirthYear = Convert.ToInt32(Console.ReadLine()); 
	
	Console.WriteLine(); 
	Console.WriteLine("Hello, " + myFirstName + " " + myLastName); 
	
	int myAge = DateTime.Now.Year - myBirthYear; 
	Console.WriteLine("This year, you will be " + myAge + " years old. " ); 
	
	int newAge = myAge + 5; 
	Console.WriteLine("In 5 years, you will have " + newAge + " years. "); 
	Console.ReadLine(); 
}

// You can define other methods, fields, classes and namespaces here
