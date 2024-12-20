# Dan's ConversionCalc Library

An easy-to-implement function library providing generic numeric
conversions in a wide array of possible scenarios for engineering and
practical applications.

Basic Example:

```cs
using System;
using ConversionCalc;

// Simplest possible use of ConversionCalc.Converter.
namespace MyProject
{
 public class Program
 {
  public static void Main(string[] args)
  {
   Converter converter = new Converter();
   double toValue = converter.Convert(60, "mph", "mi/sec");
   Console.WriteLine($"Answer: {toValue} mi/sec");
  }
 }
}

```

For more information, please see the GitHub project:
[danielanywhere/ConversionCalc](https://github.com/danielanywhere/ConversionCalc)

