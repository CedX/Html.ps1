namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>map</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlMapElement"), Alias("map"), OutputType(typeof(string))]
public class NewMapElementCommand(): WriteElementCommand("map", isVoid: false) {

	/// <summary>
	/// The map name so that it can be referenced.
	/// </summary>
	[Parameter]
	public string? Name { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (!string.IsNullOrWhiteSpace(Name)) attributes["name"] = Name;
	}
}
