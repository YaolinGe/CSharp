# Notes for the book C# .net in a nutshell

- `dynamic` can be used to use dynamic typing in C#, but it is not recommended to use it as it can lead to runtime errors.
- `ildasm` tool can be used to convert IL back to C#, some examples such as `ILSpy` and JetBrains `dot-Peek` are useful tools.
- `unsafe` marks the block that pointers and explicit memory allocation are used. Most of pointer tasks are automatically done by C#, so the programmers do not need to use pointers in most of cases.
- `return 0; ` often means no error, where return other number often means something is wrong with the system.
- `F#` might be better for data processing, and `C#` might be better for GUI and web applications.