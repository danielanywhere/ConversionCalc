/*
 * Copyright (c). 1997 - 2024 Daniel Patterson, MCSD (danielanywhere).
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 * 
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ConversionCalc;

namespace ConversionCalcExample
{
	//*-------------------------------------------------------------------------*
	//*	Program																																	*
	//*-------------------------------------------------------------------------*
	/// <summary>
	/// The main instance of the ConversionCalcExample application.
	/// </summary>
	public class Program
	{
		//*************************************************************************
		//*	Private																																*
		//*************************************************************************
		//*-----------------------------------------------------------------------*
		//* Clear																																	*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Clear the contents of the specified string builder.
		/// </summary>
		/// <param name="builder">
		/// Reference to the string builder to clear.
		/// </param>
		private static void Clear(StringBuilder builder)
		{
			if(builder?.Length > 0)
			{
				builder.Remove(0, builder.Length);
			}
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* converter_DomainNotFound																							*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// The converter experienced a domain not found error.
		/// </summary>
		/// <param name="sender">
		/// The object raising this event.
		/// </param>
		/// <param name="e">
		/// Text event arguments.
		/// </param>
		private void converter_DomainNotFound(object sender, TextEventArgs e)
		{
			Console.WriteLine("Domain not found:");
			Console.WriteLine($" {e.Value}");
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* converter_MessageReady																								*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// The converter has emitted a message.
		/// </summary>
		/// <param name="sender">
		/// The object raising this event.
		/// </param>
		/// <param name="e">
		/// Text event arguments.
		/// </param>
		private void converter_MessageReady(object sender, TextEventArgs e)
		{
			Console.WriteLine(e.Value);
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* converter_SourceUnitNotFound																					*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// The converter has experienced a source not found error.
		/// </summary>
		/// <param name="sender">
		/// The object raising this event.
		/// </param>
		/// <param name="e">
		/// Text event arguments.
		/// </param>
		private void converter_SourceUnitNotFound(object sender, TextEventArgs e)
		{
			Console.WriteLine("Source unit not found:");
			Console.WriteLine($" {e.Value}");
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* converter_TargetUnitNotFound																					*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// The converter has experienced a source not found error.
		/// </summary>
		/// <param name="sender">
		/// The object raising this event.
		/// </param>
		/// <param name="e">
		/// Text event arguments.
		/// </param>
		private void converter_TargetUnitNotFound(object sender, TextEventArgs e)
		{
			Console.WriteLine("Target unit not found:");
			Console.WriteLine($" {e.Value}");
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* GetValue																															*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Return the value of the specified group member in the provided match.
		/// </summary>
		/// <param name="match">
		/// Reference to the match to be inspected.
		/// </param>
		/// <param name="groupName">
		/// Name of the group for which the value will be found.
		/// </param>
		/// <returns>
		/// The value found in the specified group, if found. Otherwise, empty
		/// string.
		/// </returns>
		private static string GetValue(Match match, string groupName)
		{
			string result = "";

			if(match != null && match.Groups[groupName] != null &&
				match.Groups[groupName].Value != null)
			{
				result = match.Groups[groupName].Value;
			}
			return result;
		}
		//*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*
		/// <summary>
		/// Return the value of the specified group member in a match found with
		/// the provided source and pattern.
		/// </summary>
		/// <param name="source">
		/// Source string to search.
		/// </param>
		/// <param name="pattern">
		/// Regular expression pattern to apply.
		/// </param>
		/// <param name="groupName">
		/// Name of the group for which the value will be found.
		/// </param>
		/// <returns>
		/// The value found in the specified group, if found. Otherwise, empty
		/// string.
		/// </returns>
		private static string GetValue(string source, string pattern,
			string groupName)
		{
			Match match = null;
			string result = "";

			if(source?.Length > 0 && pattern?.Length > 0 && groupName?.Length > 0)
			{
				match = Regex.Match(source, pattern);
				if(match.Success)
				{
					result = GetValue(match, groupName);
				}
			}
			return result;
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* ToDouble																															*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Provide fail-safe conversion of string to numeric value.
		/// </summary>
		/// <param name="value">
		/// Value to convert.
		/// </param>
		/// <returns>
		/// Double-precision floating point value. 0 if not convertible.
		/// </returns>
		private static double ToDouble(object value)
		{
			double result = 0d;

			if(value != null)
			{
				result = ToDouble(value.ToString());
			}
			return result;
		}
		//*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*
		/// <summary>
		/// Provide fail-safe conversion of string to numeric value.
		/// </summary>
		/// <param name="value">
		/// Value to convert.
		/// </param>
		/// <returns>
		/// Double-precision floating point value. 0 if not convertible.
		/// </returns>
		private static double ToDouble(string value)
		{
			double result = 0d;

			try
			{
				result = double.Parse(value);
			}
			catch { }
			return result;
		}
		//*-----------------------------------------------------------------------*

		//*************************************************************************
		//*	Protected																															*
		//*************************************************************************
		//*************************************************************************
		//*	Public																																*
		//*************************************************************************
		//*-----------------------------------------------------------------------*
		//*	_Main																																	*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Configure and run the application.
		/// </summary>
		public static void Main(string[] args)
		{
			bool bShowHelp = false; //	Flag - Explicit Show Help.
			string key = "";        //	Current Parameter Key.
			string lowerArg = "";   //	Current Lowercase Argument.
			StringBuilder message = new StringBuilder();    //	Message to display.
			Program prg = new Program();  //	Initialized instance.

			Console.WriteLine("ConversionCalcExample.exe");
			foreach(string arg in args)
			{
				lowerArg = arg.ToLower();
				key = "/?";
				if(lowerArg == key)
				{
					bShowHelp = true;
					continue;
				}
				key = "/convertfrom:";
				if(lowerArg.StartsWith(key))
				{
					prg.mConvertFrom = arg.Substring(key.Length);
					continue;
				}
				key = "/convertto:";
				if(lowerArg.StartsWith(key))
				{
					prg.mConvertTo = arg.Substring(key.Length);
					continue;
				}
				key = "/wait";
				if(lowerArg.StartsWith(key))
				{
					prg.mWaitAfterEnd = true;
					continue;
				}
			}
			if(!bShowHelp)
			{
				if(prg.mConvertFrom.Length == 0)
				{
					message.AppendLine("Please specify the /convertfrom parameter.");
					bShowHelp = true;
				}
				if(prg.mConvertTo.Length == 0)
				{
					message.AppendLine("Please specify the /convertto parameter.");
					bShowHelp = true;
				}
			}
			if(bShowHelp)
			{
				//	Display Syntax.
				Console.WriteLine(message.ToString() + "\r\n" + ResourceMain.Syntax);
			}
			else
			{
				//	Run the configured application.
				prg.Run();
			}
			if(prg.mWaitAfterEnd)
			{
				Console.WriteLine("Press [Enter] to exit...");
				Console.ReadLine();
			}
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	ConvertFrom																														*
		//*-----------------------------------------------------------------------*
		private string mConvertFrom = "";
		/// <summary>
		/// Get/Set the value and unit to convert from.
		/// </summary>
		public string ConvertFrom
		{
			get { return mConvertFrom; }
			set { mConvertFrom = value; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	ConvertTo																															*
		//*-----------------------------------------------------------------------*
		private string mConvertTo = "";
		/// <summary>
		/// Get/Set the value and unit to convert to.
		/// </summary>
		public string ConvertTo
		{
			get { return mConvertTo; }
			set { mConvertTo = value; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	Run																																		*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Run the configured application.
		/// </summary>
		public void Run()
		{
			bool bContinue = false;
			StringBuilder builder = new StringBuilder();
			Converter converter = new Converter();
			int count = 0;
			ConversionDomainItem domain = null;
			string fromUnit = "";
			double fromValue = 0d;
			int index = 0;
			Match match = null;
			string name = "";
			string s = "";
			List<ConversionDefinitionItem> sourceDefinitions = null;
			List<string> sourceDomains = new List<string>();
			List<ConversionDefinitionItem> targetDefinitions = null;
			List<string> targetDomains = new List<string>();
			double toValue = 0d;

			converter.DomainNotFound += converter_DomainNotFound;
			converter.MessageReady += converter_MessageReady;
			converter.SourceUnitNotFound += converter_SourceUnitNotFound;
			converter.TargetUnitNotFound += converter_TargetUnitNotFound;

			//	Test Degrees to Radians.
			Console.WriteLine("-----");
			Console.WriteLine("Test degrees to radians.");
			Console.WriteLine("Convert from 57.3 deg to rad");
			toValue = converter.Convert("angles", 57.3, "deg", "rad");
			Console.WriteLine($" {toValue:0.###}");

			//	Test Diameter to Area.
			Console.WriteLine("-----");
			Console.WriteLine("Test circle diameter to area.");
			Console.WriteLine("Convert from 10 diameter to area.");
			toValue = converter.Convert("circle", 10, "diameter", "area");
			Console.WriteLine($" {toValue:0.###}");

			//	From Example 1 on GitHub main page.
			Console.WriteLine("-----");
			Console.WriteLine("Test publication article Example 1.");
			RunExample1();

			//	From Example 2 on GitHub main page.
			Console.WriteLine("-----");
			Console.WriteLine("Test publication article Example 2.");
			RunExample2();

			Console.WriteLine("-----");
			Console.WriteLine("Local command-line test.");
			Console.WriteLine($"Convert from: {mConvertFrom} to {mConvertTo}");

			match = Regex.Match(mConvertFrom, ResourceMain.rxValueUnit);
			if(match.Success)
			{
				fromValue = ToDouble(GetValue(match, "value"));
				fromUnit = GetValue(match, "unit");
				if(fromUnit.Length > 0)
				{
					//	A source unit was specified.
					if(mConvertTo.Length > 0)
					{
						//	A target unit was specified.
						//	Let's see if we can find the source and target units.
						domain = converter.FindDomain(fromUnit, mConvertTo);
						if(domain != null)
						{
							Console.WriteLine($"Using domain: {domain.DomainName}");
							bContinue = true;
						}
						else
						{
							//	The common domain for both units was not found.
							//	Is the source unit defined anywhere?
							sourceDefinitions = converter.FindAllDefinitions(fromUnit);
							targetDefinitions = converter.FindAllDefinitions(mConvertTo);
							if(sourceDefinitions.Count > 0 && targetDefinitions.Count > 0)
							{
								//	Both units existed, but not in the same domain.
								foreach(ConversionDefinitionItem defItem in sourceDefinitions)
								{
									name = defItem.Domain.DomainName;
									if(name.Length > 0 && !sourceDomains.Contains(name))
									{
										sourceDomains.Add(name);
									}
								}
								foreach(ConversionDefinitionItem defItem in targetDefinitions)
								{
									name = defItem.Domain.DomainName;
									if(name.Length > 0 && !targetDomains.Contains(name))
									{
										targetDomains.Add(name);
									}
								}
								Clear(builder);
								s = (sourceDomains.Count != 1 ? "s" : "");
								builder.AppendLine(
									$"The unit {fromUnit} appears in the domain{s}:");
								if(sourceDomains.Count > 1)
								{
									count = sourceDomains.Count;
									for(index = 0; index < count - 1; index ++)
									{
										builder.Append(" ");
										builder.Append(sourceDomains[index]);
										builder.Append(",");
									}
									builder.AppendLine($" and {sourceDomains[^1]}");
								}
								else
								{
									builder.AppendLine(sourceDomains[0]);
								}
								s = (targetDomains.Count != 1 ? "s" : "");
								builder.AppendLine(
									$"... but the unit {mConvertTo} appears in the domain{s}:");
								if(targetDomains.Count > 1)
								{
									count = targetDomains.Count;
									for(index = 0; index < count - 1; index++)
									{
										builder.Append(" ");
										builder.Append(targetDomains[index]);
										builder.Append(",");
									}
									builder.AppendLine($" and {targetDomains[^1]}");
								}
								else
								{
									builder.AppendLine(targetDomains[0]);
								}
								Console.WriteLine("Error:");
								Console.WriteLine(builder.ToString());
							}
							else if(sourceDefinitions.Count > 0)
							{
								//	Only the source unit existed.
								Console.WriteLine(
									$"Error: The target unit {mConvertTo} was not found.");
							}
							else if(targetDefinitions.Count > 0)
							{
								//	Only the target unit existed.
								Console.WriteLine(
									$"Error: The source unit {fromUnit} was not found.");
							}
							else
							{
								//	Neither the source nor the target units were found.
								Console.WriteLine(
									$"Error: The units {fromUnit} and " +
									$"{mConvertTo} were not found.");
							}
						}
					}
					else
					{
						Console.WriteLine("Error: No target unit was specified.");
					}
				}
				else
				{
					Console.WriteLine("Error: No source unit was specified.");
				}
			}
			if(bContinue)
			{
				toValue = converter.Convert(domain, fromValue, fromUnit, mConvertTo);
				Console.WriteLine($"Result: {toValue:#,##0.######} {mConvertTo}");
			}
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* RunExample1																														*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// This is a test of the code for Example 1 on the main publication readme
		/// page of the GitHub project.
		/// </summary>
		/// <remarks>
		/// Convert 25,479 teaspoons to cups, using the implicit domain lookup
		/// feature.
		/// </remarks>
		public void RunExample1()
		{
			Converter converter = new Converter();

			double toValue = converter.Convert(25479, "tsp", "cups");
			Console.WriteLine($"Answer: {toValue} cups");

		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* RunExample2																														*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// This is a test of the code for Example 2 on the main publication readme
		/// page of the GitHub project.
		/// </summary>
		/// <remarks>
		/// Multiple conversions for different domains for user input of
		/// "1000 mi/sec to mi/hr".
		/// </remarks>
		public void RunExample2()
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
			if(match.Success)
			{
				//	The first conversion is required.
				value = ToDouble(GetValue(match, "value"));
				fromUnit = GetValue(match, "fromUnit1");
				toUnit = GetValue(match, "toUnit1");
				if(fromUnit.Length > 0 && toUnit.Length > 0)
				{
					//	From and to were both provided.
					domain = converter.FindDomain(fromUnit, toUnit);
					if(domain != null)
					{
						//	A common domain was found.
						Console.WriteLine($"Using domain: {domain.DomainName}");
						value = converter.Convert(domain, value, fromUnit, toUnit);
						Console.WriteLine($"Intermediate. {toUnit} = {value}.");
						//	The second conversion is optional.
						domain = null;
						fromUnit = GetValue(match, "fromUnit2");
						toUnit = GetValue(match, "toUnit2");
						if((fromUnit.Length > 0 || toUnit.Length > 0) &&
							(fromUnit.Length == 0 || toUnit.Length == 0))
						{
							//	Only one unit was supplied.
							if(fromUnit.Length > 0)
							{
								//	The from unit was supplied. Get the default to unit.
								domain = converter.FindDomain(fromUnit);
								if(domain != null &&
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
								if(domain != null &&
									domain.Conversions.Exists(x =>
										x.EntryType == ConversionDefinitionEntryType.Base))
								{
									fromUnit = domain.Conversions.First(x =>
										x.EntryType == ConversionDefinitionEntryType.Base).Name;
								}
							}
						}
						else if(fromUnit.Length > 0)
						{
							//	Both units were supplied.
							domain = converter.FindDomain(fromUnit, toUnit);
						}
						if(domain != null && fromUnit.Length > 0 && toUnit.Length > 0)
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
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	WaitAfterEnd																													*
		//*-----------------------------------------------------------------------*
		private bool mWaitAfterEnd = false;
		/// <summary>
		/// Get/Set a value indicating whether to wait for user keypress after 
		/// processing has completed.
		/// </summary>
		public bool WaitAfterEnd
		{
			get { return mWaitAfterEnd; }
			set { mWaitAfterEnd = value; }
		}
		//*-----------------------------------------------------------------------*

	}
	//*-------------------------------------------------------------------------*

}
