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
using System.Diagnostics;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

namespace ConversionCalc
{
	//*-------------------------------------------------------------------------*
	//*	Converter																																*
	//*-------------------------------------------------------------------------*
	/// <summary>
	/// The main converter.
	/// </summary>
	public class Converter
	{
		//*************************************************************************
		//*	Private																																*
		//*************************************************************************
		//*-----------------------------------------------------------------------*
		//* CalculateForward																											*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Return the result of a single calculation in the forward direction.
		/// </summary>
		/// <param name="step">
		/// Reference to the logical operation.
		/// </param>
		/// <param name="value">
		/// The value to convert.
		/// </param>
		/// <returns>
		/// Calculated value.
		/// </returns>
		private static double CalculateForward(IConversionStep step, double value)
		{
			ConversionDefinitionItem defItem = null;
			double result = 0d;

			if(step?.Operation != ConversionOperationEnum.None)
			{
				switch(step.Operation)
				{
					case ConversionOperationEnum.Add:
						result = value + step.Value;
						break;
					case ConversionOperationEnum.Convert:
						if(step.Domain != null)
						{
							defItem = step.Domain.Conversions.FirstOrDefault(x =>
								x.Name == step.RefName || x.Aliases.Contains(step.RefName));
							if(defItem != null)
							{
								result = ProcessForward(defItem, value);
							}
						}
						break;
					case ConversionOperationEnum.Divide:
						if(step.Value != 0d)
						{
							result = value / step.Value;
						}
						break;
					case ConversionOperationEnum.Multiply:
						result = value * step.Value;
						break;
					case ConversionOperationEnum.Reciprocal:
						if(value != 0d)
						{
							result = 1d / value;
						}
						break;
					case ConversionOperationEnum.Subtract:
						result = value - step.Value;
						break;
				}
			}
			return result;
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* CalculateReverse																											*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Return the result of a single calculation in the reverse direction.
		/// </summary>
		/// <param name="step">
		/// Reference to the logical operation.
		/// </param>
		/// <param name="value">
		/// The value to convert.
		/// </param>
		/// <returns>
		/// Calculated value.
		/// </returns>
		private static double CalculateReverse(IConversionStep step, double value)
		{
			ConversionDefinitionItem defItem = null;
			double result = 0d;

			if(step?.Operation != ConversionOperationEnum.None)
			{
				switch(step.Operation)
				{
					case ConversionOperationEnum.Add:
						result = value - step.Value;
						break;
					case ConversionOperationEnum.Convert:
						if(step.Domain != null)
						{
							defItem = step.Domain.Conversions.FirstOrDefault(x =>
								x.Name == step.RefName || x.Aliases.Contains(step.RefName));
							if(defItem != null)
							{
								result = ProcessReverse(defItem, value);
							}
						}
						break;
					case ConversionOperationEnum.Divide:
						result = value * step.Value;
						break;
					case ConversionOperationEnum.Multiply:
						if(step.Value != 0d)
						{
							result = value / step.Value;
						}
						break;
					case ConversionOperationEnum.Reciprocal:
						if(value != 0d)
						{
							result = 1d / value;
						}
						break;
					case ConversionOperationEnum.Subtract:
						result = value + step.Value;
						break;
				}
			}
			return result;
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* ProcessForward																												*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Process the conversion in a forward, natural direction.
		/// </summary>
		/// <param name="definition">
		/// Reference to the conversion definition to be processed.
		/// </param>
		/// <param name="value">
		/// The value to be converted.
		/// </param>
		/// <returns>
		/// The converted value resulting from the operation.
		/// </returns>
		private static double ProcessForward(
			ConversionDefinitionItem definition,
			double value)
		{
			double result = value;

			if(definition?.EntryType != ConversionDefinitionEntryType.Base)
			{
				//	This item is eligible for conversion.
				//	A target is known.
				switch(definition.EntryType)
				{
					case ConversionDefinitionEntryType.Conversion:
						result = CalculateForward(definition, value);
						break;
					case ConversionDefinitionEntryType.Procedure:
						foreach(ConversionStepItem stepItem in definition.Steps)
						{
							result = CalculateForward(stepItem, result);
						}
						break;
				}
			}
			return result;
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* ProcessReverse																												*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Process the conversion in a backward direction, including visiting any
		/// procedural steps in reverse.
		/// </summary>
		/// <param name="definition">
		/// Reference to the conversion definition to be processed.
		/// </param>
		/// <param name="value">
		/// The value to be converted.
		/// </param>
		/// <returns>
		/// The converted value resulting from the operation.
		/// </returns>
		private static double ProcessReverse(ConversionDefinitionItem definition,
			double value)
		{
			int count = 0;
			int index = 0;
			double result = value;
			List<ConversionStepItem> steps = null;

			if(definition?.EntryType != ConversionDefinitionEntryType.Base)
			{
				//	This item is eligible for conversion.
				//	A target is known.
				switch(definition.EntryType)
				{
					case ConversionDefinitionEntryType.Conversion:
						result = CalculateReverse(definition, value);
						break;
					case ConversionDefinitionEntryType.Procedure:
						steps = definition.Steps;
						count = steps.Count;
						for(index = count - 1; index > -1; index --)
						{
							result = CalculateReverse(steps[index], result);
						}
						break;
				}
			}
			return result;
		}
		//*-----------------------------------------------------------------------*

		//*************************************************************************
		//*	Protected																															*
		//*************************************************************************

		//*-----------------------------------------------------------------------*
		//* OnDomainNotFound																											*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Raises the DomainNotFound event when a matching domain was not found
		/// for a referenced or implied domain.
		/// </summary>
		/// <param name="domainName">
		/// Name of the domain not found, if applicable. Otherwise, an empty
		/// string.
		/// </param>
		protected virtual void OnDomainNotFound(string domainName = "")
		{
			DomainNotFound?.Invoke(this, new TextEventArgs(domainName));
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* OnMessageReady																												*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Raises the MessageReady event when a message has been emitted during
		/// a conversion.
		/// </summary>
		/// <param name="messageText">
		/// The text of the message to send.
		/// </param>
		protected virtual void OnMessageReady(string messageText = "")
		{
			MessageReady?.Invoke(this, new TextEventArgs(messageText));
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* OnSourceUnitNotFound																									*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Raises the SourceUnitNotFound event when the specified source unit
		/// name could not be found.
		/// </summary>
		/// <param name="unitName">
		/// Name of the unit that could not be found.
		/// </param>
		protected virtual void OnSourceUnitNotFound(string unitName)
		{
			SourceUnitNotFound?.Invoke(this, new TextEventArgs(unitName));
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* OnTargetUnitNotFound																									*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Raises the TargetUnitNotFound event when the specified target unit
		/// name could not be found.
		/// </summary>
		/// <param name="unitName">
		/// Name of the unit that could not be found.
		/// </param>
		protected virtual void OnTargetUnitNotFound(string unitName)
		{
			TargetUnitNotFound?.Invoke(this, new TextEventArgs(unitName));
		}
		//*-----------------------------------------------------------------------*

		//*************************************************************************
		//*	Public																																*
		//*************************************************************************
		//*-----------------------------------------------------------------------*
		//*	_Constructor																													*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Create a new instance of the Converter item.
		/// </summary>
		public Converter()
		{
			if(mData == null)
			{
				InitializeData(this, ResourceMain.DefaultData);
			}
		}
		//*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*
		/// <summary>
		/// Create a new instance of the Converter item.
		/// </summary>
		/// <param name="jsonData">
		/// The JSON catalog definition string used to intiialize the data.
		/// </param>
		public Converter(string jsonData) : this()
		{
			if(jsonData?.Length > 0)
			{
				InitializeData(this, jsonData);
			}
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* Convert																																*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Return the new version of the source value after it has been converted
		/// from the source unit to the target unit.
		/// </summary>
		/// <param name="domain">
		/// Reference to the domain within which the units will be found.
		/// </param>
		/// <param name="sourceValue">
		/// The value to be converted.
		/// </param>
		/// <param name="sourceUnit">
		/// The unit from which the conversion will be made.
		/// </param>
		/// <param name="targetUnit">
		/// The unit into which the value will be converted.
		/// </param>
		/// <returns>
		/// The value resulting from the conversion.
		/// </returns>
		public double Convert(ConversionDomainItem domain, double sourceValue,
			string sourceUnit, string targetUnit)
		{
			double result = sourceValue;
			ConversionDefinitionItem source = null;
			ConversionDefinitionItem target = null;

			if(domain != null && sourceUnit?.Length > 0 && targetUnit?.Length > 0 &&
				sourceUnit != targetUnit)
			{
				//	Only convert if the source and target units are different.
				source = FindDefinition(domain, sourceUnit);
				target = FindDefinition(domain, targetUnit);
				if(source != null && target != null)
				{
					//	Source and target are available.
					//	Step 1. Convert from source to base.
					if(source.EntryType != ConversionDefinitionEntryType.Base)
					{
						result = ProcessForward(source, result);
					}
					//	Step 2. Convert from base to destination.
					if(target.EntryType != ConversionDefinitionEntryType.Base)
					{
						result = ProcessReverse(target, result);
					}
				}
				else
				{
					if(source == null)
					{
						OnSourceUnitNotFound(
							$"Domain: {domain.DomainName}; Unit: {sourceUnit}");
					}
					if(target == null)
					{
						OnTargetUnitNotFound(
							$"Domain: {domain.DomainName}; Unit: {targetUnit}");
					}
				}
			}
			return result;
		}
		//*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*
		/// <summary>
		/// Return the new version of the source value after it has been converted
		/// from the source unit to the target unit, using an implicit common
		/// domain shared between the source and target units.
		/// </summary>
		/// <param name="sourceValue">
		/// The value to be converted.
		/// </param>
		/// <param name="sourceUnit">
		/// The unit from which the conversion will be made.
		/// </param>
		/// <param name="targetUnit">
		/// The unit into which the value will be converted.
		/// </param>
		/// <returns>
		/// The value resulting from the conversion.
		/// </returns>
		public double Convert(double sourceValue, string sourceUnit,
			string targetUnit)
		{
			ConversionDomainItem domain = null;
			double result = sourceValue;
			ConversionDefinitionItem source = null;
			ConversionDefinitionItem target = null;

			if(sourceUnit?.Length > 0 && targetUnit?.Length > 0 &&
				sourceUnit != targetUnit)
			{
				//	Only convert if the source and target units are different.
				domain = FindDomain(sourceUnit, targetUnit);
				if(domain != null)
				{
					OnMessageReady($"Using domain: {domain.DomainName}");
					source = FindDefinition(domain, sourceUnit);
					target = FindDefinition(domain, targetUnit);
					if(source != null && target != null)
					{
						//	Source and target are available.
						//	Step 1. Convert from source to base.
						if(source.EntryType != ConversionDefinitionEntryType.Base)
						{
							result = ProcessForward(source, result);
						}
						//	Step 2. Convert from base to destination.
						if(target.EntryType != ConversionDefinitionEntryType.Base)
						{
							result = ProcessReverse(target, result);
						}
					}
					else
					{
						if(source == null)
						{
							OnSourceUnitNotFound(
								$"Domain: {domain.DomainName}; Unit: {sourceUnit}");
						}
						if(target == null)
						{
							OnTargetUnitNotFound(
								$"Domain: {domain.DomainName}; Unit: {targetUnit}");
						}
					}
				}
				else
				{
					OnDomainNotFound(
						$"Domain: Implied; Source:{sourceUnit}; Target:{targetUnit}");
				}
			}
			return result;
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	Data																																	*
		//*-----------------------------------------------------------------------*
		private ConversionData mData = null;
		/// <summary>
		/// Get/Set a reference to the active conversion data catalog for this
		/// converter.
		/// </summary>
		public ConversionData Data
		{
			get { return mData; }
			set { mData = value; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* DomainNotFound																												*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Fired when a referenced or implied domain was not found for a
		/// conversion.
		/// </summary>
		public event EventHandler<TextEventArgs> DomainNotFound;
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* FindAllDefinitions																										*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Return all of the definitions where the unit name matches the caller's
		/// requested value.
		/// </summary>
		/// <param name="unitName">
		/// Name of the conversion unit to search for.
		/// </param>
		/// <returns>
		/// Reference to a collection of definitions in any domain that match
		/// the caller's unit name, if any were found. Otherwise, an empty list.
		/// </returns>
		public List<ConversionDefinitionItem> FindAllDefinitions(string unitName)
		{
			List<ConversionDefinitionItem> items = null;
			List<ConversionDefinitionItem> result =
				new List<ConversionDefinitionItem>();

			if(unitName?.Length > 0)
			{
				foreach(ConversionDomainItem domainItem in mData.Domains)
				{
					items = domainItem.Conversions.FindAll(x =>
						x.Name == unitName || x.Aliases.Contains(unitName));
					if(items?.Count > 0)
					{
						result.AddRange(items);
					}
				}
			}
			return result;
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* FindDefinition																												*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Return a reference to the definition specified by the unit name.
		/// </summary>
		/// <param name="domain">
		/// Reference to the domain within which the definition will be found.
		/// </param>
		/// <param name="unitName">
		/// Name of the unit or its alias.
		/// </param>
		/// <returns>
		/// Reference to the conversion definition item, if found. Otherwise, null.
		/// </returns>
		public ConversionDefinitionItem FindDefinition(ConversionDomainItem domain,
			string unitName)
		{
			ConversionDefinitionItem result = null;

			if(domain != null && unitName?.Length > 0)
			{
				result = domain.Conversions.FirstOrDefault(x =>
					x.Name == unitName || x.Aliases.Contains(unitName));
			}
			return result;
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* FindDomain																														*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Find and return the first domain where conversions for both units are
		/// defined.
		/// </summary>
		/// <param name="sourceUnit">
		/// The source unit of the conversion.
		/// </param>
		/// <param name="targetUnit">
		/// The target unit of the conversion.
		/// </param>
		/// <returns>
		/// Reference to the domain where both of the caller's units are defined,
		/// if found. Otherwise, null.
		/// </returns>
		public ConversionDomainItem FindDomain(string sourceUnit,
			string targetUnit)
		{
			ConversionDomainItem result = null;
			ConversionDefinitionItem source = null;
			ConversionDefinitionItem target = null;

			if(sourceUnit?.Length > 0 && targetUnit?.Length > 0)
			{
				foreach(ConversionDomainItem domainItem in mData.Domains)
				{
					source = domainItem.Conversions.FirstOrDefault(x =>
						x.Name == sourceUnit ||
						x.Aliases.Contains(sourceUnit));
					target = domainItem.Conversions.FirstOrDefault(x =>
						x.Name == targetUnit ||
						x.Aliases.Contains(targetUnit));
					if(source != null && target != null)
					{
						result = domainItem;
						break;
					}
				}
			}
			return result;
		}
		//*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -*
		/// <summary>
		/// Find and return the first domain where conversions for the specified
		/// unit is defined.
		/// </summary>
		/// <param name="unitName">
		/// The name of the unit to locate.
		/// </param>
		/// <returns>
		/// Reference to the domain the caller's unit is defined, if found.
		/// Otherwise, null.
		/// </returns>
		public ConversionDomainItem FindDomain(string unitName)
		{
			ConversionDomainItem result = null;

			if(unitName?.Length > 0)
			{
				result = mData.Domains.FirstOrDefault(x =>
					x.Conversions.Exists(y =>
						y.Name == unitName || y.Aliases.Contains(unitName)));
			}
			return result;
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* InitializeData																												*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Initialize the data catalog for the specified session.
		/// </summary>
		/// <param name="converter">
		/// Reference to the converter to be initialized.
		/// </param>
		/// <param name="jsonData">
		/// JSON string data containing the catalog definition to be parsed.
		/// </param>
		/// <remarks>
		/// The Converter Data Catalog schema for this version follows:
		/// <list type="bullet">
		/// <item>**Catalog**.
		/// <list type="bullet">
		/// <item>**Remarks** (StringList). One or more lines of space-extended
		/// multiline text.</item>
		/// <item>**Domains** (DomainCollection). Collection of calculation
		/// domains like *Density*, *Temperature*, etc.
		/// <list type="bullet">
		/// <item>**DomainName** (String). Name of the domain.</item>
		/// <item>**Remarks** (StringList). One or more lines of space-extended
		/// multiline text.</item>
		/// <item>**Conversions**. (ConversionCollection). Collection of
		/// uni-directional calculation conversions, orientent toward the base.
		/// <list type="bullet">
		/// <item>**EntryType** (String). Type of conversion entry:
		/// {None|Base|Conversion|Procedure}.</item>
		/// <item>**Aliases** (StringList). List of alternative names under which
		/// the same conversion can be performed.</item>
		/// <item>**Value** (FloatingPoint). A conversion value used to calclate
		/// this step.</item>
		/// </list>
		/// </item>
		/// </list>
		/// </item>
		/// </list>
		/// </item>
		/// </list>
		/// </remarks>
		public static void InitializeData(Converter converter, string jsonData)
		{
			if(converter != null && jsonData?.Length > 0)
			{
				try
				{
					converter.mData =
						JsonConvert.DeserializeObject<ConversionData>(jsonData);
					//	Initialize domain reference.
					foreach(ConversionDomainItem domainItem in converter.mData.Domains)
					{
						foreach(ConversionDefinitionItem defItem in domainItem.Conversions)
						{
							defItem.Domain = domainItem;
							foreach(ConversionStepItem stepItem in defItem.Steps)
							{
								stepItem.Domain = domainItem;
							}
						}
					}
				}
				catch { }
			}
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* MessageReady																													*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Fired when a message has been emitted during a conversion.
		/// </summary>
		public event EventHandler<TextEventArgs> MessageReady;
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* SourceUnitNotFound																										*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Fired when the source unit for a conversion could not be found.
		/// </summary>
		public event EventHandler<TextEventArgs> SourceUnitNotFound;
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//* TargetUnitNotFound																										*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Fired when the target unit for a conversion could not be found.
		/// </summary>
		public event EventHandler<TextEventArgs> TargetUnitNotFound;
		//*-----------------------------------------------------------------------*

	}
	//*-------------------------------------------------------------------------*

}
