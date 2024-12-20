using System;
using ConversionCalc;

// Convert 25,479 teaspoons to cups, using implicit domain lookup.
namespace MyProject
{
 public class Program
 {
  public static void Main(string[] args)
  {
   Converter converter = new Converter();
   double toValue = converter.Convert(25479, "tsp", "cups");
   Console.WriteLine($"Answer: {toValue} cups");
  }
 }
}
