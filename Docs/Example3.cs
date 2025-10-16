using ConversionCalc;

/// <summary>
/// The current font size is 16px (12pt).
/// </summary>
private float mCurrentFontSize = 16f;
/// <summary>
/// Form height: 1080px.
/// </summary>
private float mFormHeight = 1080f;
/// <summary>
/// Form width: 1920px.
/// </summary>
private float mFormWidth = 1920f;
/// <summary>
/// The root font size for the document is 13px (10pt).
/// </summary>
private float mRootFontSize = 13.333333333f;

/// <summary>
/// Up-convert the supplied value for the provided external entry type.
/// </summary>
/// <param name="sender">
/// The object raising this event.
/// </param>
/// <param name="e">
/// Conversion event arguments.
/// </param>
private void converter_ResolveBaseToValue(object sender,
	ConversionEventArgs e)
{
	string name = "";

	//	Relative CSS Unit Values.
	if(e != null)
	{
		name = e.Definition.Name;
		if(name == "vmax")
		{
			if(mFormWidth >= mFormHeight)
			{
				name = "vw";
			}
			else
			{
				name = "vh";
			}
		}
		else if(name == "vmin")
		{
			if(mFormWidth >= mFormHeight)
			{
				name = "vh";
			}
			else
			{
				name = "vw";
			}
		}
		switch(name)
		{
			case "ch":
				//	1ch = height in current font and size * 0.666666667.
				e.Value *= 1d /
					((double)mCurrentFontSize * 0.666666667d * e.Definition.Value);
				e.Handled = true;
				break;
			case "em":
				//	1em = 'M' in current font height.
				e.Value *= 1d / ((double)mCurrentFontSize * e.Definition.Value);
				e.Handled = true;
				break;
			case "ex":
				//	1ex = 'X' in current font height = 16px.
				e.Value *= 1d / ((double)mCurrentFontSize * e.Definition.Value);
				e.Handled = true;
				break;
			case "rem":
				//	1rem = 'M' in root font height.
				e.Value *= 1d / ((double)mRootFontSize * e.Definition.Value);
				e.Handled = true;
				break;
			case "vh":
				//	1vh = (viewport height / 100) pixels.
				e.Value *= 1d /
					(((double)mFormHeight / 100d) * e.Definition.Value);
				e.Handled = true;
				break;
			case "vw":
				//	1vw = (viewport width / 100) pixels.
				e.Value *= 1d / (((double)mFormWidth / 100d) * e.Definition.Value);
				e.Handled = true;
				break;
		}
	}
}

/// <summary>
/// Down-convert the supplied value for the provided external entry type.
/// </summary>
/// <param name="sender">
/// The object raising this event.
/// </param>
/// <param name="e">
/// Conversion event arguments.
/// </param>
private void converter_ResolveValueToBase(object sender,
	ConversionEventArgs e)
{
	string name = "";

	//	Relative CSS Unit Values.
	if(e != null)
	{
		name = e.Definition.Name;
		if(name == "vmax")
		{
			if(mFormWidth >= mFormHeight)
			{
				name = "vw";
			}
			else
			{
				name = "vh";
			}
		}
		else if(name == "vmin")
		{
			if(mFormWidth >= mFormHeight)
			{
				name = "vh";
			}
			else
			{
				name = "vw";
			}
		}
		switch(name)
		{
			case "ch":
				//	1ch = height in current font and size * 0.666666667.
				e.Value *=
					((double)mCurrentFontSize * 0.666666667d * e.Definition.Value);
				e.Handled = true;
				break;
			case "em":
				//	1em = 'M' in current font height.
				e.Value *= ((double)mCurrentFontSize * e.Definition.Value);
				e.Handled = true;
				break;
			case "ex":
				//	1ex = 'X' in current font height = 16px.
				e.Value *= ((double)mCurrentFontSize * e.Definition.Value);
				e.Handled = true;
				break;
			case "rem":
				//	1rem = 'M' in root font height.
				e.Value *= ((double)mRootFontSize * e.Definition.Value);
				e.Handled = true;
				break;
			case "vh":
				//	1vh = (viewport height / 100) pixels.
				e.Value *= (((double)mFormHeight / 100d) * e.Definition.Value);
				e.Handled = true;
				break;
			case "vw":
				//	1vw = (viewport width / 100) pixels.
				e.Value *= (((double)mFormWidth / 100d) * e.Definition.Value);
				e.Handled = true;
				break;
		}
	}
}

/// <summary>
/// The main application.
/// </summary>
/// <param name="args">
/// Command-line parameters.
/// </param>
public static void Main(string[] args)
{
	Converter converter = new Converter();
	ConversionDomainItem domain = null;
	double toValue = 0d;

	converter.ResolveBaseToValue += converter_ResolveBaseToValue;
	converter.ResolveValueToBase += converter_ResolveValueToBase;

	//	Add relative Css Units to the Distance domain.
	domain = mConverter.Data.Domains.FirstOrDefault(x =>
		x.DomainName == "Distance");
	if(domain != null)
	{
		//	All of the CSS relative conversions in this example are
		//	based in pixels.
		domain.Conversions.AddRange(new ConversionDefinitionItem[]
		{
			new ConversionDefinitionItem()
			{
				EntryType = ConversionDefinitionEntryType.External,
				Name = "ch",
				Value = 0.002645833d
			},
			new ConversionDefinitionItem()
			{
				EntryType = ConversionDefinitionEntryType.External,
				Name = "em",
				Value = 0.002645833d
			},
			new ConversionDefinitionItem()
			{
				EntryType = ConversionDefinitionEntryType.External,
				Name = "ex",
				Value = 0.002645833d
			},
			new ConversionDefinitionItem()
			{
				EntryType = ConversionDefinitionEntryType.External,
				Name = "rem",
				Value = 0.002645833d
			},
			new ConversionDefinitionItem()
			{
				EntryType = ConversionDefinitionEntryType.External,
				Name = "vh",
				Value = 0.002645833d
			},
			new ConversionDefinitionItem()
			{
				EntryType = ConversionDefinitionEntryType.External,
				Name = "vmax",
				Value = 0.002645833d
			},
			new ConversionDefinitionItem()
			{
				EntryType = ConversionDefinitionEntryType.External,
				Name = "vmin",
				Value = 0.002645833d
			},
			new ConversionDefinitionItem()
			{
				EntryType = ConversionDefinitionEntryType.External,
				Name = "vw",
				Value = 0.002645833d
			}
		});
	}

	//	CSS Units. Convert 1.2em to px (at 12pt font).
	Console.WriteLine("Test 1.2em to px (at 12pt font).");
	toValue = converter.Convert("distance", 1.2d, "em", "px");
	Console.WriteLine($" {toValue:0.###}px");

}
