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
	//*	ConversionData																													*
	//*-------------------------------------------------------------------------*
	/// <summary>
	/// Information that allows conversions of any two elements of a domain to be
	/// made.
	/// </summary>
	public class ConversionData
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
		//*	Domains																																*
		//*-----------------------------------------------------------------------*
		private ConversionDomainCollection mDomains =
			new ConversionDomainCollection();
		/// <summary>
		/// Get a reference to the collection of domains present in this catalog.
		/// </summary>
		[JsonProperty(Order = 1)]
		public ConversionDomainCollection Domains
		{
			get { return mDomains; }
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
		[JsonProperty(Order = 0)]
		public List<string> Remarks
		{
			get { return mRemarks; }
		}
		//*-----------------------------------------------------------------------*


	}
	//*-------------------------------------------------------------------------*

}
