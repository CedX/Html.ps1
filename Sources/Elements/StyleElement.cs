namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>style</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlStyleElement"), Alias("style"), OutputType(typeof(string))]
public class NewStyleElementCommand(): WriteElementCommand("style", isVoid: false) {

	/// <summary>
	/// Defines which media the style should be applied to.
	/// </summary>
	[Parameter]
	public string? Media { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (!string.IsNullOrWhiteSpace(Media)) attributes["media"] = Media;
	}
}
