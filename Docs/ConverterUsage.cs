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
