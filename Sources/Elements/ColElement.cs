namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>col</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlColElement"), Alias("col"), OutputType(typeof(string))]
public class NewColElementCommand(): WriteElementCommand("col", isVoid: true) {

	/// <summary>
	/// The number of consecutive columns the element spans.
	/// </summary>
	[Parameter, ValidateRange(ValidateRangeKind.Positive)]
	public int Span { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (Span > 0) attributes["span"] = Span;
	}
}
