namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>base</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlBaseElement"), Alias("base"), OutputType(typeof(string))]
public class NewBaseElementCommand(): WriteElementCommand("base", isVoid: true) {

	/// <summary>
	/// The base URL to be used throughout the document for relative URLs.
	/// </summary>
	[Parameter(Mandatory = true)]
	public required Uri Href { get; set; }

	/// <summary>
	/// The default browsing context to show the results of navigation from elements without explicit <c>target</c> attribute.
	/// </summary>
	[Parameter]
	public string? Target { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		attributes["href"] = Href;
		if (!string.IsNullOrWhiteSpace(Target)) attributes["target"] = Target;
	}
}
