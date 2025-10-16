# Dan's ConversionCalc Library

An easy-to-implement function library providing generic numeric conversions in a wide array of possible scenarios for engineering and practical applications.


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

## Updates

| Version | Description |
|---------|-------------|
| 25.3016.3818 | Added the remaining concrete CSS Unit Measurements **pc**, **pt**, and **px** (examples of the relative measurements **ch**, **em**, **ex**, **rem**, **vh**, **vmax**, **vmin**, and **vw** are available in the example source at the GitHib page) to the **Distance** domain; Added **External** conversion entry type with associated events **ResolveValueToBase** and **ResolveBaseToValue** to handle external down-conversion and up-conversion steps, respectively. |
| 25.1109.1402 | Intellisense support added. |
| 25.1104.1240 | Added overload method **public double Convert(string domainName, double sourceValue, string sourceUnit,string targetUnit)**. This provides a method by which you can perform a domain-specific conversion with a case-insensitive partial name of the intended conversion category; **Angles** and **Circles** conversion categories have been added to the default rule set. |
| 24.1220.1425 | Initial public release. |


## More Information

For more information, please see the GitHub project:
[danielanywhere/ConversionCalc](https://github.com/danielanywhere/ConversionCalc)

Full API documentation is available at this library's [GitHub User Page](https://danielanywhere.github.io/ConversionCalc).
