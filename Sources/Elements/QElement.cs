namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>q</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlQElement"), Alias("q"), OutputType(typeof(string))]
public class NewQElementCommand(): WriteElementCommand("q", isVoid: false) {

	/// <summary>
	/// A URL that designates a source document or message for the information quoted.
	/// </summary>
	[Parameter]
	public Uri? Cite { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (Cite is not null) attributes["cite"] = Cite;
	}
}
