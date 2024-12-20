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
	//*	ConversionOperationEnum																									*
	//*-------------------------------------------------------------------------*
	/// <summary>
	/// Enumeration of the available range of operations available while
	/// converting.
	/// </summary>
	public enum ConversionOperationEnum
	{
		/// <summary>
		/// No operation defined or unknown.
		/// </summary>
		None = 0,
		/// <summary>
		/// Add the value.
		/// </summary>
		Add,
		/// <summary>
		/// Perform a conversion on the value.
		/// </summary>
		Convert,
		/// <summary>
		/// Divide by the value.
		/// </summary>
		Divide,
		/// <summary>
		/// Multiply by the value.
		/// </summary>
		Multiply,
		/// <summary>
		/// Subtract the value.
		/// </summary>
		Subtract,
		/// <summary>
		/// Get the reciprocal of the value (1/value).
		/// </summary>
		Reciprocal
	}
	//*-------------------------------------------------------------------------*

}
