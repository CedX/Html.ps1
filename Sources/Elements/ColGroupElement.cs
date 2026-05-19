namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>colgroup</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlColgroupElement"), Alias("colgroup"), OutputType(typeof(string))]
public class NewColgroupElementCommand(): WriteElementCommand("colgroup", isVoid: false) {

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
