namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>progress</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlProgressElement"), Alias("progress"), OutputType(typeof(string))]
public class NewProgressElementCommand(): WriteElementCommand("progress", isVoid: false) {

	/// <summary>
	/// Describes how much work the task requires.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public double? Max { get; set; }

	/// <summary>
	/// Specifies how much of the task that has been completed.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.NonNegative)]
	public double? Value { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (Max is not null) attributes["max"] = Max.Value;
		if (Value is not null) attributes["value"] = Value.Value;
	}
}
