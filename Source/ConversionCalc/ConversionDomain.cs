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
	//*	ConversionDomainCollection																							*
	//*-------------------------------------------------------------------------*
	/// <summary>
	/// Collection of ConversionDomainItem Items.
	/// </summary>
	public class ConversionDomainCollection : List<ConversionDomainItem>
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
	//*	ConversionDomainItem																										*
	//*-------------------------------------------------------------------------*
	/// <summary>
	/// Definition of an individual domain whose elements can be compared on par
	/// with one another.
	/// </summary>
	public class ConversionDomainItem
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
		//*	Conversions																														*
		//*-----------------------------------------------------------------------*
		private ConversionDefinitionCollection mConversions =
			new ConversionDefinitionCollection();
		/// <summary>
		/// Get a reference to the collection of conversion definitions for this
		/// domain.
		/// </summary>
		[JsonProperty(Order = 2)]
		public ConversionDefinitionCollection Conversions
		{
			get { return mConversions; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	DomainName																														*
		//*-----------------------------------------------------------------------*
		private string mDomainName = "";
		/// <summary>
		/// Get/Set the name of the domain.
		/// </summary>
		[JsonProperty(Order = 0)]
		public string DomainName
		{
			get { return mDomainName; }
			set { mDomainName = value; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	Remarks																																*
		//*-----------------------------------------------------------------------*
		private List<string> mRemarks = new List<string>();
		/// <summary>
		/// Get a referene to the collection of remarks lines for this data
		/// catalog.
		/// </summary>
		[JsonProperty(Order = 1)]
		public List<string> Remarks
		{
			get { return mRemarks; }
		}
		//*-----------------------------------------------------------------------*


	}
	//*-------------------------------------------------------------------------*

}
