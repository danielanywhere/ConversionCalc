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
	//*	ConversionStepCollection																								*
	//*-------------------------------------------------------------------------*
	/// <summary>
	/// Collection of ConversionStepItem Items.
	/// </summary>
	public class ConversionStepCollection : List<ConversionStepItem>
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
	//*	ConversionStepItem																											*
	//*-------------------------------------------------------------------------*
	/// <summary>
	/// Information about an individual calculation step used during the
	/// conversion.
	/// </summary>
	public class ConversionStepItem : IConversionStep
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
		//*	Operation																															*
		//*-----------------------------------------------------------------------*
		private ConversionOperationEnum mOperation =
			ConversionOperationEnum.Multiply;
		/// <summary>
		/// Get/Set the type of operation used to complete this conversion.
		/// Only used if EntryType == Conversion.
		/// </summary>
		[JsonProperty(Order = 0)]
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
		/// Get/Set the name of this step's conversion reference.
		/// </summary>
		[JsonProperty(Order = 1)]
		public string RefName
		{
			get { return mRefName; }
			set { mRefName = value; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	Value																																	*
		//*-----------------------------------------------------------------------*
		private double mValue = 0d;
		/// <summary>
		/// Get/Set the conversion value.
		/// </summary>
		[JsonProperty(Order = 2)]
		public double Value
		{
			get { return mValue; }
			set { mValue = value; }
		}
		//*-----------------------------------------------------------------------*


	}
	//*-------------------------------------------------------------------------*

}
