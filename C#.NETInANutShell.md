# Notes for the book C# .net in a nutshell

## Ch2, C# language basics
- `int million = 1_000_000` to make it more readable after C#.
- `var b = 0b1010_1011_1100_1101_1110_1111;` for binary.
- `double d = 1E06; ` to use exponential notation.
- `--int.MinValue == int.MaxValue` overflow.
- `checked` and `unchecked` can enable Exception or disable it during runtime.
- `decimal` and `double` both exhibit numerical real-number rounding errors.
- `@""` can include `""` inside verbatim expression in the string literal.
- `Index first = 0; Index last = ^1;` to indicate the indices for an array.
- `Range firstTwoRange = 0..2` to add indices for a range.
- `ref`can be useful for performance gains as it does not copy the whole value type. Instead, it only copies the reference to that value type.

- `dynamic` can be used to use dynamic typing in C#, but it is not recommended to use it as it can lead to runtime errors.
- `ildasm` tool can be used to convert IL back to C#, some examples such as `ILSpy` and JetBrains `dot-Peek` are useful tools.
- `unsafe` marks the block that pointers and explicit memory allocation are used. Most of pointer tasks are automatically done by C#, so the programmers do not need to use pointers in most of cases.
- `return 0; ` often means no error, where return other number often means something is wrong with the system.
- `F#` might be better for data processing, and `C#` might be better for GUI and web applications.


Page 139
