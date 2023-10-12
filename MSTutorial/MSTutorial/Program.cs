//Console.WriteLine("Hello World!"); 

//string aFriend = "Bill"; 
//Console.WriteLine(aFriend);
//aFriend = "Maira"; 
//Console.WriteLine(aFriend);
//Console.WriteLine("Hello " + aFriend);
//Console.WriteLine($"Hello {aFriend}");

//string firstFriend = "Maria"; 
//string secondFriend = "Sage"; 
//Console.WriteLine($"My friends are {firstFriend} and {secondFriend}");
//Console.WriteLine($"The name {firstFriend} has {firstFriend.Length} letters. ");
//Console.WriteLine($"The name {secondFriend} has {secondFriend.Length} letters.");

//string greeting = "       Hello World!        "; 
//Console.WriteLine($"[{greeting}]");

//string trimmedGreeting = greeting.TrimStart();
//Console.WriteLine($"[{trimmedGreeting}]");

//trimmedGreeting = greeting.TrimEnd(); 
//Console.WriteLine($"[{trimmedGreeting}]");

//trimmedGreeting = greeting.Trim();
//Console.WriteLine($"[{trimmedGreeting}]");

//string sayHello = "Hello World!"; 
//Console.WriteLine(sayHello);
//sayHello = sayHello.Replace("Hello", "Greetings"); 
//Console.WriteLine(sayHello);

//Console.WriteLine(sayHello.ToUpper());
//Console.WriteLine(sayHello.ToLower());

//string songLyrics = "You say goodbye, and I say hello"; 
//Console.WriteLine(songLyrics.Contains("goodbye"));
//Console.WriteLine(songLyrics.Contains("greetings"));

//Console.WriteLine(songLyrics.StartsWith("Y"));
//Console.WriteLine(songLyrics.StartsWith("You "));
//Console.WriteLine(songLyrics.EndsWith("hello"));
//Console.WriteLine(songLyrics.EndsWith("goodbye"));
//Console.WriteLine(songLyrics.EndsWith("o"));


// ================================================================

//int a = 5;
//int b = 4;
//int c = 2;
//int d = a + b * c; 
//Console.WriteLine(d);
//d = (a + b) * c; 
//Console.WriteLine(d);
//d = (a + b) - 6 * c + (12 * 4) / 3 + 12; 
//Console.WriteLine(d);
//d = (a + b) / c; 
//Console.WriteLine(d);

//int a = 7;
//int b = 4;
//int c = 3;
//int d = (a + b) / c;
//int e = (a + b) % c; 
//Console.WriteLine($"quotient: {d}");
//Console.WriteLine($"remainder: {e}");

//int max = int.MaxValue;
//int min = int.MinValue; 
//Console.WriteLine($"The range of integers is {min} to {max}");

//int what = max + 3; 
//Console.WriteLine($"An example of overflow: {what}");

//double a = 5;
//double b = 4;
//double c = 2;
//double d = (a + b) / c; 
//Console.WriteLine(d);

//a = 19;
//b = 23;
//c = 8;
//d = (a + b) / c; 
//Console.WriteLine(d);

//double max = double.MaxValue; 
//double min = double.MinValue;
//Console.WriteLine($"The range of double is {min} to {max}");

//double third = 1.0 / 3.0; 
//Console.WriteLine(third);

//decimal min = decimal.MinValue;
//decimal max = decimal.MaxValue; 
//Console.WriteLine($"The range of the decimal type is {min} to {max}");

//double a = 1.0;
//double b = 3.0; 
//Console.WriteLine(a / b);

//decimal c = 1.0M; 
//decimal d = 3.0M; 
//Console.WriteLine(c / d);
//Console.WriteLine($"Pi is {Math.PI}");

//double radius = 2.50;
//double area = Math.PI * Math.Pow(radius, 2); 
//Console.WriteLine($"Area of a radius {radius} is {area}");

// ================================================================

//using System.ComponentModel.Design;

//int a = 5;
//int b = 3;
//if (a + b > 10)
//    Console.WriteLine("The answer is greater than 10. ");
//else
//    Console.WriteLine("The answer is not greater than 10. ");

//int c = 4;
//if ((a + b + c > 10) && (a == b))
//{
//    Console.WriteLine("The answer is greater than 10");
//    Console.WriteLine("And the first number is equal to the second");
//}
//else
//{
//    Console.WriteLine("The answer is not greater than 10");
//    Console.WriteLine("Or the first number is not equal to the second");
//}

//int counter = 0;
//while (counter < 10)
//{
//    Console.WriteLine($"Hello World! The counter is {counter}");
//    counter++; 
//}

//do
//{
//    Console.WriteLine($"Hello world! The counter is {counter}");
//    counter++; 
//}while (counter < 10);

//for (int counter = 0; counter < 10; counter++)
//{
//    Console.WriteLine($"Hello world! The counter is {counter}");
//}

//for (int row = 1; row < 11; row++)
//{
//    Console.WriteLine($"The row is {row}");
//}

//for (char column = 'a'; column < 'k'; column++)
//{
//    Console.WriteLine($"The column is {column}");
//}

//for (int row = 1; row < 11; row++)
//{
//    for (char column = 'a'; column < 'k'; column++)
//    {
//        Console.Write($"The cell is ({row}, {column}) \t");
//    }
//    Console.WriteLine();
//}

//var sum = 0;
//for (var cnt = 1; cnt <= 20; cnt++)
//{
//    if (cnt % 3 == 0)
//    {
//        sum += cnt; 
//    }
//}
//Console.WriteLine($"The sum is {sum}");

// ================================================================

var names = new List<string> { "Yaolin", "Ana", "Felip" };
//foreach (var name in names)
//{
//    Console.WriteLine($"Hello {name.ToUpper()}!");
//}

//Console.WriteLine(); 
//names.Add("Maria");
//names.Add("Bill");
//names.Remove("Ana");
//foreach (var name in names)
//{
//    Console.WriteLine($"Hello {name.ToUpper()}!");
//}

//Console.WriteLine($"My name is {names[0]}.");
//Console.WriteLine($"I've added {names[2]} and {names[3]} to the list. ");
//Console.WriteLine($"The list has {names.Count} people in it");

//var index = names.IndexOf("Felip");
//if (index != -1)
//{
//    Console.WriteLine($"The name {names[index]} is at index {index}");
//}
//var notFound = names.IndexOf("Not Found"); 
//Console.WriteLine($"When an item is not found, IndexOf returns {notFound}");

//names.Sort();
//foreach (var name in names)
//{
//    Console.WriteLine($"Hello {name.ToUpper()}!");
//}

var fibonacciNumbers = new List<int> { 1, 1 };

for (var i = 2; i < 20; i++)
{
    var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
    var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];
    fibonacciNumbers.Add(previous + previous2);
}

foreach (var item in fibonacciNumbers)
{
    Console.WriteLine(item);
}
