namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>li</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlLiElement"), Alias("li"), OutputType(typeof(string))]
public class NewLiElementCommand(): WriteElementCommand("li", isVoid: false) {

	/// <summary>
	/// The ordinal value of the list item as defined by the <c>ol</c> element.
	/// </summary>
	[Parameter]
	public int? Value { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (Value is not null) attributes["value"] = Value.Value;
	}
}
