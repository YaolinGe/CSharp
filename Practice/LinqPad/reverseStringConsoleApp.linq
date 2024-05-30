<Query Kind="Program" />

void Main() 
{
	Console.WriteLine("Enter the string you want to reverse: "); 
	string myString = Console.ReadLine(); 
	
	DisplayResult(ReverseString(myString)); 
	
	Console.WriteLine(); 
}

string ReverseString(string message)
{
	char[] charArray = message.ToCharArray(); 
	Array.Reverse(charArray); 
	return String.Concat(charArray); 
}

void DisplayResult(string message)
{
	Console.WriteLine($"Your backwards string is: {message}"); 
}