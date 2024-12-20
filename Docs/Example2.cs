using System;
using ConversionCalc;

// Multiple conversions for different domains for
// user input of 1000 km/sec to mi/hr.
namespace MyProject
{
 public class Program
 {
  public static void Main(string[] args)
  {
   Converter converter = new Converter();
   ConversionDomainItem domain = null;
   string fromUnit = "";
   Match match = null;
   string toUnit = "";
   string userInput = "1000 km/sec to mi/hr";
   double value = 0d;

   Console.WriteLine($"Convert {userInput}.");
   match = Regex.Match(userInput,
    @"^\s*(?<value>-{0,1}[0-9]+(\.[0-9]+){0,1})\s+" +
    @"(?<fromUnit1>\w+)\s*(\s*/\s*(?<fromUnit2>\w+)){0,1}\s+to\s+" +
    @"(?<toUnit>(?<toUnit1>\w+)\s*(\s*/\s*(?<toUnit2>\w+)){0,1})");
   if (match.Success)
   {
    //	The first conversion is required.
    value = ToDouble(GetValue(match, "value"));
    fromUnit = GetValue(match, "fromUnit1");
    toUnit = GetValue(match, "toUnit1");
    if (fromUnit.Length > 0 && toUnit.Length > 0)
    {
     //	From and to were both provided.
     domain = converter.FindDomain(fromUnit, toUnit);
     if (domain != null)
     {
      //	A common domain was found.
      Console.WriteLine($"Using domain: {domain.DomainName}");
      value = converter.Convert(domain, value, fromUnit, toUnit);
      Console.WriteLine($"Intermediate. {toUnit} = {value}.");
      //	The second conversion is optional.
      domain = null;
      fromUnit = GetValue(match, "fromUnit2");
      toUnit = GetValue(match, "toUnit2");
      if ((fromUnit.Length > 0 || toUnit.Length > 0) &&
       (fromUnit.Length == 0 || toUnit.Length == 0))
      {
       //	Only one unit was supplied.
       if (fromUnit.Length > 0)
       {
        //	The from unit was supplied. Get the default to unit.
        domain = converter.FindDomain(fromUnit);
        if (domain != null &&
         domain.Conversions.Exists(x =>
          x.EntryType == ConversionDefinitionEntryType.Base))
        {
         toUnit = domain.Conversions.First(x =>
          x.EntryType == ConversionDefinitionEntryType.Base).Name;
        }
       }
       else
       {
        //	The to unit was supplied. Get the default from unit.
        domain = converter.FindDomain(toUnit);
        if (domain != null &&
         domain.Conversions.Exists(x =>
          x.EntryType == ConversionDefinitionEntryType.Base))
        {
         fromUnit = domain.Conversions.First(x =>
          x.EntryType == ConversionDefinitionEntryType.Base).Name;
        }
       }
      }
      else if (fromUnit.Length > 0)
      {
       //	Both units were supplied.
       domain = converter.FindDomain(fromUnit, toUnit);
      }
      if (domain != null && fromUnit.Length > 0 && toUnit.Length > 0)
      {
       Console.WriteLine($"Using domain: {domain.DomainName}");
       //	The unit references are flipped on the second element because
       //	we want a division of the original unit instead of
       //	a multiplication.
       //	ie miles/hr as opposed to miles*hr.
       value = converter.Convert(domain, value, toUnit, fromUnit);
      }
      Console.WriteLine($"Answer: {value} {GetValue(match, "toUnit")}");
     }
     else
     {
      Console.Write("Error: Common domain not found for ");
      Console.WriteLine($"{fromUnit} and {toUnit}.");
     }
    }
   }
  }
 }
}
