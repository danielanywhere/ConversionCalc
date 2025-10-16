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
	//*	ConversionDefinitionEntryType																						*
	//*-------------------------------------------------------------------------*
	/// <summary>
	/// Enumeration of available definition entry types.
	/// </summary>
	public enum ConversionDefinitionEntryType
	{
		/// <summary>
		/// No conversion entry type defined or unknown.
		/// </summary>
		None = 0,
		/// <summary>
		/// This is the base entry for the domain.
		/// </summary>
		Base,
		/// <summary>
		/// This conversion can be performed as a single operation from the base.
		/// </summary>
		Conversion,
		/// <summary>
		/// Resolve the item externally through an event.
		/// </summary>
		External,
		/// <summary>
		/// This conversion requires a series of operational steps to complete.
		/// </summary>
		Procedure
	}
	//*-------------------------------------------------------------------------*

}
