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
using System.Text;

using Newtonsoft.Json;

namespace ConversionCalc
{
	//*-------------------------------------------------------------------------*
	//*	ConversionDefinitionCollection																					*
	//*-------------------------------------------------------------------------*
	/// <summary>
	/// Collection of ConversionDefinitionItem Items.
	/// </summary>
	public class ConversionDefinitionCollection : List<ConversionDefinitionItem>
	{
		//*************************************************************************
		//*	Private																																*
		//*************************************************************************
		//*************************************************************************
		//*	Protected																															*
		//*************************************************************************
		//*************************************************************************
		//*	Public																																*
		//*************************************************************************


	}
	//*-------------------------------------------------------------------------*

	//*-------------------------------------------------------------------------*
	//*	ConversionDefinitionItem																								*
	//*-------------------------------------------------------------------------*
	/// <summary>
	/// Definition of an individual conversion.
	/// </summary>
	public class ConversionDefinitionItem : IConversionStep
	{
		//*************************************************************************
		//*	Private																																*
		//*************************************************************************
		//*************************************************************************
		//*	Protected																															*
		//*************************************************************************
		//*************************************************************************
		//*	Public																																*
		//*************************************************************************
		//*-----------------------------------------------------------------------*
		//*	Aliases																																*
		//*-----------------------------------------------------------------------*
		private List<string> mAliases = new List<string>();
		/// <summary>
		/// Get a reference to the list of aliases by which this conversion might
		/// be known.
		/// </summary>
		[JsonProperty(Order = 2)]
		public List<string> Aliases
		{
			get { return mAliases; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	Domain																																*
		//*-----------------------------------------------------------------------*
		private ConversionDomainItem mDomain = null;
		/// <summary>
		/// Get/Set a reference to the domain to which this definition belongs.
		/// </summary>
		[JsonIgnore]
		public ConversionDomainItem Domain
		{
			get { return mDomain; }
			set { mDomain = value; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	EntryType																															*
		//*-----------------------------------------------------------------------*
		private ConversionDefinitionEntryType mEntryType =
			ConversionDefinitionEntryType.None;
		/// <summary>
		/// Get/Set the entry type of this conversion.
		/// </summary>
		[JsonProperty(Order = 0)]
		public ConversionDefinitionEntryType EntryType
		{
			get { return mEntryType; }
			set { mEntryType = value; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	Name																																	*
		//*-----------------------------------------------------------------------*
		private string mName = "";
		/// <summary>
		/// Get/Set the name of the conversion.
		/// </summary>
		[JsonProperty(Order = 1)]
		public string Name
		{
			get { return mName; }
			set { mName = value; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	Operation																															*
		//*-----------------------------------------------------------------------*
		private ConversionOperationEnum mOperation =
			ConversionOperationEnum.Multiply;
		/// <summary>
		/// Get/Set the type of operation used to complete this conversion.
		/// Only used if EntryType == Conversion.
		/// </summary>
		[JsonProperty(Order = 3)]
		public ConversionOperationEnum Operation
		{
			get { return mOperation; }
			set { mOperation = value; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	RefName																																*
		//*-----------------------------------------------------------------------*
		private string mRefName = "";
		/// <summary>
		/// Get/Set the name of the conversion to look up.
		/// </summary>
		[JsonProperty(Order = 4)]
		public string RefName
		{
			get { return mRefName; }
			set { mRefName = value; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	Steps																																	*
		//*-----------------------------------------------------------------------*
		private ConversionStepCollection mSteps = new ConversionStepCollection();
		/// <summary>
		/// Get a reference to the collection of steps used to complete this
		/// conversion when this is a procedural entry.
		/// </summary>
		[JsonProperty(Order = 6)]
		public ConversionStepCollection Steps
		{
			get { return mSteps; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	Value																																	*
		//*-----------------------------------------------------------------------*
		private double mValue = 0d;
		/// <summary>
		/// Get/Set the conversion value.
		/// </summary>
		[JsonProperty(Order = 5)]
		public double Value
		{
			get { return mValue; }
			set { mValue = value; }
		}
		//*-----------------------------------------------------------------------*


	}
	//*-------------------------------------------------------------------------*

}
