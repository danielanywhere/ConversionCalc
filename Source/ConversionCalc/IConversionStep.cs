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

namespace ConversionCalc
{
	//*-------------------------------------------------------------------------*
	//*	IConversionStep																													*
	//*-------------------------------------------------------------------------*
	/// <summary>
	/// Conversion step interface.
	/// </summary>
	public interface IConversionStep
	{
		//*-----------------------------------------------------------------------*
		//*	Domain																																*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Get/Set a reference to the domain to which this definition belongs.
		/// </summary>
		ConversionDomainItem Domain { get; set; }
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	Operation																															*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Get/Set the type of operation used to complete this conversion.
		/// Only used if EntryType == Conversion.
		/// </summary>
		ConversionOperationEnum Operation { get; set; }
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	RefName																																*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Get/Set the name of this step's conversion reference.
		/// </summary>
		string RefName { get; set; }
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	Value																																	*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Get/Set the conversion value.
		/// </summary>
		double Value { get; set; }
		//*-----------------------------------------------------------------------*
	}
	//*-------------------------------------------------------------------------*

}
