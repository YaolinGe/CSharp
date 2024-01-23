# C# notes
- `IProductModel` inside each interface, everything has to be public, thus no need to add public in the front of each item.
- interface is like a contract and it has everything declared public to all so that everyone knows what exists in the contract and easy to switch later. I cannot have private method in interface.
- Difference between `abstract` and `interface` is that interface does not implement anything, but only provide a contract to the methods or properties that other classes need to implement. However, abstract method is somewhere in between.
- class needs to inherit from the interface to be able to behave like an interface-enabled class.
- `virtual` in the base class, and `override` in the children class to be able to inherit from the base class and then override it.
- `abstract` keyword should be used in the declaration of the base class and also method inside the base class to declare a abstract method so that the children classes can implement them.
- class library is useful and I think they have used it everywhere in the codebase.
- `people = people.OrderBy(x => x.LastName).ToList(); ` to order the selected list from the library.
- class proliferation leads to stovepipe design.
- `caskaydiacove nerd font` to change `!=` to math unequal to sign.
- `public async Task function()` to return `Task` from a asynchronous function, do not return `void` from an asynchronous method.
- `await` should be used for that specific task.

# CI/CD for web app
- `render.com` can be used to deploy dash app for free.
- `pythongoanywhere.com` can be used to deploy dash app for free.


# Design patterns for C#
## Antipatterns
- Stovepipe systems
- The big ball of mud
- The golden hammer

## SOLID principles
- `SOLID` principle
  - Single responsibility principle
    - One method for one thing
    - One class for one thing
  - Open-closed principle
    - open for extension
    - closed for modification
  - Liskov substitution principle
    - inheritance IS A relationship (square is a rectangle)
  - Interface segregation principle
    - interfaces can be inherited
  - Dependency inversion principle  
    - Dependency injection (DI) is different
    - Inversion of control (IOC) is different
- Code Review
  - overall design: domain-driven Design, behavior-driven design
  - functionality

### Creational pattern
- <<Enumeration>> can be used to define those magic numbers.
- in UML, `italicized` class name is interpreted as an abstract class.
- in UML, access modifiers and types can be left out as those are implementation details and can be changed very quickly. Can be added if both developer and architect is the same person.
- `Simple Factory` is like hello world like an idiom used for beginners.
- `Factory Method` is use interface to link the product.
- `abstract factory method` is to separate different parts from each factory.
- `builder pattern` is essential composing different procedures together.
- `object pool` to have a pool of object instances to make concurrent distribution.
- `singleton` to only have one instance over the whole program, to make it not changeble by other parts of the program.


### Structural pattern
- Helps to maintain flexibility and efficiency.
- `Decorator pattern` wrapping functions into extensions, but not modify the base class.
- `Facade pattern` to wrap the API calls to avoid dependency to different API providers, avoid tight coupling. It has a wrapper to talk to different APIs to fix the coupling issues. Remember to name the function generally to better remove the detailed implementation of each method.
- `Composite pattern` makes the main component based on many subcomponents, and they share some common properties.
- `Bridge pattern` 




### Behavior pattern


### Dispose pattern
- `using PureManagedClass pmc = new PureManagedClass(); ` to properly use the dispose method once it is finished with the nearest curly braces. If `using` keyword is ignored, then it might not manage the resources responsibly.
- better use dispose instead of finalizer, finalizer is slow and inefficient.


## UML
- OOAD (object-oriented analysis and design)
-

### Boxing and unboxing
- Allows the value types to be treated as reference types and vice versa.
- Values types:
  - Saved on the stack
  - Can implement interface
- Reference types:
  - Saved on the heap
  - Examples:
    - arrays
    - classes
    - strings
- Boxing:
  - Wrap the value type in an object, so it can be used as an object.
- Unboxing:
  - When a method returns an object, but we need a value type, then it is needed.
- Stack:
  - Memory allocated to the code which is currently running on the CPU
  - When the stack frame has finished executing, value are removed
- Heap:
  - Memory shared acorss many applications running the OS at the same time

- Learn more about async and other features used in C# project
- always check which user I am using for github.

# Notes for C# learning from both Udemy and Microsoft Learn.
- `stuct` variable always live in stack if they don't belong to any class object.
- `int`, `double`, `datetime` live in stack as they are small.
- `static` function cannot access global variables.
- once a new function is created, then a separate stack region is created as well to separate the concern from other areas.
- every method gets its own stack frame.
- `class` lives on the heap memory.
- `(x is null) == (!x.HasValue)` are the same, but the first one is preferred.
- large object is probably long-living object.

`\t, \n, \\` to add escape character, note that `\t` only moves the cursor to the next 8 position, so if the word itself is already 7, then it looks like a space.
`stateless method` such as Console.WriteLine(), no need to know the state.
`stateful method` such as instance method, needs to know the state.


