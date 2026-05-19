namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>meter</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlMeterElement"), Alias("meter"), OutputType(typeof(string))]
public class NewMeterElementCommand(): WriteElementCommand("meter", isVoid: false) {

	/// <summary>
	/// The lower numeric bound of the high end of the measured range.
	/// </summary>
	[Parameter]
	public double? High { get; set; }

	/// <summary>
	/// The upper numeric bound of the low end of the measured range.
	/// </summary>
	[Parameter]
	public double? Low { get; set; }

	/// <summary>
	/// The upper numeric bound of the measured range.
	/// </summary>
	[Parameter]
	public double? Max { get; set; }

	/// <summary>
	/// The lower numeric bound of the measured range.
	/// </summary>
	[Parameter]
	public double? Min { get; set; }

	/// <summary>
	/// The optimal numeric value.
	/// </summary>
	[Parameter]
	public double? Optimum { get; set; }

	/// <summary>
	/// The current numeric value.
	/// </summary>
	[Parameter]
	public double? Value { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (High is not null) attributes["high"] = High.Value;
		if (Low is not null) attributes["low"] = Low.Value;
		if (Max is not null) attributes["max"] = Max.Value;
		if (Min is not null) attributes["min"] = Min.Value;
		if (Optimum is not null) attributes["optimum"] = Optimum.Value;
		if (Value is not null) attributes["value"] = Value.Value;
	}
}
