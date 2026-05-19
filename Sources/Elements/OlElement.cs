namespace Belin.Html.Elements;

/// <summary>
/// Creates a new <c>ol</c> element.
/// </summary>
[Cmdlet(VerbsCommon.New, "HtmlOlElement"), Alias("ol"), OutputType(typeof(string))]
public class NewOlElementCommand(): WriteElementCommand("ol", isVoid: false) {

	/// <summary>
	/// Value indicating whether the list's items are in reverse order.
	/// </summary>
	[Parameter]
	public SwitchParameter Reversed { get; set; }

	/// <summary>
	/// An integer to start counting from for the list items.
	/// </summary>
	[Parameter]
	public int? Start { get; set; }

	/// <summary>
	/// Value indicating the current ordinal value of the list item as defined by the <c>ol</c> element.
	/// </summary>
	[Parameter, ValidateSet("1", "A", "a", "I", "i")]
	public string? Type { get; set; }

	/// <summary>
	/// Populates the specified attribute collection with the element attributes.
	/// </summary>
	/// <param name="attributes">The attribute collection to populate.</param>
	protected override void RenderAttributes(IDictionary<string, object?> attributes) {
		base.RenderAttributes(attributes);
		if (Reversed) attributes["reversed"] = true;
		if (Start is not null) attributes["start"] = Start.Value;
		if (Type is not null) attributes["type"] = Type;
	}
}