## Here comes some of the explanation for different headers:
`System.Linq` data management.
`System.Threading` multithreading processes.
`var number = 2; ` automatically detect datatype for variable number.
`const` to make value constant so no acidentally changed.
`(byte)` to cast the data to explicitly convert data types.
`Convert.ToInt32(s)` to forcefully convert string to a integer.
`int.Parse(s)` to parse the string to integer.
`Add classes or folder` to make it locate in the right namespace.
`string is immutable` so once it is created, it cannot be changed.
`string path = @"C:\projects\etc"; ` to remove extra unnecessary `\\`.
`Int32 == int` C# maps the primitive data types to .NET data types.
`string.Join(", ", string_array)` to concatenate the arrays with the punctual mark.
`typeof` to get the type of the target object.
`string (System.String)` and `arrays (System.Array)` are classes, and they thus have their methods.
`primitive` data types are `structure`
`Trim()` remove extra spaces at the beginning or end of the string.
`StringBuilder.Append('-', 10)
              .Append()
              .Append("Header")
              .AppendLine()
              .Append('-', 10)
              .Replace('-', '+'),
              .Remove()` to gather all the repeating commands.
`F5` runs the debug mode.
`Ctrl + F5` runs without debug mode.
`ctor` to create a snippet for constructor.
`ildasm program.exe` in the `program/bin/Debug` folder to check the IL compiled.
`prop` to activate resharper or intellisense to generate properties for the class.
`public Car(string registrationNumber) : base(registrationNumber)`
`Downcasting and Upcasting` are important concepts to grasp.
`virtual` to make it possible to be overriden.
`override` to override the previous step.
`F10, F11` are very useful commands to add the watch of the program to check if the variable is correct.
`abstract` to make it an empty class which misses implementation, cannot have implementation.
`sealed` is slightly faster.
`interface` to create an interface, no implementation, no access modifiers
`OpenClosePrinciple`

### String
- `TrimStart()`
- `Trim()`
- `TrimEnd()`
- `Contains()`
- `Replace()`
- `ToUpper()`
- `ToLower()`
- `StartsWith()`
- `EndsWith()`

### Numbers and integer maths
- `int.MaxValue`
- `int.MinValue`
- `int.ToString()` to convert int to string.

### Branches (if/else)
`using` to import a library to make use of other people's module.

### Sort, Search and Index
`Sort()`
`IndexOf()`
`Index("name")`

### String
`StringBuilder().ToString()` to build a long formatted text in string format.

## Overflow
To check the overflow:
```
checked
{
  byte number = 255;
  number = number + 1;
}
```

### LINQ
`https://github.com/dotnet/try-samples` in github, check out it and download to local repo and start trying this repo.
`https://github.com/YaolinGe/csharp-notebooks` to check out all the useful notebooks for C#.
`https://try.dot.net` useful resource.
`https://dotnet.microsoft.com/en-us/learn/videos` to watch all useful videos.
`https://www.youtube.com/watch?v=UGQP9hEakZk&list=PL8h4jt35t1wjvwFnvcB2LlYL4jLRzRmoz&pp=iAQB` to watch all useful blazor project videos.

### Packages
- `dotnet add package <name> ` to install am new package.
- `dotnet tool install <name>` to install global tools.
- `dotnet list package` to list all the installed packages.
- `dotnet list package --include-transitive` to list all packages including their parental packages.
- `dotnet restore` to restore all the packages.
- `dotnet remove package <name> ` to remove the unused packages.
- `dotnet --list-sdks` to show all the SDK installed.

### Debug and traces
`System.Diagnostics.Debug` to debug.
`System.Diagnostics.Trace` to trace.

### Files and directories
`Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories)` to list all files in the folder.
`Path.DirectorySeparatorChar` to separate the folder string.
`Path.Combine("a1", "b1")` to output the proper path.
`Path.GetExtension("sales.json")` to get the extension of a file.
`FileInfo(fileName)` to get the info of the file.
`DirectoryInfo(directoryName)` to get the info of the directory.
`info.FullName`
`info.Directory`
`info.Extension`
`info.CreationTime`
`Directory.CreateDirectory(Path.Combine("f1", "f2"))` to create directories recursively.
`Directory.Exists(filePath)` to check if a file exists or not.
`File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "greeting.txt"), "Hello World!")` to creat a file called `greeting.txt` including content `Hello World!`.
`File.ReadAllText()` to read all text content.
`variable?` means the varibale can either be null or something.

### WebAPI
`dotnet new webapi -f net7.0` to create a startup project.

### BlazorApp
`dotnet new blazorserver -f net7.0` to create a new blazor server app.
`@layout AdminLayout` can specify a sepcfic layout for the desired page.
`_Imports.razor`

## Shortcut
`Ctrl + Shift + B` compile the code
`Ctrl + Fn + F5` debug the code and see the output from the terminal console
`cw` is Console.WriteLine in Visual Studio to boost the efficiency
`Ctrl + Alt + J` open object browser
`Ctrl + Shift + Y` to show/hide the debug console in VS code.
