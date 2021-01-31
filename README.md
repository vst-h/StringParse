# StringParse
Provides a Parse generic extension method for string that converts string to T and no boxing occurs.
``` C#
// The following code does not occur boxing
var a1 = "123".Parse<int>();        // a1 == 123
var a3 = "123".Parse<int?>();       // a3 == 123
```

# Usage example
``` C#
using System;
using System.Globalization;
using StringParse;

void Exmaple1() {
    _ = "12".Parse<int>();      // 12
    // _ = "ss".Parse<int>();      // throw FormatException

    // with default value, Actually call the TryParse method internally
    _ = "12".Parse(10);     // 12
    _ = "ss".Parse(10);     // 10

    // with NumberStyles
    _ = "F".Parse<int>(NumberStyles.HexNumber);      // 15

    // parse Nullable
    _ = "12".Parse<int?>();      // 12
    // _ = "ss".Parse<int?>();      // throw FormatException

    // TryParse
    _ = "12".TryParse(out int _);      // true
    _ = "ss".TryParse(out int _);      // false

    // Parse Enum
    _ = "Saturday".ParseEnum<DayOfWeek>();          // DayOfWeek.Saturday
    _ = "Saturday".TryParseEnum(out DayOfWeek _);   // true
}
```