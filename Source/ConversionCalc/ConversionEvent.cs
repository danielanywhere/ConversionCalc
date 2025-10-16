using System;
using System.Collections.Generic;
using System.Text;

namespace ConversionCalc
{
	//*-------------------------------------------------------------------------*
	//*	ConversionEventArgs																											*
	//*-------------------------------------------------------------------------*
	/// <summary>
	/// Arguments for handling a conversion event.
	/// </summary>
	public class ConversionEventArgs
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
		//*	Definition																														*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Private member for <see cref="Definition">Definition</see>.
		/// </summary>
		private ConversionDefinitionItem mDefinition = null;
		/// <summary>
		/// Get/Set a reference to the conversion definition being processed.
		/// </summary>
		public ConversionDefinitionItem Definition
		{
			get { return mDefinition; }
			set { mDefinition = value; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	Handled																																*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Private member for <see cref="Handled">Handled</see>.
		/// </summary>
		private bool mHandled = false;
		/// <summary>
		/// Get/Set a value indicating whether this event has been handled.
		/// </summary>
		public bool Handled
		{
			get { return mHandled; }
			set { mHandled = value; }
		}
		//*-----------------------------------------------------------------------*

		//*-----------------------------------------------------------------------*
		//*	Value																																	*
		//*-----------------------------------------------------------------------*
		/// <summary>
		/// Private member for <see cref="Value">Value</see>.
		/// </summary>
		private double mValue = 0d;
		/// <summary>
		/// Get/Set the value associated with this conversion.
		/// </summary>
		public double Value
		{
			get { return mValue; }
			set { mValue = value; }
		}
		//*-----------------------------------------------------------------------*


	}
	//*-------------------------------------------------------------------------*

}
