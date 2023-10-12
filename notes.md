# Notes for C#


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


## Shortcut
`Ctrl + Shift + B` compile the code
`Ctrl + Fn + F5` debug the code and see the output from the terminal console
`cw` is Console.WriteLine in Visual Studio to boost the efficiency
`Ctrl + Alt + J` open object browser
